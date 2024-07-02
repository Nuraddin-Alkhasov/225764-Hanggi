using HMI.Resources;
using HMI.Views.MainRegion.Recipe;
using HMI.Views.MessageBoxRegion;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Views.MainRegion
{
    public class ForplanRecipesIE
    {
        
        IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
       
        public ObservableCollection<RecipeToIE> GetRecipesToImport(string FolderPath, string[] FileNames)
        {
            ObservableCollection<RecipeToIE> ret = new ObservableCollection<RecipeToIE>();
          
            foreach (string filename in FileNames)
            {
                ret.Add(new RecipeToIE()
                {
                    Name = filename.Replace(".R", ""),
                    Description = "",
                    Type = "Forplan",
                    Path = FolderPath,
                    Extension=".R",
                    isSelected = !RecipeClass.IsExistingRecipeFile(filename.Replace(".R", "")),
                    isExisting = RecipeClass.IsExistingRecipeFile(filename.Replace(".R", "")),
                    Status = RecipeClass.IsExistingRecipeFile(filename.Replace(".R", "")) ? 2 : 1
                });
            }
            return ret;
        }
        public ObservableCollection<RecipeToIE> GetRecipesToExport()
        {
            ObservableCollection<RecipeToIE> ret = new ObservableCollection<RecipeToIE>();
            foreach (string rn in RecipeClass.FileNames)
            {
                IRecipeFile recipe = RecipeClass.GetRecipeFile(rn);
                ret.Add(new RecipeToIE
                {
                    Name = rn,
                    Type = "Forplan",
                    Extension=".R",
                    Path = RecipeClass.CurrentPath+"\\",
                    isSelected = true,
                    isExisting = true,
                    Status = 1
                });
            }
            
            return ret;
        }

        public void Export(RecipeToIE R, string FolderPath) 
        {
            if (!IsFileLocked(R))
            {
                File.Copy(R.Path + R.Name + R.Extension, FolderPath + "\\" + R.Name + ".R", true);
            }
            else
            {
                new MessageBoxTask("@RecipeSystem.IE.Text16", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
            }
        }
        public async Task Import(RecipeToIE R)
        {
            if (!IsFileLocked(R))
            {
                string text = System.IO.File.ReadAllText(R.Path + R.Name + R.Extension);
                VWRecipe VWR = new VWRecipe("Ergospin", text);

                await RecipeClass.SetDefaultValuesToBufferAsync();
                await RecipeClass.WriteBufferToProcessAsync();
                foreach (VWVariable v in VWR.VWVariables)
                {

                    ApplicationService.SetVariableValue(v.Item.ToString(), v.Value);

                }
                ReadProcessToBufferResult r1 = await RecipeClass.ReadProcessToBufferAsync();
                if (r1.Result != GetRecipeResult.Succeeded)
                {
                    new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
                }
                else
                {
                    SaveToFileFromBufferResult r2 = (await RecipeClass.SaveToFileFromBufferAsync(R.Name, VWR.Description, true));
                    if (r2.Result != SaveRecipeResult.Succeeded)
                    {
                        new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
                    }
                }

                await RecipeClass.SetDefaultValuesToBufferAsync();
                await RecipeClass.WriteBufferToProcessAsync();

            }
            else 
            {
                new MessageBoxTask("@RecipeSystem.IE.Text16", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error); 
            }

           


        }
        public bool IsFileLocked(RecipeToIE R)
        {
            bool Locked = false;
            try
            {
                FileStream fs = File.Open(R.Path+ R.Name+R.Extension, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch
            {
                Locked = true;
            }
            return Locked;
        }
      

    }
}
