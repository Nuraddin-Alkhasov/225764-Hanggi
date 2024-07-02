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

	[ExportView("Extern_History")]
	public partial class Extern_History : VisiWin.Controls.View
	{

        public Extern_History()
		{
			this.InitializeComponent();
        }
       
      

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetVariableValue("Extern.Recipe.Historie", txt.Text);
            ApplicationService.SetView("DialogRegion", "EmptyView");
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
                txt.Text = ApplicationService.GetVariableValue("Extern.Recipe.Historie").ToString();
        }
    }
}