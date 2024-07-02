using HMI.Module;
using HMI.UserControls;
using HMI.Views.MessageBoxRegion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Controls;
using VisiWin.DataAccess;
using VisiWin.Recipe;

namespace HMI.Views.MainRegion
{

    [ExportAdapter("ExternAdapter")]
    public class ExternAdapter : AdapterBase
    {
        //readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        //readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        //IVariable LE;
        //readonly string isEditable = "";
        public ExternAdapter()
        {
            this.LoadFile = new ActionCommand(this.LoadRecipeToBufferCommandExecuted);
            this.SaveFile = new ActionCommand(this.SaveRecipeCommandExecuted);
            this.CopyFile = new ActionCommand(this.CopyFileExecuted);
            this.DeleteFile = new ActionCommand(this.OnDeleteFileCommandExecuted);
            this.Close = new ActionCommand(this.OnCloseCommandExecuted);
            this.PropertyChanged += this.OnSelectedFileChanged;
            FillTheGrid();
        }



        #region - - - Properties - - -
        IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Extern");
        private ObservableCollection<MachineRecipe> recipes = new ObservableCollection<MachineRecipe>();
        public ObservableCollection<MachineRecipe> Recipes
        {
            get { return this.recipes; }
            set
            {
                if (!Equals(value, this.recipes))
                {
                    this.recipes = value;
                    if (Filter == "")
                        Recipes_Temp = value;
                    this.OnPropertyChanged("Recipes");
                }
            }
        }
        private string recipeNameBuffer = "";
        public string RecipeNameBuffer
        {
            get { return this.recipeNameBuffer; }
            set
            {
                this.recipeNameBuffer = value;
                this.OnPropertyChanged("RecipeNameBuffer");
            }
        }
        private string recipeNoteBuffer = "";
        public string RecipeNoteBuffer
        {
            get { return this.recipeNoteBuffer; }
            set
            {
                this.recipeNoteBuffer = value;
                this.OnPropertyChanged("RecipeNoteBuffer");
            }
        }

        private string recipePartsBuffer = "";
        public string RecipePartsBuffer
        {
            get { return this.recipePartsBuffer; }
            set
            {
                this.recipePartsBuffer = value;
                this.OnPropertyChanged("RecipePartsBuffer");
            }
        }
        private string recipeArticleBuffer = "";
        public string RecipeArticleBuffer
        {
            get { return this.recipeArticleBuffer; }
            set
            {
                this.recipeArticleBuffer = value;
                this.OnPropertyChanged("RecipeArticleBuffer");
            }
        }

        public ObservableCollection<MachineRecipe> Recipes_Temp = new ObservableCollection<MachineRecipe>();
        private string filter = "";
        public string Filter
        {
            get { return this.filter; }
            set
            {
                this.filter = value;
              
                if (value != "")
                {
                    IEnumerable<MachineRecipe> enumerable = Recipes_Temp.Where(x => x.Name.Contains(filter) || x.Article.Contains(filter));
                    Recipes = Convert(enumerable);
                    SelectedRecipe = null;
                }
                else
                {
                    Recipes = Recipes_Temp;
                }

                this.OnPropertyChanged("Filter");
            }
        }

        private bool recipeIsSelected = false;
        public bool RecipeIsSelected
        {
            get { return this.recipeIsSelected; }
            set
            {
                this.recipeIsSelected = value;
                this.OnPropertyChanged("RecipeIsSelected");
            }
        }
        private MachineRecipe selectedRecipe=null;
        public MachineRecipe SelectedRecipe
        {
            get { return this.selectedRecipe; }
            set
            {
                if (!Equals(value, this.selectedRecipe))
                {
                    this.selectedRecipe = value;
                    if (selectedRecipe != null)
                    {
                        this.RecipeNameBuffer = selectedRecipe.Name;
                        this.RecipePartsBuffer = selectedRecipe.Parts;
                        this.RecipeArticleBuffer = selectedRecipe.Article;
                        this.RecipeNoteBuffer = selectedRecipe.Note;
                    }
                    else
                    {
                        this.RecipeNameBuffer = "";
                        this.RecipePartsBuffer = "";
                        this.RecipeArticleBuffer = "";
                        this.RecipeNoteBuffer = "";
                    }

                    this.OnPropertyChanged("SelectedRecipe");
                }
            }
        }

        private MachineRecipe lastLoaded = null;
        public MachineRecipe LastLoaded
        {
            get { return this.lastLoaded; }
            set
            {
                if (!Equals(value, this.lastLoaded))
                {
                    this.lastLoaded = value;

                    this.OnPropertyChanged("LastLoaded");
                }
            }
        }

