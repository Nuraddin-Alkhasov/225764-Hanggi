using HMI.Module;
using HMI.Views.MessageBoxRegion;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VisiWin.ApplicationFramework;
using VisiWin.Recipe;

namespace HMI.Views.MainRegion
{
    public class SiemensParser
    {
        IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
        public ObservableCollection<SiemensRecipe> SiemensRecipes = new ObservableCollection<SiemensRecipe>();

        public ObservableCollection<RecipeToIE> GetRecipesToImport(string FilePath)
        {
            DoWork(FilePath);
            ObservableCollection<RecipeToIE> ret = new ObservableCollection<RecipeToIE>();
            foreach (var r in SiemensRecipes)
            {
                ret.Add(new RecipeToIE()
                {
                    Name = r.Name,
                    Article=r.Article,
                    Type = "Siemens",
                    Extension=".csv",
                    Path = FilePath,
                    isSelected = !RecipeClass.IsExistingRecipeFile(r.Name),
                    isExisting = RecipeClass.IsExistingRecipeFile(r.Name),
                    Status = RecipeClass.IsExistingRecipeFile(r.Name.Replace(".R", "")) ? 2 : 1
                });
            }
            return ret;
        }
        public void DoWork(string FilePath) 
        {
            using (var reader = new StreamReader(FilePath, System.Text.Encoding.GetEncoding(1252)))
            {
                List<List<string>> header = new List<List<string>>();
                List<List<string>> variables = new List<List<string>>();
                char s = default(char);
                int RecipeCount = 0;
                string x = "";
                while ((x = reader.ReadLine()).Contains("List separator="))
                {
                    s = GetSeparator(x);
                    RecipeCount = GetRecipeCount(x, s);
                }

                if (s != default(char))
                {
                    while ((x = reader.ReadLine()).Contains("LANGID"))
                    {
                        header.Add(x.Split(s).ToList());
                    }

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (!line.Contains("_Wert_"))
                        {
                            variables.Add(line.Split(s).ToList());
                        }
                    }

                    if (variables.Where(c => c.Count != variables[0].Count).Count() == 0)
                    {
                        for (int i = 1; i <= variables[0].Count - 1; i++)
                        {

                            List<SRValue> l = new List<SRValue>();
                            

                            foreach (List<string> r in variables)
                            {

                                string temp = r[0].Contains("Loop_Time_") ? r[0].Replace("DB_Rez_Gewählt_", "")
                                                                                .Replace("{", "[")
                                                                                .Replace("}_", "].")
                                                                                :
                                                                            r[0].Replace("DB_Rez_Gewählt_", "")
                                                                                .Replace("{", "[")
                                                                                .Replace("}_", "].")
                                                                                .Replace("_Hour", ".Hour")
                                                                                .Replace("_Minute", ".Minute")
                                                                                .Replace("_Second", ".Second");
                                temp += r[0].Contains("Kommentar") ? "#STRING113" : "";

                                l.Add(new SRValue
                                {
                                    Name = temp,

                                    Value = r[i]
                                });
                            }

                            SiemensRecipes.Add(GetSR(l, header[0][i]));
                        }
                    }
                    else
                    {
                        new MessageBoxTask("@RecipeSystem.IE.Text7", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
                    }

                    if (RecipeClass.GetVariableNames().Count-2 != variables.Count) 
                    {
                        SiemensRecipes = new ObservableCollection<SiemensRecipe>();
                        new MessageBoxTask("@RecipeSystem.IE.Text9", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
                    }

                }
                else
                {
                        new MessageBoxTask("@RecipeSystem.IE.Text8", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
                }

            }
        }
        public async Task ImportAsync(RecipeToIE r) 
        {
            SiemensRecipe sr = SiemensRecipes.Where(x => x.Name == r.Name).ToList()[0];

            await RecipeClass.SetDefaultValuesToBufferAsync();
            await RecipeClass.WriteBufferToProcessAsync();

            foreach (SRValue v in sr.Values)
            {

               ApplicationService.SetVariableValue("Ergospin.Recipe." + v.Name, v.Value);

            }
            ReadProcessToBufferResult r1 = await RecipeClass.ReadProcessToBufferAsync();
            if (r1.Result != GetRecipeResult.Succeeded)
            {
                new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
            }
            else
            {
                SaveToFileFromBufferResult r2 = (await RecipeClass.SaveToFileFromBufferAsync(sr.Name, "", true));
                if (r2.Result != SaveRecipeResult.Succeeded)
                {
                    new MessageBoxTask("@RecipeSystem.Results.SaveError", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
                }
            }
            await RecipeClass.SetDefaultValuesToBufferAsync();
            await RecipeClass.WriteBufferToProcessAsync();
        }
        private char GetSeparator(string line)
        {
            char separator = default(char);
            for (int i = 0; i <= line.Length - 1; i++)
            {
                if (line[i] == '=')
                {
                    separator = line[i + 1];
                    break;
                }
            }
            return separator;
        }
        private int GetRecipeCount(string line, char separator)
        {
            int RecipeCount = 0;
            for (int i = 0; i <= line.Length - 1; i++)
            {
                if (line[i] == separator)
                {
                    RecipeCount++;
                }
            }
            return RecipeCount;
        }
        public SiemensRecipe GetSR(List<SRValue> l ,string STR)
        {

            string FinalString = STR.Replace("  ", " ").Replace("/", "");
            int status = 3;
            string article="";
            if (FinalString.Contains("["))
            {
                int Pos1 = FinalString.IndexOf("[") + 1;
                FinalString = FinalString.Substring(Pos1, FinalString.Length - Pos1);
                FinalString = FinalString.Replace("]", "");
                article = STR.Substring(0, Pos1 - 1).Replace(" ", "");
            }
            return new SiemensRecipe() { Values=l, Name=FinalString, Article = article, Status=status};
        }

        public bool WriteArticle(string _a, string _r) 
        {
            DataTable DT = (new LocalDBAdapter("SELECT * " +
                                                  "FROM Barcodes " +
                                                  "WHERE MR='" + _r + "' OR Barcode='"+_a+"';")).DB_Output();
            if (DT.Rows.Count == 0)
            {
                bool result = (new LocalDBAdapter("INSERT INTO Barcodes (Barcode, MR) VALUES ('" + _a + "','" + _r + "')")).DB_Input();
                return true;
            }
            else 
            {
                return false;
            }
            
        }
    }


    public class SiemensRecipe
    {
        public string Name { get; set; }
        public string Article { get; set; }
        public int Status { get; set; }
        public List<SRValue> Values { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    public class SRValue 
    {
        public string Name { get; set; }
        public  string Value { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
