using HMI.Module;
using HMI.Resources;
using HMI.Views.MessageBoxRegion;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Recipe;



namespace HMI.Views.MainRegion
    {
    class RecipeIEAdapter : AdapterBase
    {

        public RecipeIEAdapter()
        {
            SelectSCommand = new ActionCommand(SelectSCommandExecuted);
            SelectFCommand = new ActionCommand(SelectFCommandExecuted);
            ExportCommand = new ActionCommand(ExportCommandExecuted);
            ImportCommand = new ActionCommand(ImportCommandExecuted);
            CloseDialogViewCommand = new ActionCommand(CloseDialogViewCommandExecuted);
          
        }

        #region - - - Properties - - -
        IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
        string TitleOpen = ApplicationService.GetText("@RecipeSystem.IE.Text6").ToString();
        string TitleExport = ApplicationService.GetText("@RecipeSystem.IE.Text3").ToString();
        string Filter = "";
        string InitialDirectory = (new LocalResources()).Default;
        string FilePath = "";
        string [] FileNames ;
        string FolderPath = "";
        string Extension = "";

        ObservableCollection<RecipeToIE> recipeToImport = new ObservableCollection<RecipeToIE>();
        public ObservableCollection<RecipeToIE> RecipesToImport
        {
            get { return this.recipeToImport; }
            set
            {
                this.recipeToImport = value;
                this.OnPropertyChanged("RecipesToImport");
            }
        }

        ObservableCollection<RecipeToIE> recipeToExport = new ObservableCollection<RecipeToIE>();
        public ObservableCollection<RecipeToIE> RecipesToExport
        {
            get { return this.recipeToExport; }
            set
            {
                this.recipeToExport = value;
                this.OnPropertyChanged("RecipesToExport");
            }
        }

        RecipeToIE selectedRecipe = new RecipeToIE();
        public RecipeToIE SelectedRecipe
        {
            get { return this.selectedRecipe; }
            set
            {
                this.selectedRecipe = value;
                this.OnPropertyChanged("SelectedRecipe");
            }
        }

        ObservableCollection<MachineRecipe> recipes = new ObservableCollection<MachineRecipe>();
        public ObservableCollection<MachineRecipe> Recipes
        {
            get { return this.recipes; }
            set
            {
                this.recipes = value;
                this.OnPropertyChanged("Recipes");
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
        public ICommand SelectSCommand { get; set; }
        private void SelectSCommandExecuted(object parameter)
        {
           
            Filter = "Siemens Recipe (*.csv) | *.csv";
            if (ShowImportSDialog())
            {
                IsLoading = Visibility.Visible;
                SiemensParser SP = new SiemensParser();
                Task.Run(async () =>
                {
                    await Task.Delay(1500);
                    RecipesToImport = SP.GetRecipesToImport(FilePath);
                    IsLoading = Visibility.Hidden;
                });
            }
        }

        public ICommand SelectFCommand { get; set; }
        private void SelectFCommandExecuted(object parameter)
        {
           
            Filter = "Forplan Recipe(*.R) | *.R";
            if (ShowImportFDialog())
            {
                IsLoading = Visibility.Visible;
                
                ForplanRecipesIE ER = new ForplanRecipesIE();
                Task.Run(async () =>
                {
                    await Task.Delay(1500);
                    RecipesToImport = ER.GetRecipesToImport(FolderPath, FileNames);
                  

                    IsLoading = Visibility.Hidden;
                   
                });
            }
        }

        public ICommand ImportCommand { get; set; }
        private void ImportCommandExecuted(object parameter)
        {
            IRegionService iRS = ApplicationService.GetService<IRegionService>();


            RecipeAdapter RA = (RecipeAdapter)((Recipe_Main)iRS.GetView("Recipe_Main")).DataContext;
            RA.LastLoaded = new MachineRecipe();
            if (RecipesToImport.Count > 0) 
            {
                IsLoading = Visibility.Visible;
                switch (RecipesToImport[0].Type) 
                {
                    case "Siemens":
                        SiemensParser SP = new SiemensParser();
                        Task.Run(async () =>
                        {
                            await Task.Delay(1500);
                            SP.DoWork(RecipesToImport[0].Path);
                            foreach (RecipeToIE R in RecipesToImport)
                            {
                                if (R.isSelected)
                                {
                                    await SP.ImportAsync(R);
                                    R.isImported = true;
                                    if (R.Article.Length > 0)
                                    {
                                        R.Status = SP.WriteArticle(R.Article, R.Name) ? 3 : 4;
                                    }
                                    else 
                                    {
                                        R.Status = 3;
                                    }
                                  
                                    
                                }

                            }

                            Dispatcher.Invoke(delegate
                            {
                                var temp = RecipesToImport;
                                RecipesToImport = null;
                                RecipesToImport = temp;
                            });

                            IsLoading = Visibility.Hidden;
                        });
                        break;
                    case "Forplan":
                        Task.Run(async () =>
                        {
                            await Task.Delay(1500);
                            foreach(RecipeToIE R in RecipesToImport) 
                            {
                                if (R.isSelected) 
                                {
                                    await (new ForplanRecipesIE()).Import(R);
                                    R.isImported = true;
                                    R.Status = 3;
                                }
                                
                            }
                            
                            Dispatcher.Invoke(delegate
                            {
                                var temp = RecipesToImport;
                                RecipesToImport = null;
                                RecipesToImport = temp;
                            });
                           
                            IsLoading = Visibility.Hidden;
                        });
                      
                        break;
                }
            }
        }

        public ICommand ExportCommand { get; set; }

        private void ExportCommandExecuted(object parameter)
        {
           
            if (ShowFolderSelectDialog())
            {
                ForplanRecipesIE ER = new ForplanRecipesIE();
                Task.Run(async () =>
                {
                    IsLoading = Visibility.Visible;
                    await Task.Delay(1500);
                    foreach (RecipeToIE R in RecipesToExport)
                    {
                        if (R.isSelected)
                        {
                            (new ForplanRecipesIE()).Export(R,FolderPath);
                            R.Status = 3;
                        }
                    }

                    Dispatcher.Invoke(delegate
                    {
                        var temp = RecipesToExport;
                        RecipesToExport = null;
                        RecipesToExport = temp;
                    });
                    IsLoading = Visibility.Hidden;
                });
            }
        }
        public ICommand CloseDialogViewCommand { get; set; }

        private void CloseDialogViewCommandExecuted(object parameter)
        {

            ApplicationService.SetView("DialogRegion", "EmptyView");
        }

        #endregion

        #region - - - Methods - - -

        public bool ShowImportSDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = TitleOpen;
            fileDialog.Filter = Filter;
            fileDialog.InitialDirectory = InitialDirectory;
            if ((bool)fileDialog.ShowDialog())
            {
                FilePath = fileDialog.FileName;
                Extension = Path.GetExtension(FilePath);
                return true;
            }
            return false;
        }

        public bool ShowImportFDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = TitleOpen;
            fileDialog.Filter = Filter;
            fileDialog.Multiselect = true;
            fileDialog.InitialDirectory = InitialDirectory;
            if ((bool)fileDialog.ShowDialog() && fileDialog.FileNames.Length > 0)
            {
                FolderPath = fileDialog.FileNames[0].Substring(0, fileDialog.FileNames[0].Length - fileDialog.SafeFileNames[0].Length);
                FileNames = fileDialog.SafeFileNames;
                Extension = Path.GetExtension(FilePath);
                return true;
            }
            return false;
        }

        public bool ShowFolderSelectDialog()
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
            folderDialog.Title = TitleExport;
            folderDialog.IsFolderPicker = true;
            folderDialog.InitialDirectory = InitialDirectory;
            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                FolderPath = folderDialog.FileName;
                return true;
            }
            return false;
        }

        public void UpdateRecipeToExport()
        {
            IsLoading = Visibility.Visible;
            Task.Run(async () =>
            {
                await Task.Delay(1500);
                RecipesToExport = new ForplanRecipesIE().GetRecipesToExport();
                IsLoading = Visibility.Hidden;
            });
        }
        #endregion

    }
}