        Visibility isLoading = Visibility.Hidden;
        public Visibility IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                this.isLoading = value;
                this.OnPropertyChanged("IsLoading");
            }
        }
      
        double totalH = 0;
        public double TotalH
        {
            get { return this.totalH; }
            set
            {
                this.totalH = value;
                this.OnPropertyChanged("TotalH");
            }
        }
        double totalM = 0;
        public double TotalM
        {
            get { return this.totalM; }
            set
            {
                this.totalM = value;
                this.OnPropertyChanged("TotalM");
            }
        }
        double totalS = 0;
        public double TotalS
        {
            get { return this.totalS; }
            set
            {
                this.totalS = value;
                this.OnPropertyChanged("TotalS");
            }
        }
        ObservableCollection<E_Step> items = new ObservableCollection<E_Step>();
        public ObservableCollection<E_Step> Items 
        {
            get { return this.items; }
            set
            {
                this.items = value;
                this.OnPropertyChanged("Items");
            }
        }
        #endregion

        #region - - - Commands - - -

        public ICommand LoadFile { get; set; }
        public void LoadRecipeToBufferCommandExecuted(object parameter)
        {
 
            IsLoading = Visibility.Visible;
           // Task.Run(async () => {
                Dispatcher.BeginInvoke((Action)(async () =>
                {

                     //LoadFromFileToBufferResult r1 = await RecipeClass.LoadFromFileToBufferAsync(SelectedRecipe.Name);
                     //if (r1.Result != LoadRecipeResult.Succeeded)
                     //{
                     //    new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text9", MessageBoxIcon.Error);
                     //}
                     //else 
                     //{
                         LoadFromFileToProcessResult r2 = await RecipeClass.LoadFromFileToProcessAsync(SelectedRecipe.Name);
                         LastLoaded = SelectedRecipe;
                         if (r2.Result != SendRecipeResult.Succeeded)
                         {
                             new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text9", MessageBoxIcon.Error);
                         }
                    // }
                    IsLoading = Visibility.Hidden;
                    OnCloseCommandExecuted(null);
                }));
               
           // });
        }
        public ICommand SaveFile { get; set; }
        private void SaveRecipeCommandExecuted(object parameter)
        {
            IsLoading = Visibility.Visible;
            Task.Run(async () => {
                await Dispatcher.BeginInvoke((Action)(async () =>
                {
                    if (RecipeClass.IsExistingRecipeFile(RecipeNameBuffer))
                    {
                        if (MessageBoxView.Show("@RecipeSystem.Results.OverwriteFileQuery", "@RecipeSystem.Results.SaveFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
                        {
                           await SaveRecipeAsync();
                        }
                    }
                    else
                    {
                       await SaveRecipeAsync();
                    }
                  
                    IsLoading = Visibility.Hidden;
                    OnCloseCommandExecuted(null);
                }));
            });
        }
        public ICommand CopyFile { get; set; }
        private void CopyFileExecuted(object parameter)
        {
            if (!RecipeClass.IsExistingRecipeFile(RecipeNameBuffer))
            {
                IsLoading = Visibility.Visible;
                Task.Run(async () =>
                {
                    File.Copy(RecipeClass.CurrentPath + "\\" + SelectedRecipe.Name + ".R", RecipeClass.CurrentPath + "\\" + RecipeNameBuffer + ".R", true);
                    if ((await RecipeClass.LoadFromFileToProcessAsync(RecipeNameBuffer)).Result == SendRecipeResult.Succeeded)
                    {
                        ApplicationService.SetVariableValue("Extern.Recipe.Teilenamen", RecipePartsBuffer);
                        if ((await RecipeClass.ReadProcessToBufferAsync()).Result == GetRecipeResult.Succeeded)
                        {
                            if ((await RecipeClass.SaveToFileFromBufferAsync(RecipeNameBuffer, RecipeNoteBuffer, true)).Result == SaveRecipeResult.Succeeded)
                            {
                                if ((await RecipeClass.LoadFromFileToProcessAsync(RecipeNameBuffer)).Result == SendRecipeResult.Succeeded)
                                {
                                    LastLoaded = new MachineRecipe() { Name = RecipeNameBuffer };
                                    await UpdateFileList();
                                    OnCloseCommandExecuted(null);
                                }
                                else
                                {
                                    new MessageBoxTask("@DataPicker.Text16", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);

                                }

                            }
                            else
                            {
                                new MessageBoxTask("@DataPicker.Text16", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            new MessageBoxTask("@DataPicker.Text16", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        new MessageBoxTask("@DataPicker.Text16", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
                    }
                    IsLoading = Visibility.Hidden;
                });


            }
            else
            {
                new MessageBoxTask("@DataPicker.Text15", "@RecipeSystem.IE.Text10", MessageBoxIcon.Error);
            }

        }

        public ICommand DeleteFile { get; set; }
        private void OnDeleteFileCommandExecuted(object parameter)
        {
            if (MessageBoxView.Show("@RecipeSystem.Results.DeleteFileQuery", "@RecipeSystem.Results.DeleteFile", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
            {
                IsLoading = Visibility.Visible;
                Task.Run(async () =>
                {
                    RecipeClass.DeleteFile(SelectedRecipe.Name);
                    LastLoaded = SelectedRecipe = new MachineRecipe();
                    bool result = (new LocalDBAdapter("DELETE FROM Extern WHERE Extern = '" + SelectedRecipe.Name + "';")).DB_Input();
                    await RecipeClass.SetDefaultValuesToBufferAsync();
                    await RecipeClass.WriteBufferToProcessAsync();
                    await UpdateFileList();
                    IsLoading = Visibility.Hidden;
                });
            }
        }

        public ICommand Close { get; set; }
        private void OnCloseCommandExecuted(object parameter)
        {
            Filter = "";
            Dispatcher.BeginInvoke((Action)(() =>
            {
                ApplicationService.SetView("DialogRegion", "EmptyView");
            }));
        }

        #endregion

        public void OnSelectedFileChanged(object sender, PropertyChangedEventArgs e)
        {
            if ("SelectedRecipe".Equals(e.PropertyName))
            {
                this.RecipeIsSelected = this.SelectedRecipe != null;
            }
        }
        #region - - - Methods - - -

        public async Task UpdateFileList()
        {
            IsLoading = Visibility.Visible;
            ObservableCollection<MachineRecipe> T_recipes = new ObservableCollection<MachineRecipe>();
            await Task.Run(() =>
            {
                foreach (string rn in RecipeClass.FileNames)
                {
                    IRecipeFile recipe = RecipeClass.GetRecipeFile(rn);
                    DataTable DT = (new LocalDBAdapter("SELECT * " +
                                                       "FROM Extern " +
                                                       "WHERE Extern='" + rn + "';")).DB_Output();
                    string a = "";
                    if (DT.Rows.Count > 0)
                    {
                        a = (string)DT.Rows[0]["Barcode"];
                    }


                    T_recipes.Add(new MachineRecipe
                    {
                        Name = recipe.FileName,
                        Parts = recipe.GetValues()["Extern.Recipe.Teilenamen"] != null ? recipe.GetValues()["Extern.Recipe.Teilenamen"].ToString() : "",
                        Article = a,//recipe.GetValues()["Extern.Recipe.Artikelnummer"].ToString(),
                        Note = recipe.Description,
                        LastChanged = recipe.TimeOfLastChange,
                        User = recipe.WhoSavedRecipe()
                    });
                }
            });
            Recipes = T_recipes;
            if(LastLoaded!=null)
                if (RecipeClass.IsExistingRecipeFile(LastLoaded.Name))
                    LastLoaded = SelectedRecipe = Recipes.Where(r => r.Name == LastLoaded.Name).First();
            IsLoading = Visibility.Hidden;
          
        }

        async Task SaveRecipeAsync() 
        {
            ApplicationService.SetVariableValue("Extern.Recipe.Teilenamen", RecipePartsBuffer);
            //ApplicationService.SetVariableValue("Extern.Recipe.Artikelnummer", RecipeArticleBuffer);
            ReadProcessToBufferResult r1 = await RecipeClass.ReadProcessToBufferAsync();
            if (r1.Result != GetRecipeResult.Succeeded)
            {
                new MessageBoxTask("@RecipeSystem.Results.SaveError", "@MessageBox.Text1", MessageBoxIcon.Error);
            }
            else 
            {
                SaveToFileFromBufferResult r2 = await RecipeClass.SaveToFileFromBufferAsync(RecipeNameBuffer, RecipeNoteBuffer, true);
                LastLoaded = SelectedRecipe;
                if (r2.Result != SaveRecipeResult.Succeeded)
                {
                    new MessageBoxTask("@RecipeSystem.Results.SaveError", "@MessageBox.Text1", MessageBoxIcon.Error);
                }
                else
                {
                    LastLoaded.Name = RecipeNameBuffer;
                    await UpdateFileList();
                }
            }
        }

        public void CalculateTotalTime() 
        {
            double tempH = 0;
            double tempM = 0;
            double tempS = 0;
            // SV.Items
            foreach (E_Step rs in Items) 
            {
                tempH = tempH + rs.sth.Value;
                tempM = tempM + rs.stm.Value;
                tempS = tempS + rs.sts.Value;
            }
          

            TotalH = tempH;
            TotalM = tempM;
            TotalS = tempS;
        }

        private void FillTheGrid()
        {
            Task.Run(async () => {
                for (int i = 1; i <= 6; i++)
                {
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Items.Add(new E_Step { StepNumber = i });
                    });
                    await Task.Delay(200);
                }
            });
        }

        public ObservableCollection<MachineRecipe> Convert(IEnumerable original)
        {
            return new ObservableCollection<MachineRecipe>(original.Cast<MachineRecipe>());
        }

        #endregion
    }


}