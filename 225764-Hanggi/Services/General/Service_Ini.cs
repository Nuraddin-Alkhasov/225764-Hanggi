using HMI.Interfaces;
using HMI.Services.Custom_Objects;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using VisiWin.Recipe;

namespace HMI.Services
{
    [ExportService(typeof(IIni))] 
    [Export(typeof(IIni))]
    public class Service_Ini : ServiceBase, IIni
    {

        public Service_Ini()
        {
            if (ApplicationService.IsInDesignMode)
                return;
        }
     

        #region OnProject

      
        // Hier stehen noch keine VisiWin Funktionen zur Verfügung
        protected override void OnLoadProjectStarted()
        {
            (new VWSafeStart()).DoWork();
            base.OnLoadProjectStarted();
        }

        // Hier kann auf die VisiWin Funktionen zugegriffen werden
        protected override void OnLoadProjectCompleted()
        {
            
            InitializeRecipe();
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

        private void InitializeRecipe()
        {
            IRecipeClass T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("DarkBlue");
            T.StartEdit();
            T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("LightBlue");
            T.StartEdit();
            T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("MarineBlue");
            T.StartEdit();
            T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("MelonYellow");
            T.StartEdit();
            T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Orange");
            T.StartEdit();
            T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Pink");
            T.StartEdit();
            T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("TurquoiseGreen");
            T.StartEdit();
            T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("YellowGreen");
            T.StartEdit();

            //T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Ergospin");
            //T.StartEdit();
            //T = ApplicationService.GetService<IRecipeService>().GetRecipeClass("Extern");
            //T.StartEdit();
        }

        #endregion

    }
}
