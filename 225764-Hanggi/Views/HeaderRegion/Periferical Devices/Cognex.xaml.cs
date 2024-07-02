using System;
using HMI.Interfaces;
using HMI.Services;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.Views
{
	/// <summary>
	/// Interaction logic for UserAdd.xaml
	/// </summary>
    [ExportView("Cognex")]
	public partial class Cognex : VisiWin.Controls.View, IView
	{
        ICognex BarcodeService = ApplicationService.GetService<ICognex>();

        public Cognex()
		{
			this.InitializeComponent();
                           
        }

        private void OpenConnection_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BarcodeService.OpenConnection();
            
        }

        private void CloseConnection_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BarcodeService.CloseConnection();
        }

        private void CheckConnection_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           status.Value = BarcodeService.CheckConnection();
        }
    }
}