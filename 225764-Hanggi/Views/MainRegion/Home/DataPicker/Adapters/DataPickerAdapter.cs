using HMI.Module;
using HMI.UserControls;
using HMI.Views.MessageBoxRegion;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.DataAccess;
using VisiWin.Recipe;

namespace HMI.Views.MainRegion
{

    [ExportAdapter("DataPickerAdapter")]
    public class DataPickerAdapter : AdapterBase
    {

        
        public DataPickerAdapter()
        {
            ShowMRList = new ActionCommand(ShowMRListCommandExecuted);
            ShowHistory = new ActionCommand(ShowHistoryExecuted);
            ShowEHistory = new ActionCommand(ShowEHistoryExecuted);
            LoadRecipe = new ActionCommand(LoadRecipeCommandExecuted);
            SelectMachineRecipe = new ActionCommand(SelectMachineRecipeCommandExecuted);
            CloseRecipeSelectorCommand = new ActionCommand(OnCloseRecipeSelectorCommandExecuted);
            CloseDataPickerCommand = new ActionCommand(OnCloseDataPickerCommandExecuted);
            ShowExternRecipe = new ActionCommand(ShowExternRecipeExecuted);
            FillTheGrid();
        }



        #region - - - Properties - - -
       
        readonly IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
        readonly IRecipeClass RecipeClassExtern = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Extern");
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

        private MachineRecipe selectedRecipe = null;
        public MachineRecipe SelectedRecipe
        {
            get { return this.selectedRecipe; }
            set
            {
                if (!Equals(value, this.selectedRecipe))
                {
                    this.selectedRecipe = value;
                    this.OnPropertyChanged("SelectedRecipe");
                }
            }
        }

