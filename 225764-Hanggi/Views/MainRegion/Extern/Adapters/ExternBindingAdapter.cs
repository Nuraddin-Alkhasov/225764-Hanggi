
using HMI.Module;
using HMI.Views.MessageBoxRegion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Recipe;

namespace HMI.Views.MainRegion
    {
    class ExternBindingAdapter : AdapterBase
    {
        Visibility _DialogVisible;
        public ExternBindingAdapter()
        {
            NewCommand = new ActionCommand(NewCommandExecuted);
            EditCommand = new ActionCommand(EditCommandExecuted);
            CloseDialogCommand = new ActionCommand(CloseDialogCommandExecuted);
            CloseDialogViewCommand = new ActionCommand(CloseDialogViewCommandExecuted);

            SelectMachineRecipeCommand = new ActionCommand(SelectMachineRecipeCommandExecuted);
            CloseRecipeSelectViewCommand = new ActionCommand(CloseRecipeSelectViewCommandExecuted);
            ShowMRList = new ActionCommand(ShowMRListCommandExecuted);
            SaveCommand = new ActionCommand(SaveCommandExecuted);
            DeleteCommand = new ActionCommand(DeleteCommandExecuted);
            _DialogVisible = Visibility.Hidden;
        }

        #region - - - Properties - - -
        IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Extern");
        public ObservableCollection<MachineRecipe> Recipes_Temp = new ObservableCollection<MachineRecipe>();
        private string recipeFilter = "";
        public string RecipeFilter
        {
            get { return this.recipeFilter; }
            set
            {
                this.recipeFilter = value;

                if (value != "")
                {
                    IEnumerable<MachineRecipe> enumerable = Recipes_Temp.Where(x => x.Name.Contains(RecipeFilter));
                    Recipes = ConvertToRecipeCollection(enumerable);
                    SelectedRecipe = null;
                }
                else
                {
                    Recipes = Recipes_Temp;
                }

                this.OnPropertyChanged("Filter");
            }
        }

        public ObservableCollection<Barcode> BarcodeList_Temp = new ObservableCollection<Barcode>();
        private string barcodeFilter = "";
        public string BarcodeFilter
        {
            get { return this.barcodeFilter; }
            set
            {
                this.barcodeFilter = value;

                if (value != "")
                {
                    IEnumerable<Barcode> enumerable = BarcodeList_Temp.Where(x => x.MR_Name.Contains(BarcodeFilter) || x.BC.Contains(BarcodeFilter));
                    BarcodeList = ConvertToBarcodeCollection(enumerable);
                    SelectedBarcode = null;
                }
                else
                {
                    BarcodeList = BarcodeList_Temp;
                }

                this.OnPropertyChanged("BarcodeFilter");
            }
        }
        ObservableCollection<Barcode> barcodeList = new ObservableCollection<Barcode>();
        public ObservableCollection<Barcode> BarcodeList
        {
            get { return this.barcodeList; }
            set
            {
                this.barcodeList = value;
                if (BarcodeFilter == "")
                    BarcodeList_Temp = value;
                this.OnPropertyChanged("BarcodeList");
            }
        }

        ObservableCollection<MachineRecipe> recipes = new ObservableCollection<MachineRecipe>();
        public ObservableCollection<MachineRecipe> Recipes
        {
            get { return this.recipes; }
            set
            {
                this.recipes = value;
                if (RecipeFilter == "")
                    Recipes_Temp = value;
                this.OnPropertyChanged("Recipes");
            }
        }

        MachineRecipe selectedRecipe;
        public MachineRecipe SelectedRecipe
        {
            get { return this.selectedRecipe; }
            set
            {
                this.selectedRecipe = value;
                this.OnPropertyChanged("SelectedRecipe");
            }
        }

        Barcode selectedBarcode = new Barcode();
        public Barcode SelectedBarcode
        {
            get { return this.selectedBarcode; }
            set
            {
                if (value != null) { IsBCToMRSelected = true; }
                else { IsBCToMRSelected = false; }
                this.selectedBarcode = value;
                this.OnPropertyChanged("SelectedBarcode");
            }
        }
        Barcode selectedBarcodeBuffer;
        public Barcode SelectedBarcodeBuffer
        {
            get { return this.selectedBarcodeBuffer; }
            set
            {
                this.selectedBarcodeBuffer = value;
                this.OnPropertyChanged("SelectedBarcodeBuffer");
            }
        }

        bool isBCToMRSelected;
        public bool IsBCToMRSelected
        {
            get { return this.isBCToMRSelected; }
            set
            {
                this.isBCToMRSelected = value;
                this.OnPropertyChanged("IsBCToMRSelected");
            }
        }
        public Visibility DialogVisible
        {
            get { return this._DialogVisible; }
            set
            {
                if (!Equals(value, this._DialogVisible))
                {
                    this._DialogVisible = value;
                    this.OnPropertyChanged("DialogVisible");
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

        #endregion

        #region - - - Commands - - -

        public ICommand NewCommand { get; set; }
        private void NewCommandExecuted(object parameter)
        {
            if (DialogVisible == Visibility.Hidden) 
            {
                Task T = Task.Run(() =>
                {
                    bool result = (new LocalDBAdapter("INSERT INTO Extern (Barcode, Extern) VALUES ('No Barcode','No Extern')")).DB_Input();
                    UpdateBarcodeList();
                });
            }
               
        }

        public ICommand EditCommand { get; set; }

        private void EditCommandExecuted(object parameter)
        {
            if (DialogVisible == Visibility.Hidden)
            {
                DialogVisible = Visibility.Visible;
                SelectedBarcodeBuffer = new Barcode()
                {
                    Id = SelectedBarcode.Id,
                    BC = SelectedBarcode.BC,
                    MR_Name = SelectedBarcode.MR_Name
                };
            }
              
        }

        public ICommand SaveCommand { get; set; }

        private void SaveCommandExecuted(object parameter)
        {
            if (this.SelectedBarcode != null)
            {
                Task T = Task.Run(() =>
                {
                    if (SelectedBarcode != null)
                    {
                        if (BarcodeList.Where(x => x.Id != SelectedBarcodeBuffer.Id).Where(x => x.MR_Name == SelectedBarcodeBuffer.MR_Name).ToArray().Length > 0)
                        {
                            new MessageBoxTask("@Datapicker.Text15", "@Datapicker.Text7", MessageBoxIcon.Exclamation);
                        }
                        else if (BarcodeList.Where(x => x.Id != SelectedBarcodeBuffer.Id).Where(x => x.BC == SelectedBarcodeBuffer.BC).ToArray().Length > 0)
                        {
                            new MessageBoxTask("@Datapicker.Text10", "@Datapicker.Text7", MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            bool result = (new LocalDBAdapter("UPDATE Extern " +
                                                                "SET Barcode ='" + SelectedBarcodeBuffer.BC + "', Extern = '" + SelectedBarcodeBuffer.MR_Name + "' " +
                                                                "WHERE Id = " + SelectedBarcodeBuffer.Id + ";")).DB_Input();
                            DialogVisible = Visibility.Hidden;
                            UpdateBarcodeList();

                        }
                    }
                });
            }
        }

        public ICommand DeleteCommand { get; set; }

        private void DeleteCommandExecuted(object parameter)
        {
            if (this.SelectedBarcode != null && DialogVisible == Visibility.Hidden)
            {
                Task T = Task.Run(() =>
                {
                    bool result = (new LocalDBAdapter("DELETE FROM Extern WHERE Id = " + SelectedBarcode.Id + ";")).DB_Input();
                    UpdateBarcodeList();
                });
            }
        }

        public ICommand SelectMachineRecipeCommand { get; set; }

        private void SelectMachineRecipeCommandExecuted(object parameter)
        {
            SelectedBarcodeBuffer.MR_Name = SelectedRecipe.Name;
            this.OnPropertyChanged("SelectedBarcodeBuffer");
            CloseRecipeSelectViewCommandExecuted(null);
        }

        public ICommand CloseDialogCommand { get; set; }

        private void CloseDialogCommandExecuted(object parameter)
        {
            DialogVisible = Visibility.Hidden;
        }

        public ICommand CloseDialogViewCommand { get; set; }

        private void CloseDialogViewCommandExecuted(object parameter)
        {
            BarcodeFilter = "";
            DialogVisible = Visibility.Hidden;
            ApplicationService.SetView("DialogRegion", "EmptyView");
        }
        public ICommand CloseRecipeSelectViewCommand { get; set; }

        private void CloseRecipeSelectViewCommandExecuted(object parameter)
        {
            RecipeFilter = "";
            ApplicationService.SetView("MessageBoxRegion", "EmptyView");
        }
        public ICommand ShowMRList { get; set; }

        private void ShowMRListCommandExecuted(object parameter)
        {
            ApplicationService.SetView("MessageBoxRegion", "Extern_Selector");
        }

        #endregion

        #region - - - Methods - - -
        public void UpdateBarcodeList()
        {
            IsLoading = Visibility.Visible;
            Task T = Task.Run(async () =>
            {
                //await Task.Delay(500);
                await Application.Current.Dispatcher.InvokeAsync((Action)delegate
                {
                    DataTable DT = (new LocalDBAdapter("SELECT Id, Barcode, Extern " +
                                                       "FROM Extern;")).DB_Output();
                    BarcodeList.Clear();
                    if (DT.Rows.Count > 0)
                    {
                        foreach (DataRow r in DT.Rows)
                        {
                            BarcodeList.Add(new Barcode()
                            {
                                Id = (long)r["Id"],
                                BC = (string)r["Barcode"],
                                MR_Name = (string)r["Extern"]
                            });
                        }
                    }

                    Recipes.Clear();
                    ExternAdapter ra = (ExternAdapter)ApplicationService.GetAdapter("ExternAdapter");
                    Recipes = ra.Recipes;
                   
                    IsLoading = Visibility.Hidden;
                });
            });
        }

        public async Task UpdateFileList()
        {
            IsLoading = Visibility.Visible;
            ObservableCollection<MachineRecipe> T_recipes = new ObservableCollection<MachineRecipe>();
            string temp= SelectedBarcodeBuffer.MR_Name;
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
            if (RecipeClass.IsExistingRecipeFile(temp.ToString()))
                SelectedRecipe = Recipes.Where(r => r.Name == temp.ToString()).First();
            //await Task.Delay(500);
            IsLoading = Visibility.Hidden;

        }

        public ObservableCollection<MachineRecipe> ConvertToRecipeCollection(IEnumerable original)
        {
            return new ObservableCollection<MachineRecipe>(original.Cast<MachineRecipe>());
        }

        public ObservableCollection<Barcode> ConvertToBarcodeCollection(IEnumerable original)
        {
            return new ObservableCollection<Barcode>(original.Cast<Barcode>());
        }
        #endregion

    }
}
