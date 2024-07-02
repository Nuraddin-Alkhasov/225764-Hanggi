using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

	[ExportView("Recipe_IE")]
	public partial class Recipe_IE : VisiWin.Controls.View
	{
        RecipeIEAdapter RIEA;
        public Recipe_IE()
		{
			this.InitializeComponent();

            RIEA = new RecipeIEAdapter();
            this.DataContext = RIEA;

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }
       
        private void Btn1_PreviewTouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            btn1.IsSelected = true;
        }
        private void Btn2_PreviewTouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
           
                btn2.IsSelected = true;
            
           
        }
        private void btn2_KeyDown(object sender, KeyEventArgs e)
        {
            
               
                btn2.IsSelected = true;
          
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            toExport.UnselectAllCells();
        }

        private void toImport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            toImport.UnselectAllCells();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (btn2.IsSelected)
                {
                    RIEA.UpdateRecipeToExport();
                    sopen.Visibility = Visibility.Hidden;
                    fopen.Visibility = Visibility.Hidden;
                    imp.Visibility = Visibility.Hidden;
                    exp.Visibility = Visibility.Visible;
                }
                else 
                {
                    sopen.Visibility = Visibility.Visible;
                    fopen.Visibility = Visibility.Visible;
                    imp.Visibility = Visibility.Visible;
                    exp.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RecipeToIE obj = ((FrameworkElement)sender).DataContext as RecipeToIE;
            ApplicationService.SetView("MessageBoxRegion", "Recipe_Compare", obj);
        }

        private void toImport_Unloaded(object sender, RoutedEventArgs e)
        {
            RIEA.RecipesToImport.Clear();
        }
    }
}