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

	[ExportView("DPR_History")]
	public partial class DPR_History : VisiWin.Controls.View
	{
        readonly IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");

        public DPR_History()
		{
			this.InitializeComponent();
        }
       
      

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MessageBoxRegion", "EmptyView");
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            string rname = ApplicationService.ObjectStore.GetValue("DPR_History_KEY").ToString();
            if (this.IsVisible)
            {
                txt.Text = RecipeClass.GetRecipeFile(rname).GetValues()["Ergospin.Recipe.Historie"].ToString();

                ApplicationService.ObjectStore.Remove("DPR_History_KEY");
            }
        }
    }
}