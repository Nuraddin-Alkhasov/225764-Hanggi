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

	[ExportView("DPR_EHistory")]
	public partial class DPR_EHistory : VisiWin.Controls.View
	{
        readonly IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Extern");

        public DPR_EHistory()
		{
			this.InitializeComponent();
        }
       
      

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("MessageBoxRegion", "EmptyView");
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            string rname = ApplicationService.ObjectStore.GetValue("DPR_EHistory_KEY").ToString();
            if (this.IsVisible)
            {
                txt.Text = RecipeClass.GetRecipeFile(rname).GetValues()["Extern.Recipe.Historie"].ToString();

                ApplicationService.ObjectStore.Remove("DPR_EHistory_KEY");
            }
        }
    }
}