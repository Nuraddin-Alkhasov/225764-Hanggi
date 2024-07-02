using HMI.Views.MessageBoxRegion;
using System;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Views.MainRegion
{
    class ExternData
    {
        
        public ExternData()
        {
            MR_Name = "";
        }
        public string MR_Name { set; get; }

        public string GetMR_Name()
        {
            IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Extern");
            if (RecipeClass.IsExistingRecipeFile(MR_Name))
            {
                return MR_Name;
            }
            else {
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text9", MessageBoxIcon.Error);
                return ""; 
            }

        }
        public DateTime GetLastChanged()
        {
            IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Extern");
            if (RecipeClass.IsExistingRecipeFile(MR_Name))
            {
                return RecipeClass.GetRecipeFile(MR_Name).TimeOfLastChange;
            }
            else
            {
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text9", MessageBoxIcon.Error);
                return DateTime.MinValue;
            }

        }
    }
}