        public ObservableCollection<MV_ErgospinS> Ergospins = new ObservableCollection<MV_ErgospinS>();
        private bool isLoadingNotActive = true;
        public bool IsLoadingNotActive
        {
            get { return isLoadingNotActive; }
            set
            {
                this.isLoadingNotActive = value;
                this.OnPropertyChanged("IsLoadingNotActive");
            }
        }
        private string recipeName = "";
        public string RecipeName
        {
            get { return this.recipeName; }
            set
            {
                this.recipeName = value;
                this.OnPropertyChanged("RecipeName");
            }
        }
        private string recipeParts = "";
        public string RecipeParts
        {
            get { return this.recipeParts; }
            set
            {
                this.recipeParts = value;
                this.OnPropertyChanged("RecipeParts");
            }
        }
        private string recipeNote = "";
        public string RecipeNote
        {
            get { return this.recipeNote; }
            set
            {
                this.recipeNote = value;
                this.OnPropertyChanged("RecipeNote");
            }
        }
        private string recipeBarcode = "";
        public string RecipeBarcode
        {
            get { return this.recipeBarcode; }
            set
            {
                this.recipeBarcode = value;
                SetRecipe();
                this.OnPropertyChanged("RecipeBarcode");
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

        Visibility isHistory = Visibility.Collapsed;
        public Visibility IsHistory
        {
            get
            {
                return isHistory;
            }
            set
            {
                this.isHistory = value;
                this.OnPropertyChanged("IsHistory");
            }
        }

        Visibility isEHistory = Visibility.Collapsed;
        public Visibility IsEHistory
        {
            get
            {
                return isEHistory;
            }
            set
            {
                this.isEHistory = value;
                this.OnPropertyChanged("IsEHistory");
            }
        }

        Visibility isExternRecipe = Visibility.Collapsed;
        public Visibility IsExternRecipe
        {
            get
            {
                return isExternRecipe;
            }
            set
            {
                this.isExternRecipe = value;
                this.OnPropertyChanged("IsExternRecipe");
            }
        }

        private string externRecipe = "";
        public string ExternRecipe
        {
            get { return this.externRecipe; }
            set
            {
                this.externRecipe = value;
                this.OnPropertyChanged("ExternRecipe");
            }
        }

        #endregion

        #region - - - Commands - - -


        public ICommand SelectMachineRecipe { get; set; }
        private void SelectMachineRecipeCommandExecuted(object parameter)
        {
            if (SelectedRecipe != null) 
            {
                if (SelectedRecipe.Article.Length > 0)
                {
                    RecipeBarcode = SelectedRecipe.Article;
                }
                else 
                {
                    RecipeName = SelectedRecipe.Name;
                    RecipeParts = SelectedRecipe.Parts;
                    RecipeNote = SelectedRecipe.Note;
                    recipeBarcode = SelectedRecipe.Article;
                    this.OnPropertyChanged("RecipeBarcode");
                    IsExternRecipe = Visibility.Collapsed;
                    ExternRecipe = "";
                    if (RecipeClass.GetRecipeFile(SelectedRecipe.Name).GetValues()["Ergospin.Recipe.Historie"].ToString().Length > 0)
                    {
                        IsHistory = Visibility.Visible;
                    }
                    else
                    {
                        IsHistory = Visibility.Collapsed;
                    }
                }
                
                OnCloseRecipeSelectorCommandExecuted(null);
            }
        }

        public ICommand CloseRecipeSelectorCommand { get; set; }
        private void OnCloseRecipeSelectorCommandExecuted(object parameter)
        {
            Filter = "";
            ApplicationService.SetView("MessageBoxRegion", "EmptyView");
        }

        public ICommand CloseDataPickerCommand { get; set; }
        private void OnCloseDataPickerCommandExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion", "EmptyView");
        }
        public ICommand ShowMRList { get; set; }

        private void ShowMRListCommandExecuted(object parameter)
        {
            ApplicationService.SetView("MessageBoxRegion", "DPR_Selector");
        }
        public ICommand LoadRecipe { get; set; }

        private void LoadRecipeCommandExecuted(object parameter)
        {
            
            if (RecipeClass.IsExistingRecipeFile(RecipeName))
            {
                List<MV_ErgospinS> ErgoList = Ergospins.Where(x => x.selected.IsChecked == true).ToList();
                
                if (ErgoList.Count > 0)
                {
                    if (MessageBoxView.Show("@RecipeSystem.Results.Text10", "@RecipeSystem.Results.Text9", MessageBoxButton.YesNo, icon: MessageBoxIcon.Question) == MessageBoxResult.Yes)
                    {
                        IsLoading = Visibility.Visible;
                        IsLoadingNotActive = false;

                        Task.Run(async () =>
                        {
                          
                            Dictionary<string, object> toBeLoaded = RecipeClass.GetRecipeFile(RecipeName).GetValues();

                            foreach (MV_ErgospinS es in ErgoList)
                            {
                                IRecipeClass TempClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass(es.ErgospinName);
                                string[] variables = TempClass.GetVariableNames().ToArray();



                                for (int i = 0; i < variables.Length; i++)
                                {
                                    if (variables[i].Contains("Ergospin.Station.Rez_Name#STRING40"))
                                    {
                                        TempClass.SetValue(es.ErgospinName + ".PLC.Blocks.DB PC.Ergospin.Station.Rez_Name#STRING40", RecipeName);
                                    }
                                    else
                                    {
                                        TempClass.SetValue
                                        (
                                            variables[i],
                                            toBeLoaded.Where(x => x.Key == variables[i].Replace(es.ErgospinName + ".PLC.Blocks.DB PC.Ergospin.Station", "Ergospin.Recipe")).ToArray()[0].Value
                                        );
                                    }
                                }
                              
                                WriteBufferToProcessResult r = await TempClass.WriteBufferToProcessAsync();
                                    
                                await Dispatcher.InvokeAsync(delegate
                                {
                                    if (r.Result == SetRecipeResult.Succeeded)
                                    {
                                        es.IsRecipeLoaded = true;
                                        ApplicationService.SetVariableValue(es.ErgospinName + ".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Loaded", true);
                                    }
                                    else
                                    {
                                        es.IsRecipeLoaded = false;
                                        ApplicationService.SetVariableValue(es.ErgospinName + ".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Not loaded", true);
                                    }
                                });
                            }
                            await Dispatcher.InvokeAsync(delegate
                            {
                                IsLoadingNotActive = true;
                                IsLoading = Visibility.Hidden;
                            });
                        });
                    }
                }
                else
                {
                    new MessageBoxTask("@RecipeSystem.Results.Text11", "@RecipeSystem.Results.Text9", MessageBoxIcon.Warning);
                }
            }
            else
            {
                new MessageBoxTask("@RecipeSystem.Results.Text7", "@RecipeSystem.Results.Text9", MessageBoxIcon.Warning);
            }
            
        }

        public ICommand ShowExternRecipe { get; set; }

        private void ShowExternRecipeExecuted(object parameter)
        {
            ApplicationService.SetView("DialogRegion", "EmptyView");
            IRegionService iRS = ApplicationService.GetService<IRegionService>();
            AppbarView abv = (AppbarView)iRS.GetView("AppbarView");
            abv.externR.IsChecked = true;
            ApplicationService.SetView("MainRegion", "Extern_Main", new ExternData {MR_Name = ExternRecipe });

        }

        public ICommand ShowHistory { get; set; }

        private void ShowHistoryExecuted(object parameter)
        {
            ApplicationService.SetView("MessageBoxRegion", "DPR_History", RecipeName);
        }

        public ICommand ShowEHistory { get; set; }

        private void ShowEHistoryExecuted(object parameter)
        {
            ApplicationService.SetView("MessageBoxRegion", "DPR_EHistory", ExternRecipe);
        }

        #endregion

       

        #region - - - Methods - - -



        private void FillTheGrid()
        {
            IRegionService iRS = ApplicationService.GetService<IRegionService>();
            MO_DataPicker MO_DP = (MO_DataPicker)iRS.GetView("MO_DataPicker");

            MV_ErgospinS Ergospin;

            Task.Run(async () => {
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "DarkBlue"
                    };
                    Grid.SetRow(Ergospin, 0);
                    Grid.SetColumn(Ergospin, 0);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_1_8)MO_DP.pn_dp.PanoramaRegions[0].Content).ergospins.Children.Add(Ergospin);
                });
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "YellowGreen"
                    };
                    Grid.SetRow(Ergospin, 0);
                    Grid.SetColumn(Ergospin, 1);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_1_8)MO_DP.pn_dp.PanoramaRegions[0].Content).ergospins.Children.Add(Ergospin);
                });
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "MelonYellow"
                    };
                    Grid.SetRow(Ergospin, 0);
                    Grid.SetColumn(Ergospin, 2);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_1_8)MO_DP.pn_dp.PanoramaRegions[0].Content).ergospins.Children.Add(Ergospin);
                });
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "TurquoiseGreen"
                    };
                    Grid.SetRow(Ergospin, 0);
                    Grid.SetColumn(Ergospin, 3);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_1_8)MO_DP.pn_dp.PanoramaRegions[0].Content).ergospins.Children.Add(Ergospin);
                });
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "WaterBlue"
                    };
                    Grid.SetRow(Ergospin, 1);
                    Grid.SetColumn(Ergospin, 0);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_1_8)MO_DP.pn_dp.PanoramaRegions[0].Content).ergospins.Children.Add(Ergospin);
                });
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "MarineBlue"
                    };
                    Grid.SetRow(Ergospin, 1);
                    Grid.SetColumn(Ergospin, 1);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_1_8)MO_DP.pn_dp.PanoramaRegions[0].Content).ergospins.Children.Add(Ergospin);
                });
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "LightBlue"
                    };
                    Grid.SetRow(Ergospin, 1);
                    Grid.SetColumn(Ergospin, 2);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_1_8)MO_DP.pn_dp.PanoramaRegions[0].Content).ergospins.Children.Add(Ergospin);
                });
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "Pink"
                    };
                    Grid.SetRow(Ergospin, 1);
                    Grid.SetColumn(Ergospin, 3);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_1_8)MO_DP.pn_dp.PanoramaRegions[0].Content).ergospins.Children.Add(Ergospin);
                });
               
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "Orange"
                    };
                    Grid.SetRow(Ergospin, 0);
                    Grid.SetColumn(Ergospin, 0);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_9_16)MO_DP.pn_dp.PanoramaRegions[1].Content).ergospins.Children.Add(Ergospin);
                });
                
                
                await Task.Delay(500);
                await Dispatcher.InvokeAsync(delegate
                {
                    Ergospin = new MV_ErgospinS
                    {
                        ErgospinName = "RubinRed"
                    };
                    Grid.SetRow(Ergospin, 0);
                    Grid.SetColumn(Ergospin, 1);
                    Ergospins.Add(Ergospin);
                    ((HMI.DialogRegion.MO.Views.MO_DP_Ergospins_9_16)MO_DP.pn_dp.PanoramaRegions[1].Content).ergospins.Children.Add(Ergospin);
                });
                
            });

        }

        public async Task UpdateFileList()
        {
            IsLoading = Visibility.Visible;
            ObservableCollection<MachineRecipe> T_recipes = new ObservableCollection<MachineRecipe>();
            string temp= RecipeName;
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
                        Parts = recipe.GetValues()["Ergospin.Recipe.Teilenamen"] != null ? recipe.GetValues()["Ergospin.Recipe.Teilenamen"].ToString() : "",
                        Article = a,//recipe.GetValues()["Ergospin.Recipe.Artikelnummer"].ToString(),
                        Note = recipe.Description,
                        LastChanged = recipe.TimeOfLastChange,
                        User = recipe.WhoSavedRecipe()
                    });
                }
            });
            Recipes = T_recipes;
            if (RecipeClass.IsExistingRecipeFile(temp.ToString()))
                SelectedRecipe = Recipes.Where(r => r.Name == temp.ToString()).First();
           // await Task.Delay(500);
            IsLoading = Visibility.Hidden;

        }

        public void SetRecipe() 
        {
            Task.Run(() => 
            {
                DataTable DT = (new LocalDBAdapter("SELECT MR " +
                                                   "FROM Barcodes " +
                                                   "WHERE Barcode='" + RecipeBarcode + "';")).DB_Output();
                if (DT.Rows.Count > 0)
                {
                    string recipe = (string)DT.Rows[0]["MR"];
                    if (RecipeClass.IsExistingRecipeFile(recipe))
                    {

                        IRecipeFile temp = RecipeClass.GetRecipeFile(recipe);
                        //SelectedRecipe = null;
                        RecipeName = temp.FileName;
                        RecipeNote = temp.Description;
                        RecipeParts = temp.GetValues()["Ergospin.Recipe.Teilenamen"].ToString();

                        if (RecipeClass.GetRecipeFile(RecipeName).GetValues()["Ergospin.Recipe.Historie"].ToString().Length > 0)
                        {
                            IsHistory = Visibility.Visible;
                        }
                        else
                        {
                            IsHistory = Visibility.Collapsed;
                        }

                        if (Recipes.Count > 0)
                        {
                            SelectedRecipe = Recipes.Where(x => x.Name == recipe).ToArray()[0];
                        }
                        else
                        {
                            IsHistory = Visibility.Collapsed;
                            RecipeName = "";
                            RecipeParts = "";
                            RecipeNote = "";
                            new MessageBoxTask("@DataPicker.Text13", "@DataPicker.Text9", MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    IsHistory = Visibility.Collapsed;
                    RecipeName = "";
                    RecipeParts = "";
                    RecipeNote = "";
                    new MessageBoxTask("@DataPicker.Text11", "@DataPicker.Text9", MessageBoxIcon.Warning);

                }

                DT = (new LocalDBAdapter("SELECT Extern " +
                                         "FROM Extern " +
                                         "WHERE Barcode='" + RecipeBarcode + "';")).DB_Output();

                if (DT.Rows.Count > 0)
                {
                    IsExternRecipe = Visibility.Visible;
                    string recipe = (string)DT.Rows[0]["Extern"];
                    if (RecipeClassExtern.IsExistingRecipeFile(recipe))
                    {
                        ExternRecipe = recipe;
                        if (RecipeClassExtern.GetRecipeFile(ExternRecipe).GetValues()["Extern.Recipe.Historie"].ToString().Length > 0)
                        {
                            IsEHistory = Visibility.Visible;
                        }
                        else
                        {
                            IsEHistory = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        IsEHistory = Visibility.Collapsed;
                        ExternRecipe = "";
                        new MessageBoxTask("@DataPicker.Text14", "@DataPicker.Text9", MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    IsExternRecipe = Visibility.Collapsed;
                    ExternRecipe = "";
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