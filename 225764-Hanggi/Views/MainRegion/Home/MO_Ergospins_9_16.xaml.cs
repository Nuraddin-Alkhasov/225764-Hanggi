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
    [ExportView("MO_Ergospins_9_16")]
    public partial class MO_Ergospins_9_16 : VisiWin.Controls.View
    {
        MV_Ergospin Ergospin9;
        MV_Ergospin Ergospin7;
        public MO_Ergospins_9_16()
        {
            InitializeComponent();
        }
        bool ViewLoaded = false;
        private void LayoutRoot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!ViewLoaded) 
            {
                Task.Run(async () => {
                    await Task.Delay(4500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin7 = new MV_Ergospin
                        {
                            ErgospinName = "Orange"

                        };
                        Grid.SetRow(Ergospin7, 0);
                        Grid.SetColumn(Ergospin7, 0);
                        ergospins.Children.Add(Ergospin7);
                    });
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin9 = new MV_Ergospin
                        {
                            ErgospinName= "RubinRed"
                        };

                        Grid.SetRow(Ergospin9, 0);
                        Grid.SetColumn(Ergospin9, 1);
                        ergospins.Children.Add(Ergospin9);
                    });

                   

                });
                ViewLoaded = true;
            }
        }

      
    }
}
