using HMI.Interfaces;
using HMI.Views.MainRegion;
using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Services
{
    [ExportService(typeof(ICognex))]
    [Export(typeof(ICognex))]
    public class Service_Cognex : ServiceBase, ICognex
    {

        HMI.Services.Custom_Objects.Cognex C;
        IVariableService VS = ApplicationService.GetService<IVariableService>();
        IVariable newDataV;
        IRegionService iRS = ApplicationService.GetService<IRegionService>();
        public Service_Cognex()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }

       

        #region OnProject


        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
            base.OnLoadProjectStarted();
        }


        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            C = new Custom_Objects.Cognex();
            C.OpenConnection();
            newDataV = VS.GetVariable("DataPicker.DatafromScanner");
            newDataV.Change += NewDataV_Change;

            base.OnLoadProjectCompleted();
        }

    

        // Hier stehen noch die VisiWin Funktionen zur Verfügung
        protected override void OnUnloadProjectStarted()
        {
            if (C != null)
                C.CloseConnection();
            base.OnUnloadProjectStarted();
        }

        // Hier sind keine VisiWin Funktionen mehr verfügbar. Bei C/S ist die Verbindung zum Server schon getrennt.
        protected override void OnUnloadProjectCompleted()
        {
            base.OnUnloadProjectCompleted();
        }
        public void OpenConnection()
        {
            C.OpenConnection();
        }

        public void CloseConnection()
        {
            C.CloseConnection();
        }

        public string CheckConnection()
        {
            return C.CheckConnection();
        }


        private void NewDataV_Change(object sender, VariableEventArgs e)
        {
            string barcode = e.Value.ToString();
            if (barcode != "") 
            {
                MO_DataPicker MO_DP = (MO_DataPicker)iRS.GetView("MO_DataPicker");
                if (MO_DP.IsVisible) 
                {
                    MO_DP.bc.Value = barcode;
                }
                
                Recipe_Binding RB = (Recipe_Binding)iRS.GetView("Recipe_Binding");
                if (RB.IsVisible)
                {
                    if (RB.dataedit.IsVisible)
                    {
                        RB.barcode.Value = barcode;
                    }
                    else
                    {
                        RB.dgv_bctor.ScrollIntoView(RB.dgv_bctor.Items[RB.GetItem(barcode)]);
                    }
                }

                Extern_Binding EB = (Extern_Binding)iRS.GetView("Extern_Binding");
                if (EB.IsVisible)
                {
                    if (EB.dataedit.IsVisible)
                    {
                        EB.barcode.Value = barcode;
                    }
                    else
                    {
                        EB.dgv_bctor.ScrollIntoView(EB.dgv_bctor.Items[RB.GetItem(barcode)]);
                    }
                }

                HMI.Views.Cognex C = (HMI.Views.Cognex)iRS.GetView("Cognex");
                if (C.IsVisible)
                {
                    C.status.Value = e.Value.ToString();
                }
                ApplicationService.SetVariableValue("DataPicker.DatafromScanner", "");

            }

        }

        #endregion
    }
}
