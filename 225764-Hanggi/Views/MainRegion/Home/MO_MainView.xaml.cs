using HMI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;

namespace HMI.Views.MainRegion
{
    /// <summary>
    /// Interaction logic for MainView1.xaml
    /// </summary>
    [ExportView("MO_MainView")]
    public partial class MO_MainView : VisiWin.Controls.View
    {
        public MO_MainView()
        {
            InitializeComponent();
        }
        bool ViewLoaded = false;
        private void Button_Click1(object sender, System.Windows.RoutedEventArgs e)
        {
            pn_.ScrollNext();
        }
        private void Button_Click2(object sender, System.Windows.RoutedEventArgs e)
        {
            pn_.ScrollPrevious();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "MO_DataPicker"); 
        }

        private void pn__SelectedPanoramaRegionChanged(object sender, VisiWin.Controls.SelectedPanoramaRegionChangedEventArgs e)
        {
            if (pn_.SelectedPanoramaRegionIndex == 0)
            {
                b1.Visibility = System.Windows.Visibility.Visible;
                b2.Visibility = System.Windows.Visibility.Hidden;
            }
            else 
            {
                b1.Visibility = System.Windows.Visibility.Hidden;
                b2.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
