using HMI.UserControls;
using HMI.Views.MessageBoxRegion;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;

namespace HMI.Views.MainRegion
{
    /// <summary>
    /// Interaction logic for MainView1.xaml
    /// </summary>
    [ExportView("Recipe_Main")]
    public partial class Recipe_Main 
    { 
        public Recipe_Main()
        {
            InitializeComponent();

            this.DataContext = new RecipeAdapter();
        }

      

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "Recipe_Browser");
        }
        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "Recipe_Binding");
        }

        private void SV_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var value = ApplicationService.ObjectStore.GetValue("Recipe_Main_KEY");
            if (value.ToString() != "")
            {
                ErgospinData data = (ErgospinData)value;
                ApplicationService.ObjectStore.Remove("Recipe_Main_KEY"); //sss
                RecipeAdapter ra = (RecipeAdapter)this.DataContext;
                if (ra.Items.Count == 10)
                {
                    MachineRecipe temp=  new MachineRecipe { Name = data.GetMR_Name(), Note = data.GetMR_Note() };
                    if (temp.Name != "")
                    {
                        ra.SelectedRecipe = temp;
                        ra.LoadRecipeToBufferCommandExecuted(null);
                    }

                }

            }
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "Recipe_IE");
        }

        private void Button_Click_3(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationService.SetView("DialogRegion", "Recipe_History"); 
        }
    }
}
