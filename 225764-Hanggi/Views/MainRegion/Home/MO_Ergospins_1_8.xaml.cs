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
    [ExportView("MO_Ergospins_1_8")]
    public partial class MO_Ergospins_1_8 : VisiWin.Controls.View
    {
        MV_Ergospin Ergospin1;
        MV_Ergospin Ergospin2;
        MV_Ergospin Ergospin3;
        MV_Ergospin Ergospin4;
        MV_Ergospin Ergospin5;
        MV_Ergospin Ergospin6;
        MV_Ergospin Ergospin10;
        MV_Ergospin Ergospin8;

        public MO_Ergospins_1_8()
        {
            InitializeComponent();
        }
        bool ViewLoaded = false;
        private void LayoutRoot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!ViewLoaded) 
            {
                Task.Run(async () => {
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin6 = new MV_Ergospin
                        {
                            ErgospinName = "DarkBlue"

                        };
                        Grid.SetRow(Ergospin6, 0);
                        Grid.SetColumn(Ergospin6, 0);
                        ergospins.Children.Add(Ergospin6);
                    });
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin5 = new MV_Ergospin
                        {
                            ErgospinName = "YellowGreen"
                        };
                        Grid.SetRow(Ergospin5, 0);
                        Grid.SetColumn(Ergospin5, 1);
                        ergospins.Children.Add(Ergospin5);
                    });
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin1 = new MV_Ergospin
                        {
                            ErgospinName= "MelonYellow"
                        };

                        Grid.SetRow(Ergospin1, 0);
                        Grid.SetColumn(Ergospin1, 2);
                        ergospins.Children.Add(Ergospin1);
                    });
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin8 = new MV_Ergospin
                        {
                            ErgospinName = "TurquoiseGreen"

                        };
                        Grid.SetRow(Ergospin8, 0);
                        Grid.SetColumn(Ergospin8, 4);
                        ergospins.Children.Add(Ergospin8);
                    });
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin10 = new MV_Ergospin
                        {
                            ErgospinName = "WaterBlue"
                        };
                        Grid.SetRow(Ergospin10, 1);
                        Grid.SetColumn(Ergospin10, 0);
                        ergospins.Children.Add(Ergospin10);
                    });
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin4 = new MV_Ergospin
                        {
                            ErgospinName = "MarineBlue"
                        };
                        Grid.SetRow(Ergospin4, 1);
                        Grid.SetColumn(Ergospin4, 1);
                        ergospins.Children.Add(Ergospin4);
                    });
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin3 = new MV_Ergospin
                        {
                            ErgospinName = "LightBlue"
                        };
                        Grid.SetRow(Ergospin3, 1);
                        Grid.SetColumn(Ergospin3, 2);
                        ergospins.Children.Add(Ergospin3);
                    });
                    await Task.Delay(500);
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Ergospin2 = new MV_Ergospin
                        {
                            ErgospinName = "Pink"
                        };
                        Grid.SetRow(Ergospin2, 1);
                        Grid.SetColumn(Ergospin2, 3);
                        ergospins.Children.Add(Ergospin2);
                    });

                   

                   

                    

                    

                    

                   
                });
                ViewLoaded = true;
            }
        }
    }
}
