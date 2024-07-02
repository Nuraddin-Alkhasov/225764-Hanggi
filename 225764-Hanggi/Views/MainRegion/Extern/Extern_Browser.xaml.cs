using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

    [ExportView("Extern_Browser")]
    public partial class Extern_Browser : VisiWin.Controls.View
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        ExternAdapter EA;
        public Extern_Browser()
        {
            this.InitializeComponent();

            EA = (ExternAdapter)((Extern_Main)iRS.GetView("Extern_Main")).DataContext;
            this.DataContext = EA;

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

        private void Main_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
            {
                doWorkAsync();
            }
        }
       
        private async void doWorkAsync() 
        {
            await EA.UpdateFileList();

            if (dg_recipes.SelectedItem != null)
            {
                dg_recipes.ScrollIntoView(dg_recipes.SelectedItem);
            }
        }

    }
}