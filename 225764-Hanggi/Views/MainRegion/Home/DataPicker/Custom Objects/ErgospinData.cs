using HMI.Views.MessageBoxRegion;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Views.MainRegion
{
    class ErgospinData
    {
        
        public ErgospinData()
        {
            Name = "";
            MR_Name = "";
            MR_Note = "";
        }
        public string Name { set; get; }
        public string MR_Name { set; get; }
        public string MR_Note { set; get; }

        public string GetMR_Name()
        {
            IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
            if (RecipeClass.IsExistingRecipeFile(MR_Name))
            {
                return MR_Name;
            }
            else {
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text9", MessageBoxIcon.Error);
                return ""; 
            }

        }
        public string GetMR_Note()
        {
            IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
            if (RecipeClass.IsExistingRecipeFile(MR_Name))
            {
                IRecipeFile recipe = RecipeClass.GetRecipeFile(MR_Name);
                MR_Note = recipe.Description;
                return MR_Note;
            }
            else
            {
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text9", MessageBoxIcon.Error);
                return ""; 
            }
            
        }
    }
}
