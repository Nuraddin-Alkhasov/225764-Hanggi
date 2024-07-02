using HMI.Views.MainRegion;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.UserControls
{
    public partial class MV_Ergospin : UserControl
    {
        public MV_Ergospin()
        {
            InitializeComponent();

            Application.Current.MainWindow.Closed += MainWindow_Closed;
        }

        #region - - - - Properties - - - -

        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        readonly ILanguageService TS = ApplicationService.GetService<ILanguageService>();
        IVariable VWV_Status;
        IVariable VWV_Step;
        bool isClosed = false;
       
        public string ergospinName;
        public string ErgospinName 
        {
            get { return ergospinName; }
            set
            {
                ergospinName = value;
                pic.SymbolResourceKey = "Ergospin" + value;
                planet.VariableName = value + ".PLC.Blocks.DB PC.Status.Drehzahlen.Planet";
                rotor.VariableName = value + ".PLC.Blocks.DB PC.Status.Drehzahlen.Rotor";
                swing.VariableName = value + ".PLC.Blocks.DB PC.Status.Drehzahlen.Swing";
                recipe.VariableName = value + ".PLC.Blocks.DB PC.Status.Aktuelles Rezept#STRING40";
                sh.VariableName = value + ".PLC.Blocks.DB PC.Status.Zeit Step.Stunde";
                sm.VariableName = value + ".PLC.Blocks.DB PC.Status.Zeit Step.Minute";
                ss.VariableName = value + ".PLC.Blocks.DB PC.Status.Zeit Step.Sekunde";
                th.VariableName = value + ".PLC.Blocks.DB PC.Status.Zeit Total.Stunde";
                tm.VariableName = value + ".PLC.Blocks.DB PC.Status.Zeit Total.Minute";
                ts.VariableName = value + ".PLC.Blocks.DB PC.Status.Zeit Total.Sekunde";

                VWV_Status = VS.GetVariable(value + ".PLC.Blocks.DB PC.Status.Maschinenstatus");
                VWV_Status.Change += VWV_Status_Change;
                CheckConenction(true);

                VWV_Step = VS.GetVariable(value+ ".PLC.Blocks.DB PC.Status.Schrittnummer");
                VWV_Step.Change += VWV_Step_Change;
            }
        }

        private bool loaded = false;
        private bool ConnectionStatus { set; get; }
        #endregion

        #region - - - - Event Handlers - - - -
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            isClosed = true;
        }

        private void VWV_Status_Change(object sender, VariableEventArgs e)
        {
            switch ((short)e.Value)
            {
                case 0:
                    status.Value = TS.GetText(@"Lists.Status1.Text2");
                    status.Background = (System.Windows.Media.Brush)Application.Current.FindResource("FP_Red_Gradient");
                    break;
                case 1:
                    status.Value = TS.GetText(@"Lists.Status1.Text1");
                    status.Background = (System.Windows.Media.Brush)Application.Current.FindResource("FP_LightGreen_Gradient");
                    break;
                default: break;
            }

        }
        private void VWV_Step_Change(object sender, VariableEventArgs e)
        {
            VisiWin.Controls.TextStateCollection x = (VisiWin.Controls.TextStateCollection)Application.Current.FindResource("Steps");
            step.Value = TS.GetText(x.Where(temp => temp.Value == e.Value.ToString()).ToArray()[0].LocalizableText);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!loaded)
            {
                Task obTask = Task.Run(async () =>
                {
                    await Application.Current.Dispatcher.InvokeAsync((Action)delegate
                    {
                        A.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 1));
                    });
                });

                loaded = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "MO_DataPicker");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IRegionService iRS = ApplicationService.GetService<IRegionService>();
            AppbarView abv = (AppbarView)iRS.GetView("AppbarView");
            abv.recipe.IsChecked = true;
            ApplicationService.SetView("MainRegion", "Recipe_Main", new ErgospinData { Name = ErgospinName, MR_Name = recipe.Value });


        }
        #endregion

        #region - - - - Methods - - - -

        private void CheckConenction(bool firstStart)
        {
            Task.Run(async () => {
                while (!isClosed)
                {
                    if (ConnectionStatus != VWV_Status.IsQualityGood || firstStart)
                    {
                        if (firstStart)
                            firstStart = false;
                        ConnectionStatus = VWV_Status.IsQualityGood;
                        await Dispatcher.InvokeAsync(delegate
                        {
                            SetConenctionStatus();
                        });
                    }
                    await Task.Delay(2000);
                }
            });

        }
        private void SetConenctionStatus()
        {
            if (VWV_Status.IsQualityGood)
            {
                conn.Value = TS.GetText(@"Lists.Status2.Text1");
                conn.Background = (System.Windows.Media.Brush)Application.Current.FindResource("FP_LightGreen_Gradient");
            }
            else
            {
                conn.Value = TS.GetText(@"Lists.Status2.Text2");
                conn.Background = (System.Windows.Media.Brush)Application.Current.FindResource("FP_Red_Gradient");
                recipe.Value = "";
                step.Value = "";
                status.Value = TS.GetText(@"Lists.Status1.Text2");
                sh.Value = 0;
                sm.Value = 0;
                ss.Value = 0;
                th.Value = 0;
                tm.Value = 0;
                ts.Value = 0;
            }
        }
        private DoubleAnimation SetOpacity(Double _O, int _T)
        {
            return new DoubleAnimation
            {
                To = _O,
                Duration = TimeSpan.FromSeconds(_T),
            };
        }
        public override string ToString()
        {
            return ErgospinName;
        }
        #endregion

    }
}
