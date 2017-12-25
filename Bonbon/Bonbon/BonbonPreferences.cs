using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonbon
{
    class BonbonPreferences
    {
        public Boolean RunOnStartup;

        public Boolean FirstTimeRunning;

        public Boolean Monitor1Disable;
        public Boolean Monitor2Disable;
        public Boolean Monitor3Disable;
        public Boolean Monitor4Disable;
        public Boolean Monitor5Disable;

        //by default, loading a BonbonPreferences class loads the current saved preferences
        public BonbonPreferences()
        {
            RunOnStartup = Properties.Settings.Default.RunOnStartup;
            setBonbonAutostart();

            FirstTimeRunning = Properties.Settings.Default.FirstTimeRunning;

            Monitor1Disable = Properties.Settings.Default.Monitor1Disable;
            Monitor2Disable = Properties.Settings.Default.Monitor2Disable;
            Monitor3Disable = Properties.Settings.Default.Monitor3Disable;
            Monitor4Disable = Properties.Settings.Default.Monitor4Disable;
            Monitor5Disable = Properties.Settings.Default.Monitor5Disable;
        }

        public void setBonbonAutostart()
        {
            //if the user prefers to run the program on startup, then set the key
            if (RunOnStartup)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("Bonbon", "\"" + System.Reflection.Assembly.GetEntryAssembly().Location + "\"");
                }
                Console.WriteLine("Bonbon is set to run on startup.");
            }
            else if (!RunOnStartup)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("Bonbon", false);
                }
                Console.WriteLine("Bonbon is set NOT to run on startup.");
            }
        }

        //Save the preferences file to the settings
        public void save()
        {
            Properties.Settings.Default.RunOnStartup = RunOnStartup;
            setBonbonAutostart();

            Properties.Settings.Default.FirstTimeRunning = FirstTimeRunning;

            Properties.Settings.Default.Monitor1Disable = Monitor1Disable;
            Properties.Settings.Default.Monitor2Disable = Monitor2Disable;
            Properties.Settings.Default.Monitor3Disable = Monitor3Disable;
            Properties.Settings.Default.Monitor4Disable = Monitor4Disable;
            Properties.Settings.Default.Monitor5Disable = Monitor5Disable;

            Properties.Settings.Default.Save();
        }
    }
}
