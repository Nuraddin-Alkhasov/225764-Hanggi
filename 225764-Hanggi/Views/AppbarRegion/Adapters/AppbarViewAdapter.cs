using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Commands;
using VisiWin.Language;

namespace HMI
{
    [ExportAdapter("AppbarViewAdapter")]
    public class AppbarViewAdapter : AdapterBase
    {
        private readonly ILanguageService languageService;
       
        public AppbarViewAdapter()
        {
            this.languageService = ApplicationService.GetService<ILanguageService>();
            languageService.LanguageChanged += LanguageService_LanguageChanged;


            this.OpenCommand = new ActionCommand(this.OpenCommandExecuted);
            this.CloseCommand = new ActionCommand(this.CloseCommandExecuted);

            this.MainViewOpenCommand = new ActionCommand(this.MainViewOpenCommandExecuted);
            this.RecipeViewOpenCommand = new ActionCommand(this.RecipeViewOpenCommandExecuted);
            this.ExternViewOpenCommand = new ActionCommand(this.ExternViewOpenCommandExecuted);
            this.ProtocolViewOpenCommand = new ActionCommand(this.ProtocolViewOpenCommandExecuted);

            this.ChangeLanguageCommand = new ActionCommand(this.ChangeLanguageCommandExecuted);
            this.LogInOutCommand = new ActionCommand(this.LogInOutCommandExecuted);
            this.ExitCommand = new ActionCommand(this.ExitCommandExecuted);
        }

        private void LanguageService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            var name = languageService.CurrentLanguage.Text;
            CurrentLanguage = name.Substring(0, name.IndexOf('(') - 1);
        }

        private Visibility openButtonVisibility = Visibility.Visible;
        public Visibility OpenButtonVisibility
        {
            get { return this.openButtonVisibility; }
            set
            {
                this.openButtonVisibility = value;
                this.OnPropertyChanged("OpenButtonVisibility");
            }
        }

        private Visibility closeButtonVisibility = Visibility.Collapsed;
        public Visibility CloseButtonVisibility
        {
            get { return this.closeButtonVisibility; }
            set
            {
                this.closeButtonVisibility = value;
                this.OnPropertyChanged("CloseButtonVisibility");
            }
        }
       
        

        private string ltMainViewButton = "@Appbar.Text3";
        public string LTMainViewButton
        {
            get { return this.ltMainViewButton; }
            set
            {
                this.ltMainViewButton = value;
                this.OnPropertyChanged("LTMainViewButton");
            }
        }

       

        private string ltRecipeViewButton = "@Appbar.Text3";
        public string LTRecipeViewButton
        {
            get { return this.ltRecipeViewButton; }
            set
            {
                this.ltRecipeViewButton = value;
                this.OnPropertyChanged("LTRecipeViewButton");
            }
        }

        private string ltExternViewButton = "@Appbar.Text3";
        public string LTExternViewButton
        {
            get { return this.ltExternViewButton; }
            set
            {
                this.ltExternViewButton = value;
                this.OnPropertyChanged("LTExternViewButton");
            }
        }
        private string ltProtocolViewButton = "@Appbar.Text3";
        public string LTProtocolViewButton
        {
            get { return this.ltProtocolViewButton; }
            set
            {
                this.ltProtocolViewButton = value;
                this.OnPropertyChanged("LTProtocolViewButton");
            }
        }

        private string currentLanguage = "";
        public string CurrentLanguage
        {
            get { return this.currentLanguage; }
            set
            {
                this.currentLanguage = value;
                this.OnPropertyChanged("CurrentLanguage");
            }
        }

        private string currentUser = "";
        public string CurrentUser
        {
            get { return this.currentUser; }
            set
            {
                this.currentUser = value;
                this.OnPropertyChanged("CurrentUser");
            }
        }
        private string powerOff = "";
        public string PowerOff
        {
            get { return this.powerOff; }
            set
            {
                this.powerOff = value;
                this.OnPropertyChanged("PowerOff");
            }
        }


        #region - - - Commands - - -
        public ICommand OpenCommand { get; set; }
        private void OpenCommandExecuted(object parameter)
        {
            CloseButtonVisibility = Visibility.Visible;
            OpenButtonVisibility = Visibility.Collapsed;

            
            LTMainViewButton = "@Appbar.lblAnlageübersicht";
           
            LTRecipeViewButton  = "@Appbar.lblRezeptverwaltung";
            LTExternViewButton = "@Appbar.lblExtern";

            LTProtocolViewButton = "@Appbar.lbllogs";




            var name = languageService.CurrentLanguage.Text;
            CurrentLanguage = name.Substring(0, name.IndexOf('(') - 1);
            CurrentUser = ApplicationService.GetVariableValue("__CURRENT_USER.FULLNAME").ToString();
            PowerOff = "@Appbar.Exit";
        }

        public ICommand CloseCommand { get; set; }
        private void CloseCommandExecuted(object parameter)
        {
            CloseButtonVisibility = Visibility.Collapsed;
            OpenButtonVisibility = Visibility.Visible;


            LTMainViewButton = "@Appbar.Text3";
            LTRecipeViewButton = "@Appbar.Text3";
            LTExternViewButton = "@Appbar.Text3";
            LTProtocolViewButton = "@Appbar.Text3";
            CurrentLanguage = "";
            CurrentUser = "";
            PowerOff = "@Appbar.Text3";
        }
        
        public ICommand MainViewOpenCommand { get; set; }
        private void MainViewOpenCommandExecuted(object parameter)
        {
            ApplicationService.SetView("MainRegion", "MO_MainView");
        }
        
        public ICommand RecipeViewOpenCommand { get; set; }
        public void RecipeViewOpenCommandExecuted(object parameter)
        {
            ApplicationService.SetView("MainRegion", "Recipe_Main");
        }
        public ICommand ExternViewOpenCommand { get; set; }
        private void ExternViewOpenCommandExecuted(object parameter)
        {
            ApplicationService.SetView("MainRegion", "Extern_Main");
        }
        public ICommand ProtocolViewOpenCommand { get; set; }
        private void ProtocolViewOpenCommandExecuted(object parameter)
        {
            ApplicationService.SetView("MainRegion", "Protocol_Main");
        }

        public ICommand ChangeLanguageCommand { get; set; }
        private void ChangeLanguageCommandExecuted(object parameter)
        {
            switch (languageService.CurrentLanguage.LCID)
            {
                case 1031: languageService.ChangeLanguageAsync(1033); break;
                case 1033: languageService.ChangeLanguageAsync(1031); break;
                default: languageService.ChangeLanguageAsync(1031); break;
            }
        }

        public ICommand LogInOutCommand { get; set; }
        private void LogInOutCommandExecuted(object parameter)
        {
           
        }
        public ICommand ExitCommand { get; set; }
        private void ExitCommandExecuted(object parameter)
        {
            Application.Current.Shutdown();
        }

        
        #endregion


    }
}