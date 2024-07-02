using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Language;

namespace HMI.UserControls
{
    public partial class MV_ErgospinS : UserControl
    {
        public MV_ErgospinS()
        {
            InitializeComponent();
            IsChecked = false;
          
            Application.Current.MainWindow.Closed += MainWindow_Closed;
            var image = new BitmapImage();
            
        }
        #region - - - - Properties - - - -
        readonly ILanguageService TS = ApplicationService.GetService<ILanguageService>();
        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        IVariable VWV_Status;
       
        bool isClosed = false;
        public bool IsChecked
        {
            get { return (bool)selected.IsChecked; }
            set { selected.IsChecked = value; }
        }
        public string ergospinName;
        public string ErgospinName
        {
            get { return ergospinName; }
            set
            {
                ergospinName = value;
                pic.SymbolResourceKey = "Ergospin" + value + "_S";

                VWV_Status = VS.GetVariable(value + ".PLC.Blocks.DB PC.Status.Maschinenstatus");
                VWV_Status.Change += VWV_Status_Change;
                CheckConenction(true);
            }
        }
       
        private bool ConnectionStatus { set; get; }

        private bool ucloaded = false;
        public bool IsRecipeLoaded
        {
            get { return (bool)loaded.IsChecked; }
            set
            {
                selected.IsChecked = false;
                loaded.Visibility = Visibility.Visible;
                loaded.IsChecked = value;
            }
        }

      
        #endregion



        #region - - - - Event Handlers - - - -
        private void Loaded_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            selected.IsChecked = false;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            isClosed = true;
        }

        private void Selected_Click(object sender, RoutedEventArgs e)
        {
            loaded.Visibility = Visibility.Hidden;
            loaded.IsChecked = false;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!ucloaded)
            {
                Task obTask = Task.Run(async () =>
                {
                    await Application.Current.Dispatcher.InvokeAsync((Action)delegate
                    {
                        A.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 1));
                    });
                });

                ucloaded = true;
            }
            loaded.Visibility = Visibility.Hidden;
            loaded.IsChecked = false;
        }

        private void VWV_Status_Change(object sender, VariableEventArgs e)
        {
            switch ((short)e.Value)
            {
                case 0:
                    selected.IsEnabled = true;
                    status.Value = TS.GetText(@"Lists.Status1.Text2");
                    status.Background = (System.Windows.Media.Brush)Application.Current.FindResource("FP_Red_Gradient");
                    break;
                case 1:
                    status.Value = TS.GetText(@"Lists.Status1.Text1");
                    status.Background = (System.Windows.Media.Brush)Application.Current.FindResource("FP_LightGreen_Gradient");
                    selected.IsEnabled = false;
                    IsChecked = false;
                    break;
                default: break;
            }
            loaded.Visibility = Visibility.Hidden;
        }
        #endregion

        #region - - - - Methods - - - -
        public bool GetStatus()
        {
            if (status.Value == "An")
            {
                return true;
            }
            else
            {
                return false;
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

                if ((short)VWV_Status.Value != 1)
                {
                    selected.IsEnabled = true;
                }
            }
            else
            {
                conn.Value = TS.GetText(@"Lists.Status2.Text2");
                conn.Background = (System.Windows.Media.Brush)Application.Current.FindResource("FP_Red_Gradient");
                selected.IsEnabled = false;
                IsChecked = false;
                status.Value = TS.GetText(@"Lists.Status1.Text2");
                status.Background = (System.Windows.Media.Brush)Application.Current.FindResource("FP_Red_Gradient");
            }
            loaded.Visibility = Visibility.Hidden;
        }
        public override string ToString()
        {
            return ErgospinName;
        }

        #endregion
    }
}
