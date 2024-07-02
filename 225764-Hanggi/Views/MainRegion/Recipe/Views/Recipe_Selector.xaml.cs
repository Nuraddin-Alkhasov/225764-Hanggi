using System;
using System.Windows;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

    [ExportView("Recipe_Selector")]
    public partial class Recipe_Selector : VisiWin.Controls.View
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        readonly RecipeBindingAdapter RBA;
        public Recipe_Selector()
        {
            this.InitializeComponent();

            RBA = (RecipeBindingAdapter)((Recipe_Binding)iRS.GetView("Recipe_Binding")).DataContext;
            this.DataContext = RBA;

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
            await RBA.UpdateFileList();

            if (dg_recipes.SelectedItem != null)
            {
                dg_recipes.ScrollIntoView(dg_recipes.SelectedItem);
            }
        }

    }
}