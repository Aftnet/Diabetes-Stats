using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace DiabetesStats
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            App.Current.Properties["Database"] = new Models.Database();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string AppDataFolderPath = GetUserAppDataPath();
            if (!Directory.Exists(AppDataFolderPath))
            {
                Directory.CreateDirectory(AppDataFolderPath);
            }

            AppDomain.CurrentDomain.SetData("DataDirectory", AppDataFolderPath);
        }

        public string GetUserAppDataPath()
        {
            string path = string.Empty;
            Assembly assm;
            Type at;
            object[] r;

            // Get the .EXE assembly
            assm = Assembly.GetEntryAssembly();
            // Get a 'Type' of the AssemblyCompanyAttribute
            at = typeof(AssemblyCompanyAttribute);
            // Get a collection of custom attributes from the .EXE assembly
            r = assm.GetCustomAttributes(at, false);
            // Get the Company Attribute
            AssemblyCompanyAttribute ct = ((AssemblyCompanyAttribute)(r[0]));
            // Build the User App Data Path
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path += @"\" + ct.Company;
            path += @"\" + assm.GetName().Name.ToString();
            path += @"\" + assm.GetName().Version.ToString();

            return path;
        }
    }
}
