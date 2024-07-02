using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;
using HMI.Views.DialogRegion;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;

namespace HMI
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    [ExportView("HeaderView")]
    public partial class HeaderView : VisiWin.Controls.View
    {
        public HeaderView()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogView.Show("Cognex", "Cognex barcode scanner", DialogButton.Close, DialogResult.Cancel);
        }
        
      
    }
}