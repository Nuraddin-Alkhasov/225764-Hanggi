using HMI.Views.MessageBoxRegion;
using HMI.Views.TouchpadRegion;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;
using static HMI.Resources.LocalResources;

namespace HMI.Services
{
    class DoBackup
    {
      
        string[] activeDays;

        public DoBackup()
        {
            Application.Current.Dispatcher.InvokeAsync((Action)delegate
            {
                ApplicationService.SetView("TouchpadRegion", "WaitScreen", new WaitData(0, "@WaitScreen.Text1", ""));
            });
            BackUP();
        }
        ProjectResourcePaths Paths;
        private void BackUP()
        {
            Task doTask = Task.Run(() => {
                try
                {
                   Paths = (new Resources.LocalResources()).Paths;
                    //prepare data
                    
                    activeDays = new string[30];
                    for (int i = 0; i < 30; i++)
                    {
                        activeDays[i] = (DateTime.Now.AddDays(i * -1)).ToString("yyyy-MM-dd");
                    }

                    ClearData();

                    //create root folder
                    if (!System.IO.Directory.Exists(Paths.Backup.ToDayPath))
                    {
                        System.IO.Directory.CreateDirectory(Paths.Backup.ToDayPath);
                    }

                    
                    if (!Directory.Exists(Paths.Backup.DB))
                    {
                        System.IO.Directory.CreateDirectory(Paths.Backup.DB);
                    }
                   
                    if (!Directory.Exists(Paths.Backup.Recipes))
                    {
                        System.IO.Directory.CreateDirectory(Paths.Backup.Recipes);
                    }


                    //DB
                    string[] filePaths = Directory.GetFiles(Paths.Project.DB);
                    foreach (var filename in filePaths)
                    {
                        if (!IsFileLocked(filename))
                        {
                            string str = filename.Replace(Paths.Project.DB, Paths.Backup.DB);
                            File.Copy(filename.ToString(), str, true);
                        }
                    }
                   
                    //Recipes
                    string[] fileDirectories = Directory.GetDirectories(Paths.Project.Recipes);
                    foreach (var fileDirectory in fileDirectories)
                    {
                        if (!Directory.Exists(Paths.Backup.Recipes + fileDirectory.Replace(Path.GetDirectoryName(fileDirectory), "")))
                        {
                            System.IO.Directory.CreateDirectory(Paths.Backup.Recipes + fileDirectory.Replace(Path.GetDirectoryName(fileDirectory), ""));
                        }

                        filePaths = Directory.GetFiles(fileDirectory);
                        foreach (var filename in filePaths)
                        {
                            if (!IsFileLocked(filename))
                            {
                                string str = filename.Replace(fileDirectory, Paths.Backup.Recipes + fileDirectory.Replace(Path.GetDirectoryName(fileDirectory), ""));
                                File.Copy(filename.ToString(), str, true);
                            }
                        }
                    }

                    if (File.Exists(Paths.Backup.ToDayPath + ".zip"))
                    {
                        if (!IsFileLocked((new Resources.LocalResources()).Paths.Backup.ToDayPath + ".zip"))
                        {
                            File.Delete((new Resources.LocalResources()).Paths.Backup.ToDayPath + ".zip");
                        }
                    }

                    ZipFile.CreateFromDirectory(Paths.Backup.ToDayPath, Paths.Backup.ToDayPath + ".zip", CompressionLevel.Fastest, false);
                    System.IO.Directory.Delete(Paths.Backup.ToDayPath, true);
                }
                catch (Exception ex)
                {
                    new MessageBoxTask(ex, "* * * *", MessageBoxIcon.Exclamation);
                }

                Application.Current.Dispatcher.InvokeAsync((Action)delegate
                {
                    ApplicationService.SetView("TouchpadRegion", "EmptyView");
                });
            });
        }

        private void ClearData()
        {
            string[] filePaths;

            //Backups

            if (Directory.Exists(Paths.Backup.Path))
            {
                filePaths = Directory.GetFiles(Paths.Backup.Path);
                foreach (var filename in filePaths)
                {
                    bool isInRange = false;
                    foreach (var day in activeDays)
                    {
                        if (filename.Contains(day))
                        {
                            isInRange = true;
                            break;
                        }
                    }
                    if (!isInRange)
                        if (!IsFileLocked(filename))
                            File.Delete(filename);
                }
            }
            
        }

        public bool IsFileLocked(string filename)
        {
            bool Locked = false;
            try
            {
                FileStream fs =  File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                fs.Close();
            }
            catch 
            {
                Locked = true;
            }
            return Locked;
        }
    }
}
