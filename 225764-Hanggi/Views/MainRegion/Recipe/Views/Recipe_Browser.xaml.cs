using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

    [ExportView("Recipe_Browser")]
    public partial class Recipe_Browser : VisiWin.Controls.View
    {
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        RecipeAdapter RA;
        public Recipe_Browser()
        {
            this.InitializeComponent();

            RA = (RecipeAdapter)((Recipe_Main)iRS.GetView("Recipe_Main")).DataContext;
            this.DataContext = RA;

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
            await RA.UpdateFileList();

            if (dg_recipes.SelectedItem != null)
            {
                dg_recipes.ScrollIntoView(dg_recipes.SelectedItem);
            }
        }

    }
}