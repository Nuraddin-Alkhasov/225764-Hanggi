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

    [ExportAdapter("RecipeAdapter")]
    public class RecipeAdapter : AdapterBase
    {
        //readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        //readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        //IVariable LE;
        //readonly string isEditable = "";
        public RecipeAdapter()
        {
            this.LoadFile = new ActionCommand(this.LoadRecipeToBufferCommandExecuted);
            this.SaveFile = new ActionCommand(this.SaveRecipeCommandExecuted);
            this.CopyFile = new ActionCommand(this.CopyFileExecuted);
            this.DeleteFile = new ActionCommand(this.OnDeleteFileCommandExecuted);
            this.Close = new ActionCommand(this.OnCloseCommandExecuted);
            this.CopyStep = new ActionCommand(this.CopyStepCommandExecuted);
            this.PropertyChanged += this.OnSelectedFileChanged;
            FillTheGrid();
        }



        #region - - - Properties - - -
        IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
        private ObservableCollection<MachineRecipe> recipes = new ObservableCollection<MachineRecipe>();
        public ObservableCollection<MachineRecipe> Recipes
        {
            get { return this.recipes; }
            set
            {
                if (!Equals(value, this.recipes))
                {
                    this.recipes = value;
                    if(Filter=="")
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
                    IEnumerable<MachineRecipe> enumerable = Recipes_Temp.Where(x => x.Name.Contains(Filter) || x.Article.Contains(Filter));
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
        State from = null;
        public State From
        {
            get { return this.from; }
            set
            {
                this.from = value;
                this.OnPropertyChanged("From");
            }
        }
        State to = null;
        public State To
        {
            get { return this.to; }
            set
            {
                this.to = value;
                this.OnPropertyChanged("From");
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
        ObservableCollection<R_Step> items = new ObservableCollection<R_Step>();
        public ObservableCollection<R_Step> Items 
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
                     //await RecipeClass.SetDefaultValuesToBufferAsync();
                     //await RecipeClass.WriteBufferToProcessAsync();
                         LoadFromFileToProcessResult r = await RecipeClass.LoadFromFileToProcessAsync(SelectedRecipe.Name);
                         LastLoaded = SelectedRecipe;
                         if (r.Result != SendRecipeResult.Succeeded)
                         {
                             new MessageBoxTask("@RecipeSystem.Results.LoadError", "@RecipeSystem.Results.Text9", MessageBoxIcon.Error);
                         }
                    // }
                     IsLoading = Visibility.Hidden;
                     OnCloseCommandExecuted(null);
                 }));
                //await Task.Delay(500);
               // await Dispatcher.BeginInvoke((Action)(() =>
                //{
                   
                //}));
          // });
        }
        public ICommand SaveFile { get; set; }
        private void SaveRecipeCommandExecuted(object parameter)
        {
            IsLoading = Visibility.Visible;
           // Task.Run(async () => {
                Dispatcher.BeginInvoke((Action)(async () =>
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
           // });
        }
        public ICommand CopyFile { get; set; }
        private void CopyFileExecuted(object parameter)
        {
            if (!RecipeClass.IsExistingRecipeFile(RecipeNameBuffer))
            {
                IsLoading = Visibility.Visible;
                Task.Run(async () =>
                {
                    File.Copy(RecipeClass.CurrentPath + "\\" + SelectedRecipe.Name +".R", RecipeClass.CurrentPath + "\\" + RecipeNameBuffer + ".R", true);
                    if ((await RecipeClass.LoadFromFileToProcessAsync(RecipeNameBuffer)).Result == SendRecipeResult.Succeeded)
                    {
                        ApplicationService.SetVariableValue("Ergospin.Recipe.Teilenamen", RecipePartsBuffer);
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
                    bool result = (new LocalDBAdapter("DELETE FROM Barcodes WHERE MR = '" + SelectedRecipe.Name + "';")).DB_Input();
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

        public ICommand CopyStep { get; set; }
        private void CopyStepCommandExecuted(object parameter)
        {
            if (From != null && To != null)
            {
                string _from = From.Value;
                string _to = To.Value;
                Task.Run(async () =>
                {
                    ReadProcessToBufferResult r1 = await RecipeClass.ReadProcessToBufferAsync();
                    if (r1.Result != GetRecipeResult.Succeeded)
                    {
                        new MessageBoxTask("@RecipeSystem.Results.Text8", "@MessageBox.Text1", MessageBoxIcon.Error);
                    }
                    else 
                    {
                        string[] fromVariables =
                       {
                        "Ergospin.Recipe.Step[" + _from + "].Kommentar#STRING113",
                        "Ergospin.Recipe.Step[" + _from + "].Step_Time.Hour",
                        "Ergospin.Recipe.Step[" + _from + "].Step_Time.Minute",
                        "Ergospin.Recipe.Step[" + _from + "].Step_Time.Second",
                        "Ergospin.Recipe.Step[" + _from + "].Kontrolle_nach_Step",
                        "Ergospin.Recipe.Step[" + _from + "].Rotor_direction",
                        "Ergospin.Recipe.Step[" + _from + "].Rotor_RPM",
                        "Ergospin.Recipe.Step[" + _from + "].Rotor_Interval_Time.Hour",
                        "Ergospin.Recipe.Step[" + _from + "].Rotor_Interval_Time.Minute",
                        "Ergospin.Recipe.Step[" + _from + "].Rotor_Interval_Time.Second",
                        "Ergospin.Recipe.Step[" + _from + "].Planet_direction",
                        "Ergospin.Recipe.Step[" + _from + "].Planet_RPM",
                        "Ergospin.Recipe.Step[" + _from + "].Swing_Mode",
                        "Ergospin.Recipe.Step[" + _from + "].Swing_to",
                        "Ergospin.Recipe.Step[" + _from + "].Swing_change_between",
                        "Ergospin.Recipe.Step[" + _from + "].Swing_RPM",
                        "Ergospin.Recipe.Step[" + _from + "].Swing_Interval_Time.Hour",
                        "Ergospin.Recipe.Step[" + _from + "].Swing_Interval_Time.Minute",
                        "Ergospin.Recipe.Step[" + _from + "].Swing_Interval_Time.Second"
                       
                    };
                        string[] toVariables =
                        {
                        "Ergospin.Recipe.Step[" + _to + "].Kommentar#STRING113",
                        "Ergospin.Recipe.Step[" + _to + "].Step_Time.Hour",
                        "Ergospin.Recipe.Step[" + _to + "].Step_Time.Minute",
                        "Ergospin.Recipe.Step[" + _to + "].Step_Time.Second",
                        "Ergospin.Recipe.Step[" + _to + "].Kontrolle_nach_Step",
                        "Ergospin.Recipe.Step[" + _to + "].Rotor_direction",
                        "Ergospin.Recipe.Step[" + _to + "].Rotor_RPM",
                        "Ergospin.Recipe.Step[" + _to + "].Rotor_Interval_Time.Hour",
                        "Ergospin.Recipe.Step[" + _to + "].Rotor_Interval_Time.Minute",
                        "Ergospin.Recipe.Step[" + _to + "].Rotor_Interval_Time.Second",
                        "Ergospin.Recipe.Step[" + _to + "].Planet_direction",
                        "Ergospin.Recipe.Step[" + _to + "].Planet_RPM",
                        "Ergospin.Recipe.Step[" + _to + "].Swing_Mode",
                        "Ergospin.Recipe.Step[" + _to + "].Swing_to",
                        "Ergospin.Recipe.Step[" + _to + "].Swing_change_between",
                        "Ergospin.Recipe.Step[" + _to + "].Swing_RPM",
                        "Ergospin.Recipe.Step[" + _to + "].Swing_Interval_Time.Hour",
                        "Ergospin.Recipe.Step[" + _to + "].Swing_Interval_Time.Minute",
                        "Ergospin.Recipe.Step[" + _to + "].Swing_Interval_Time.Second"
                    };
                        object[] fromValues;
                        RecipeClass.GetValues(fromVariables, out fromValues);
                        RecipeClass.SetValues(toVariables, fromValues);

                        WriteBufferToProcessResult r2 = await RecipeClass.WriteBufferToProcessAsync();
                        if (r2.Result != SetRecipeResult.Succeeded)
                        {
                            new MessageBoxTask("@RecipeSystem.Results.Text8", "@MessageBox.Text1", MessageBoxIcon.Error);
                        }
                    }
                   
                });
            }
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
                                              "FROM Barcodes " +
                                              "WHERE MR='" + rn + "';")).DB_Output();
                    string a = "";
                    if (DT.Rows.Count > 0)
                    {
                        a = (string)DT.Rows[0]["Barcode"];
                    }

                    T_recipes.Add(new MachineRecipe
                    {
                        Name = recipe.FileName,
                        Parts = recipe.GetValues()["Ergospin.Recipe.Teilenamen"] != null ? recipe.GetValues()["Ergospin.Recipe.Teilenamen"].ToString() :"",
                        Article = a,//recipe.GetValues()["Ergospin.Recipe.Artikelnummer"].ToString(),
                        Note = recipe.Description,
                        LastChanged = recipe.TimeOfLastChange,
                        User = recipe.WhoSavedRecipe()
                    });
                }
            });
            Recipes = T_recipes;
            if (LastLoaded != null)
                if (RecipeClass.IsExistingRecipeFile(LastLoaded.Name))
                    LastLoaded = SelectedRecipe = Recipes.Where(r => r.Name == LastLoaded.Name).First();
            IsLoading = Visibility.Hidden;

        }

        async Task SaveRecipeAsync() 
        {
            ApplicationService.SetVariableValue("Ergospin.Recipe.Teilenamen", RecipePartsBuffer);
            //ApplicationService.SetVariableValue("Ergospin.Recipe.Artikelnummer", RecipeArticleBuffer);
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
                    if (LastLoaded != null)
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
            foreach (R_Step rs in Items) 
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
                for (int i = 1; i <= 10; i++)
                {
                    await Dispatcher.InvokeAsync(delegate
                    {
                        Items.Add(new R_Step { StepNumber = i });
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