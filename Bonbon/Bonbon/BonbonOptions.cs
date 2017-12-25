using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonbon
{
    public partial class BonbonOptions : Form
    {
        BonbonPreferences preferences;

        public BonbonOptions()
        {
            InitializeComponent();

            //Load the preferences file
            preferences = new BonbonPreferences();

            //Bonbon icon
            pictureBox1.Image = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location).ToBitmap();

            //Run on Startup
            cb_RunOnStartup.Checked = preferences.RunOnStartup;

            //Monitors to disable
            foreach (var screen in Screen.AllScreens)
            {
                //if the devicename ends with a number, pair it with a "monitor toggle' value
                int displayNo = Int32.Parse(Regex.Match(screen.DeviceName.ToString(), @"\d+").Value);

                Console.WriteLine(displayNo + " for " + screen.DeviceName.ToString());

                //if the monitor is a primary monitor, append the tag to the list.
                String isPrimary = "";
                if (screen.Primary)
                {
                    isPrimary = " (Primary)";
                }

                if (displayNo == 1)
                {
                    clb_monitors.Items.Add("Display 1" + " - " + screen.DeviceName + isPrimary, preferences.Monitor1Disable);
                }
                else if (displayNo == 2)
                {
                    clb_monitors.Items.Add("Display 2" + " - " + screen.DeviceName + isPrimary, preferences.Monitor2Disable);
                }
                else if (displayNo == 3)
                {
                    clb_monitors.Items.Add("Display 3" + " - " + screen.DeviceName + isPrimary, preferences.Monitor3Disable);
                }
                else if (displayNo == 4)
                {
                    clb_monitors.Items.Add("Display 4" + " - " + screen.DeviceName + isPrimary, preferences.Monitor4Disable);
                }
                else if (displayNo == 5)
                {
                    clb_monitors.Items.Add("Display 5" + " - " + screen.DeviceName + isPrimary, preferences.Monitor5Disable);
                }
            }        
        }

        //This method records the form selections to the preferences object, then tells the object to save
        private void savePreferences()
        {
            preferences.RunOnStartup = cb_RunOnStartup.Checked;

            preferences.Monitor1Disable = false;
            preferences.Monitor2Disable = false;
            preferences.Monitor3Disable = false;
            preferences.Monitor4Disable = false;
            preferences.Monitor5Disable = false;
            
            foreach (var CheckedItem in clb_monitors.CheckedItems)
            {
                int displayNo = Int32.Parse(Regex.Match(CheckedItem.ToString().Substring(7, 8), @"\d+").Value);

                Console.WriteLine("Display " + displayNo + " is set to be disabled.");
                
                if (displayNo == 1)
                {
                    preferences.Monitor1Disable = true;
                }
                else if (displayNo == 2)
                {
                    preferences.Monitor2Disable = true;
                }
                else if (displayNo == 3)
                {
                    preferences.Monitor3Disable = true;
                }
                else if (displayNo == 4)
                {
                    preferences.Monitor4Disable = true;
                }
                else if (displayNo == 5)
                {
                    preferences.Monitor5Disable = true;
                }
            }

            //Save
            preferences.save();

        }

        //Cancel button click
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Do you want to close the settings menu without saving?",
                "Are you sure?",
                MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                //Cancel button closes the form without question
                this.Close();
            }
            else if (result1 == DialogResult.No)
            {
                //close and do nothing

            }
        }

        //OK button click
        private void b_ok_Click(object sender, EventArgs e)
        {
            //check if the user did something stupid like disabling all their monitors
            Boolean UserDisabledAllTheirDisplays = true;
            for (int i = 0; i < clb_monitors.Items.Count; i++)
            {
                //this should be false if the user left one monitor active
                UserDisabledAllTheirDisplays = UserDisabledAllTheirDisplays && clb_monitors.GetItemChecked(i);
            }

            if (UserDisabledAllTheirDisplays)
            {
                MessageBox.Show("You can't disable all of your displays! Your settings were not saved.", "Error");
            }
            else
            {
                //Save button saves the form then closes it
                savePreferences();
                //close
                this.Close();
            }
            
        }

        private void b_BonbonGithub_Click(object sender, EventArgs e)
        {
            //Bonbon Github
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://github.com/nguyenkvvn/Bonbon";
            Process.Start(link.LinkData as string);
        }
    }
}
