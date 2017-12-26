using System;
using System.Drawing;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;

//Notification bar app guide from https://alanbondo.wordpress.com/2008/06/22/creating-a-system-tray-app-with-c/
//Process event watcher from https://www.fluxbytes.com/csharp/how-to-know-if-a-process-exited-or-started-using-events-in-c/
//Show/hide console window from https://stackoverflow.com/questions/3571627/show-hide-the-console-window-of-a-c-sharp-console-application
//Start application at startup from https://www.fluxbytes.com/csharp/start-application-at-windows-startup/
//NirSoft's MultiMonitorTool from http://www.nirsoft.net/utils/multi_monitor_tool.html
//Running as an administrator from https://stackoverflow.com/questions/7666408/how-to-request-administrator-permissions-when-the-program-starts
//ClickOnce issue from https://stackoverflow.com/questions/11023998/clickonce-does-not-support-the-request-execution-level-requireadministrator

namespace Bonbon
{
    class Bonbon : Form
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Begin the Bonbon
            Application.Run(new Bonbon());
        }

        //Notification center icon and menu
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        //Bonbon preferences object
        BonbonPreferences preferences;

        string TargetApplication = "MixedRealityPortal.exe";
        //string TargetApplication = "notepad.exe";

        //Process event watcher query
        ManagementEventWatcher processStartEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
        ManagementEventWatcher processStopEvent = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");

        public Bonbon()
        {
            //Load perferences
            preferences = new BonbonPreferences();

            // Create the menu
            ContextMenu trayMenu = getBonbonMenu();
            // Create a tray icon
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Bonbon";
            //trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            //Add the process event handlers
            processStartEvent.EventArrived += new EventArrivedEventHandler(processStartEvent_EventArrived);
            processStopEvent.EventArrived += new EventArrivedEventHandler(processStopEvent_EventArrived);
            //Begin watching
            processStartEvent.Start();
            processStopEvent.Start();

            //Get the console window and hide it
            var handle = GetConsoleWindow();
            // Hide
            ShowWindow(handle, SW_HIDE);
        }

        //Don't forgetti to dispose of the event as it arrives or else the query will stop. (https://social.msdn.microsoft.com/Forums/vstudio/en-US/158d5f4b-1238-4854-a66c-b51e37550c52/memory-leak-in-wmi-when-querying-event-logs?forum=netfxbcl)
        void processStartEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();

            Console.WriteLine("Process started. Name: " + processName + " | ID: " + processID + " - Ignoring.");

            if (processName.Contains(TargetApplication))
            {
                Console.WriteLine("Target process started. Name: " + processName + " | ID: " + processID + " - Disabling monitors.");
                if (preferences.Monitor1Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Disable 1");
                }
                System.Threading.Thread.Sleep(1000);
                if (preferences.Monitor2Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Disable 2");
                }
                System.Threading.Thread.Sleep(1000);
                if (preferences.Monitor3Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Disable 3");
                }
                System.Threading.Thread.Sleep(1000);
                if (preferences.Monitor4Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Disable 4");
                }
                System.Threading.Thread.Sleep(1000);
                if (preferences.Monitor5Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Disable 5");
                }
            }

            e.NewEvent.Dispose();
        }
        
        //NirSoft's MultiMonitorTool should be in 
        void processStopEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();

            Console.WriteLine("Process stopped. Name: " + processName + " | ID: " + processID + " - Ignoring.");

            if (processName.Contains(TargetApplication))
            {
                Console.WriteLine("Target process ended. Name: " + processName + " | ID: " + processID + " - Enabling monitors.");
                if (preferences.Monitor1Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Enable 1");
                }
                System.Threading.Thread.Sleep(1000);
                if (preferences.Monitor2Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Enable 2");
                }
                System.Threading.Thread.Sleep(1000);
                if (preferences.Monitor3Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Enable 3");
                }
                System.Threading.Thread.Sleep(1000);
                if (preferences.Monitor4Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Enable 4");
                }
                System.Threading.Thread.Sleep(1000);
                if (preferences.Monitor5Disable)
                {
                    System.Diagnostics.Process.Start(@"MultiMonitorTool\MultiMonitorTool.exe", "/Enable 5");
                }
            }

            e.NewEvent.Dispose();
        }

        //Seperate context menu mess
        private ContextMenu getBonbonMenu()
        {
            // Create a simple tray menu
            trayMenu = new ContextMenu();

            //Title
            //trayMenu.MenuItems.Add("Bonbon v0.01");
            MenuItem TitleMenuItem = new MenuItem();
            TitleMenuItem.Text = "Bonbon";
            TitleMenuItem.Enabled = false;
            trayMenu.MenuItems.Add(TitleMenuItem);

            //Options
            MenuItem OptionsMenuItem = new MenuItem();
            OptionsMenuItem.Text = "Options";
            OptionsMenuItem.Click += new System.EventHandler(this.OptionsMenuItemClick);
            trayMenu.MenuItems.Add(OptionsMenuItem);

            //Show log
            MenuItem ShowLogMenuItem = new MenuItem();
            ShowLogMenuItem.Text = "Show log";
            ShowLogMenuItem.Click += new System.EventHandler(this.ConsoleShowHideClick);
            trayMenu.MenuItems.Add(ShowLogMenuItem);

            //Exit
            trayMenu.MenuItems.Add("Exit", OnExit);

            return trayMenu;
        }

        private void OptionsMenuItemClick(object sender, EventArgs e)
        {
            //MessageBox.Show("Options clicked");
            BonbonOptions optionsForm = new BonbonOptions();
            optionsForm.Show();
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        //Show the console window if the user desires
        private void ConsoleShowHideClick(object sender, EventArgs e)
        {
            var handle = GetConsoleWindow();

            // Show
            ShowWindow(handle, SW_SHOW);
            Console.WriteLine("[WARNING!] If you close this log window, you will close Bonbon and have to restart it.");
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}
