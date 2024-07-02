using System;
using System.Windows;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

    [ExportView("Extern_Selector")]
    public partial class Extern_Selector : VisiWin.Controls.View
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        readonly ExternBindingAdapter EBA;
        public Extern_Selector()
        {
            this.InitializeComponent();

            EBA = (ExternBindingAdapter)((Extern_Binding)iRS.GetView("Extern_Binding")).DataContext;
            this.DataContext = EBA;

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
            await EBA.UpdateFileList();

            if (dg_recipes.SelectedItem != null)
            {
                dg_recipes.ScrollIntoView(dg_recipes.SelectedItem);
            }
        }

    }
}