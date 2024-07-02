using Cognex.DataMan.SDK;
using Cognex.DataMan.SDK.Utils;
using HMI.Views.MessageBoxRegion;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml;
using VisiWin.ApplicationFramework;

namespace HMI.Services.Custom_Objects
{
    public class Cognex
    {
        IRegionService iRS = ApplicationService.GetService<IRegionService>();


        
        public Cognex() 
        {
            status = "";
            _connector = null;
            _system = null;
            _results = null;
            IP = "192.168.3.112";
            Port = 23;
            User = "admin";
            Password = "";
        }

        #region - - - Properties - - -

        string status = "";
        private ISystemConnector _connector;
        private DataManSystem _system;
        private ResultCollector _results;
        private string IP;
        private int Port;
        private string User;
        private string Password;

        #endregion


        #region - - - Event Handlers - - -

        private void OnSystemConnected(object sender, EventArgs args)
        {
           
            status = "Connected";
            new MessageBoxTask("@Cognex.Text9", "@Cognex.Text10", MessageBoxIcon.Information);
        }

        private void OnSystemDisconnected(object sender, EventArgs args)
        {

            status = "Disconected";
            new MessageBoxTask("@Cognex.Text11", "@Cognex.Text10", MessageBoxIcon.Information);
        }

        private void OnKeepAliveResponseMissed(object sender, EventArgs args)
        {
            status = "Keep-alive response missed";
            // new MessageBoxTask("@Admin.Text12", "@Admin.Text10", MessageBoxIcon.Information);
        }

        private void OnSystemWentOnline(object sender, EventArgs args)
        {

            status = "System went online";
            //  new MessageBoxTask("@Admin.Text13", "@Admin.Text10", MessageBoxIcon.Information);
        }

        private void OnSystemWentOffline(object sender, EventArgs args)
        {
            status = "System went offline";
            //  new MessageBoxTask("@Admin.Text14", "@Admin.Text10", MessageBoxIcon.Information);
        }

        private void Results_ComplexResultCompleted(object sender, ComplexResult e)
        {
            foreach (var simple_result in e.SimpleResults)
            {
                if (simple_result.Id.Type == ResultTypes.ReadXml)
                {
                    string a = GetReadStringFromResultXml(simple_result.GetDataAsString());
                    status = a;
                    ApplicationService.SetVariableValue("DataPicker.DatafromScanner", a);
                }
            }
        }

        private void Results_SimpleResultDropped(object sender, SimpleResult e)
        {
            status = e.ToString();
        }

        #endregion

        #region - - - Methods - - -

        public void OpenConnection()
        {
            try
            {

                EthSystemConnector conn = new EthSystemConnector(IPAddress.Parse(IP), Port);

                conn.UserName = User;
                conn.Password = Password;

                _connector = conn;

                _system = new DataManSystem(_connector);
                _system.DefaultTimeout = 5000;

                // Subscribe to events that are signalled when the system is connected / disconnected.
                _system.SystemConnected += new SystemConnectedHandler(OnSystemConnected);
                _system.SystemDisconnected += new SystemDisconnectedHandler(OnSystemDisconnected);
                _system.SystemWentOnline += new SystemWentOnlineHandler(OnSystemWentOnline);
                _system.SystemWentOffline += new SystemWentOfflineHandler(OnSystemWentOffline);
                _system.KeepAliveResponseMissed += new KeepAliveResponseMissedHandler(OnKeepAliveResponseMissed);

                // Subscribe to events that are signalled when the device sends auto-responses.
                ResultTypes requested_result_types = ResultTypes.ReadXml | ResultTypes.Image | ResultTypes.ImageGraphics;
                _results = new ResultCollector(_system, requested_result_types);
                _results.ComplexResultCompleted += Results_ComplexResultCompleted;
                _results.SimpleResultDropped += Results_SimpleResultDropped;

                _system.SetKeepAliveOptions(true, 3000, 1000);
                status = "Not Connected";

                Task obTask = Task.Run(async () =>
                {
                    await Task.Delay(4000);
                   
                    _system.Connect();
                });
               

                try
                {
                    _system.SetResultTypes(requested_result_types);
                }
                catch
                { }
            }
            catch (Exception ex)
            {
                CloseConnection();
                new MessageBoxTask(ex, "", MessageBoxIcon.Error);

            }


        }
        public void CloseConnection()
        {
            try
            {
                if (null != _system) 
                {
                    Task obTask = Task.Run(() =>
                    {
                        _system.Disconnect();
                    });
                }
                    
                if (null != _system)
                {
                    _system.SystemConnected -= OnSystemConnected;
                    _system.SystemDisconnected -= OnSystemDisconnected;
                    _system.SystemWentOnline -= OnSystemWentOnline;
                    _system.SystemWentOffline -= OnSystemWentOffline;
                    _system.KeepAliveResponseMissed -= OnKeepAliveResponseMissed;
                }

                _connector = null;
                _system = null;
                if (_results != null)
                    _results.ClearCachedResults();
                _results = null;
                status = "Disconnected";
            }
            catch
            { }
        }
        public string CheckConnection()
        {
            return status;
        }
        private string GetReadStringFromResultXml(string resultXml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                doc.LoadXml(resultXml);

                XmlNode full_string_node = doc.SelectSingleNode("result/general/full_string");

                if (full_string_node != null && _system != null && _system.State == ConnectionState.Connected)
                {
                    XmlAttribute encoding = full_string_node.Attributes["encoding"];
                    if (encoding != null && encoding.InnerText == "base64")
                    {
                        if (!string.IsNullOrEmpty(full_string_node.InnerText))
                        {
                            byte[] code = Convert.FromBase64String(full_string_node.InnerText);
                            return _system.Encoding.GetString(code, 0, code.Length);
                        }
                        else
                        {
                            return "";
                        }
                    }

                    return full_string_node.InnerText;
                }
            }
            catch
            {
            }

            return "";
        }

        #endregion

    }
}
