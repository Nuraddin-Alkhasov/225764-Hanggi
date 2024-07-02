using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Recipe;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

	[ExportView("Recipe_Compare")]
	public partial class Recipe_Compare : VisiWin.Controls.View
	{
        RecipeCompareAdapter RCA;
        public Recipe_Compare()
		{
			this.InitializeComponent();

            RCA = new RecipeCompareAdapter();
            this.DataContext = RCA;

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }
       
      

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MessageBoxRegion", "EmptyView");
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible) 
            {
                RCA.ToCompare = (RecipeToIE) ApplicationService.ObjectStore.GetValue("Recipe_Compare_KEY");
                ApplicationService.ObjectStore.Remove("Recipe_Compare_KEY");
            } 
        }

        private void toImport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            toImport.UnselectAllCells();
        }
    }
}