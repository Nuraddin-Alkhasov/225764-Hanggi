using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;
using HMI.Views.MainRegion;

namespace HMI
{
    /// <summary>
    /// Interaction logic for MainView1.xaml
    /// </summary>
    [ExportView("Extern_Main")]
    public partial class Extern_Main : VisiWin.Controls.View
    {
        public Extern_Main()
        {
            InitializeComponent();
            this.DataContext = new ExternAdapter();
        }
        private void SV_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var value = ApplicationService.ObjectStore.GetValue("Extern_Main_KEY");
            if (value.ToString() != "")
            {
                ExternData data = (ExternData)value;
                ApplicationService.ObjectStore.Remove("Extern_Main_KEY"); //sss
                ExternAdapter ra = (ExternAdapter)this.DataContext;
                if (ra.Items.Count == 6)
                {
                    MachineRecipe temp = new MachineRecipe { Name = data.GetMR_Name(), LastChanged = data.GetLastChanged()};
                    if (temp.Name != "")
                    {
                        ra.SelectedRecipe = temp;
                        ra.LoadRecipeToBufferCommandExecuted(null);
                    }

                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "Extern_Browser");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "Extern_Binding");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "Extern_History");
        }
    }
}
