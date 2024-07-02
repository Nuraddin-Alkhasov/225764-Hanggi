using System;
using System.Windows;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

    [ExportView("DPR_Selector")]
    public partial class DPR_Selector : VisiWin.Controls.View
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        DataPickerAdapter DPA;
        public DPR_Selector()
        {
            this.InitializeComponent();
            IRegionService iRS = ApplicationService.GetService<IRegionService>();
            DPA = (DataPickerAdapter)((MO_DataPicker)iRS.GetView("MO_DataPicker")).DataContext;
            this.DataContext =DPA;

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
                doWork();


            }
        }

        private void doWork()
        {
            if (dg_recipes.SelectedItem != null)
            {
                dg_recipes.ScrollIntoView(dg_recipes.SelectedItem);
            }
        }
    }
}