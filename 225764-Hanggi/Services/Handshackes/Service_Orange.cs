using HMI.Interfaces;
using HMI.Module;
using HMI.Views.MainRegion.Recipe;
using HMI.Views.MessageBoxRegion;
using HMI.Views.TouchpadRegion;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Threading;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Recipe;

namespace HMI.Services
{
    [ExportService(typeof(IOrange))] 
    [Export(typeof(IOrange))]
    public class Service_Orange : ServiceBase, IOrange
    {
        IRecipeClass RecipeClassFrom;
        IRecipeClass RecipeClassTo;
        IVariableService VS;
        IVariable MRFromPLC;
        string Ergospin;

        BackgroundWorker loadMR;

        public Service_Orange()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }

        #region - - - MR Handshacke - - -

        void MRFromPLC_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue && bool.Parse(e.Value.ToString()))
            {
                MRFromPLC.Value = false;
                if (!loadMR.IsBusy)
                    loadMR.RunWorkerAsync();
                else { ApplicationService.SetVariableValue(Ergospin + ".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Not loaded", true); }
            }

        }
        void W1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.InvokeAsync((Action)delegate
            {
                ApplicationService.SetView("TouchpadRegion", "WaitScreen", new WaitData(1, "@WaitScreen.Text2", Ergospin));
            });

            try
            {
                MR_From_PLCAsync();
            }
            catch { ApplicationService.SetVariableValue(Ergospin+".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Not loaded", true); }
        }

        #endregion

        #region OnProject

  
        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
            base.OnLoadProjectStarted();
        }

        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            Ergospin = "Orange"; 
             RecipeClassFrom = ApplicationService.GetService<IRecipeService>().GetRecipeClass(Ergospin);
            RecipeClassTo = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
            VS = ApplicationService.GetService<IVariableService>();
            MRFromPLC = VS.GetVariable(Ergospin + ".PLC.Blocks.DB PC.Ergospin.Handshake.to PC.Update");
            MRFromPLC.Change += MRFromPLC_Change;

            loadMR = new BackgroundWorker();
            loadMR.DoWork += W1_DoWork;

            base.OnLoadProjectCompleted();
        }

        // Hier stehen noch die VisiWin Funktionen zur Verfügung
        protected override void OnUnloadProjectStarted()
        {
            base.OnUnloadProjectStarted();
        }

        // Hier sind keine VisiWin Funktionen mehr verfügbar. Bei C/S ist die Verbindung zum Server schon getrennt.
        protected override void OnUnloadProjectCompleted()
        {
            base.OnUnloadProjectCompleted();
        }

        #endregion

        #region - - - Methods - - -

        #region - - - MachineRecipe - - - 

        async void MR_From_PLCAsync()
        {
            ReadProcessToBufferResult r1 = await RecipeClassFrom.ReadProcessToBufferAsync();
            if(r1.Result == GetRecipeResult.Succeeded)
            {
                object RecipeName;
                RecipeClassFrom.GetValue(Ergospin+".PLC.Blocks.DB PC.Ergospin.Station.Rez_Name#STRING40", out RecipeName);
                if (RecipeClassTo.IsExistingRecipeFile(RecipeName.ToString()))
                {
                    string note = RecipeClassTo.GetRecipeFile(RecipeName.ToString()).Description;
                    string[] variables = RecipeClassFrom.GetVariableNames().ToArray();

                    foreach (string v in variables)
                    {
                        if (v != Ergospin + ".PLC.Blocks.DB PC.Ergospin.Station.Rez_Name#STRING40") 
                        {
                            object value;
                            RecipeClassFrom.GetValue(v, out value);
                            ApplicationService.SetVariableValue(v.Replace(Ergospin + ".PLC.Blocks.DB PC.Ergospin.Station.", "Ergospin.Recipe."), value);
                        }
                    }
               
                    ReadProcessToBufferResult r2 = await RecipeClassTo.ReadProcessToBufferAsync();
                    if (r2.Result == GetRecipeResult.Succeeded)
                    {
                        SaveToFileFromBufferResult r3 = await RecipeClassTo.SaveToFileFromBufferAsync(RecipeName.ToString(), note, true);
                        if (r3.Result == SaveRecipeResult.Succeeded)
                        {
                            ApplicationService.SetVariableValue(Ergospin + ".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Loaded", true);
                            await Dispatcher.BeginInvoke((Action)(() =>
                            {
                                ApplicationService.SetView("TouchpadRegion", "EmptyView");
                            }));
                        }
                    }
                    else { ApplicationService.SetVariableValue(Ergospin + ".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Not loaded", true); }

                }
                else { ApplicationService.SetVariableValue(Ergospin + ".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Not loaded", true); }
            }
            else
            {
                ApplicationService.SetVariableValue(Ergospin + ".PLC.Blocks.DB PC.Ergospin.Handshake.from PC.Not loaded", true);
            }
        }
       
     

      
        #endregion

        #endregion
      
    }
}
