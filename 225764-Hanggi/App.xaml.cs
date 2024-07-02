using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using HMI;
using VisiWin.ApplicationFramework;
using VisiWin.ApplicationManager;
using VisiWin.Diagnostics;
using VisiWin.Project;

namespace HMI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ApplicationInitializer applicationInitializer;
        private SplashWindow SW;

        protected override void OnExit(ExitEventArgs e)
        {
            var projectService = ApplicationService.GetService<IProjectService>();
            if (projectService != null && projectService.IsInRunMode)
            {
                projectService.ShutdownProject();
            }

            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Task obTask = Task.Run(() => {

                Dispatcher.InvokeAsync(delegate
                {
                    SW = new SplashWindow();
                    SW.Show();
                });

            });


            var applicationManager = (ApplicationManager) this.FindResource("ApplicationManager");
            var projectName = ApplicationInitializer.GetProjectNameFromRuntimeSettings() ?? applicationManager?.ProjectName;

            if (applicationManager?.HandleApplicationException ?? true)
            {
                AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;
                Current.DispatcherUnhandledException += this.Current_DispatcherUnhandledException;
            }

            ApplicationService.UseTouchkeyboard = applicationManager?.UseTouchkeyboard ?? true;

            this.applicationInitializer = new ApplicationInitializer(projectName);
            this.applicationInitializer.Initialize();

            var projectService = ApplicationService.GetService<IProjectService>();
            projectService.WindowsKeysDisabled = applicationManager?.WindowsKeysDisabled ?? false;
            projectService.RunProjectCompleted += this.OnRunProjectCompleted;

            var startDelay = applicationManager?.StartDelay ?? 0;
            var projectParams = applicationManager?.ProjectStartParameters != null && applicationManager.ProjectStartParameters.Count > 0 ? applicationManager.ProjectStartParameters : null;
            
            projectService.RunProjectAsync(projectName, startDelay, projectParams);

            base.OnStartup(e);
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ApplicationService.Log(EventSource.Application, EventCategory.Fatal, "UnhandledDispatcherException : " + e.Exception);
            e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            ApplicationService.Log(EventSource.Application, EventCategory.Fatal, "UnhandledThreadException : " + ex);
        }

        private void OnRunProjectCompleted(object sender, RunProjectCompletedEventArgs e)
        {
            var projectService = (IProjectService)sender;
            projectService.RunProjectCompleted -= this.OnRunProjectCompleted;

            if (!e.Connected)
            {
                ApplicationService.Log(EventSource.Project, EventCategory.Fatal, e.Error.Message);
            }
            else
            {
                var mainWindow = new MainWindow();

                this.MainWindow = mainWindow;

                this.applicationInitializer.InitializeMainWindow(mainWindow);

                mainWindow.Show();                
            } 
           SW.Close();
        }
    }
}
