using HMI.Module;
using HMI.Resources;
using HMI.Views.MainRegion.Recipe;
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
    class RecipeCompareAdapter : AdapterBase
    {

        public RecipeCompareAdapter()
        {
            Close = new ActionCommand(CloseExecuted);
        }

        #region - - - Properties - - -

        IRecipeClass RecipeClass = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
        RecipeToIE toCompare;
        public RecipeToIE ToCompare
        {
            get { return toCompare; }
            set
            {
                toCompare = value;
                FillTheGrid();
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
        ObservableCollection<Variable> variables = new ObservableCollection<Variable>();
        public ObservableCollection<Variable> Variables
        {
            get
            {
                return variables;
            }
            set
            {
                this.variables = value;
                this.OnPropertyChanged("Variables");
            }
        }

        #endregion

        #region - - - Commands - - -

        public ICommand Close { get; set; }

        private void CloseExecuted(object parameter)
        {
            ApplicationService.SetView("MessageBoxRegion", "EmptyView");
        }

        #endregion

        #region - - - Methods - - -
        void FillTheGrid()
        {
            IsLoading = Visibility.Visible;
            Task T = Task.Run(async () =>
            {
                Dictionary<string, object> FR;
                switch (ToCompare.Type) 
                {
                    case "Siemens":
                        FR = RecipeClass.GetRecipeFile(ToCompare.Name).GetValues();
                        SiemensParser SP = new SiemensParser();
                        SP.DoWork(ToCompare.Path);
                        SiemensRecipe SR = SP.SiemensRecipes.Where(x => x.Name == ToCompare.Name).ToArray()[0];

                        await Dispatcher.InvokeAsync(delegate
                        {
                            if (Variables.Count > 0)
                                Variables.Clear();
                            foreach (SRValue v in SR.Values)
                            {
                                if (v.Name.Contains("Swing_change_between") || v.Name.Contains("Swing_RPM") || v.Name.Contains("Swing_to"))
                                {
                                    string tempfv = Math.Round(Convert.ToDouble(FR["Ergospin.Recipe." + v.Name].ToString()), 2).ToString("0.00");
                                    string tempsv = Math.Round(Convert.ToDouble(v.Value), 2).ToString("0.00");
                                    Variables.Add(new Variable()
                                    {
                                        Name = v.Name.Replace("#STRING113", ""),
                                        Forplan = tempfv,
                                        Extern = tempsv,
                                        Status = tempfv == tempsv ? 1 : 2
                                    });
                                }
                                else
                                {
                                    string tempfv = FR["Ergospin.Recipe." + v.Name].ToString();
                                    string tempsv = v.Value;

                                    Variables.Add(new Variable()
                                    {
                                        Name = v.Name.Replace("#STRING113", ""),
                                        Forplan = tempfv,
                                        Extern = tempsv,
                                        Status = tempfv == tempsv ? 1 : 2
                                    });
                                }
                            }
                        });

                        break;
                    case "Forplan":
                        FR = RecipeClass.GetRecipeFile(ToCompare.Name).GetValues();
                        string text = System.IO.File.ReadAllText(ToCompare.Path + ToCompare.Name + ToCompare.Extension);
                        VWRecipe VWR = new VWRecipe("Ergospin", text);
                        await Dispatcher.InvokeAsync(delegate
                        {
                            if (Variables.Count > 0)
                                Variables.Clear();
                            foreach (VWVariable v in VWR.VWVariables)
                            {
                                if (v.Item.ToString().Contains("Swing_change_between") || v.Item.ToString().Contains("Swing_RPM") || v.Item.ToString().Contains("Swing_to"))
                                {
                                    string tempfv = Math.Round(Convert.ToDouble(FR[v.Item.ToString()].ToString()), 2).ToString("0.00");
                                    string tempvwv = Math.Round(Convert.ToDouble(VWR.VWVariables.Where(x => x.Item.ToString() == v.Item.ToString()).ToArray()[0].Value.ToString()), 2).ToString("0.00");
                                    Variables.Add(new Variable()
                                    {
                                        Name = v.Item.ToString().Replace("Ergospin.Recipe.", ""),
                                        Forplan = tempfv,
                                        Extern = tempvwv,
                                        Status = tempfv == tempvwv ? 1 : 2
                                    });
                                }
                                else
                                {
                                    string tempfv = FR[v.Item.ToString()].ToString();
                                    string tempvwv = VWR.VWVariables.Where(x => x.Item.ToString() == v.Item.ToString()).ToArray()[0].Value.ToString();

                                    Variables.Add(new Variable()
                                    {
                                        Name = v.Item.ToString().Replace("Ergospin.Recipe.", ""),
                                        Forplan = tempfv,
                                        Extern = tempvwv,
                                        Status = tempfv == tempvwv ? 1 : 2
                                    });
                                }
                            }
                        });

                        break;
                }
               
                
                
                IsLoading = Visibility.Hidden;
            });
        }

        #endregion

        #region - - - Custom Object - - -
        public class Variable
        {
            public string Name { get; set; }
            public string Forplan { get; set; }
            public string Extern { get; set; }
            public int Status { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        #endregion


    }
}
