using HMI.Views.MainRegion;
using HMI.Views.MessageBoxRegion;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.Views.TouchpadRegion
{

    [ExportView("WaitScreen")]
    public partial class WaitScreen : VisiWin.Controls.View
    {

        DispatcherTimer _timer_Backup;
        DispatcherTimer _timer_Dataload;
        string Ergospin;
        public WaitScreen()
        {
            this.InitializeComponent();
         

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

        private void View_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            WaitData WD = (WaitData) ApplicationService.ObjectStore.GetValue("WaitScreen_KEY");
            TextBlockText.LocalizableText = WD.LocalizableText;
            Ergospin = WD.Ergospin;
            if (this.IsVisible)
            {
                switch (WD.Type)
                {
                    case 0: Backup_GOGO(); break;
                    case 1: LoadData_GOGO(); break;
                }
            }
            else
            {
                switch (WD.Type)
                {
                    case 0: _timer_Backup.Stop(); break;
                    case 1: _timer_Dataload.Stop(); break;
                }
            }
        }

        private void Backup_GOGO()
        {
            TimeSpan _time = TimeSpan.FromSeconds(5);

            _timer_Backup = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    if (_time == TimeSpan.Zero)
                    {
                        ApplicationService.SetView("TouchpadRegion", "EmptyView");
                       new MessageBoxTask("@Backup.Text2", "@Backup.Text1", MessageBoxIcon.Exclamation);
                    }
                    _time = _time.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);
            _timer_Backup.Start();
        }

        private void LoadData_GOGO()
        {
            TimeSpan _time = TimeSpan.FromSeconds(30);
            _timer_Dataload = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                if (_time == TimeSpan.Zero)
                {
                    ApplicationService.SetVariableValue(Ergospin+".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Not loaded", true);
                    ApplicationService.SetView("TouchpadRegion", "EmptyView");
                    new MessageBoxTask("@RecipeSystem.Results.PLCWriteError", "@RecipeSystem.Results.Text1", MessageBoxIcon.Exclamation);
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer_Dataload.Start();
        }
    }
}