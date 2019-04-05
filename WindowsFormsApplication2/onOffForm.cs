using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApplication2
{
    public partial class onOffForm : Form
    {
        bool lightsAreOff;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public onOffForm()
        {
            InitializeComponent();
            int id = 0;     // The id of the hotkey. 
            RegisterHotKey(this.Handle, id, (int)KeyModifier.Shift + (int)KeyModifier.Control, Keys.L.GetHashCode());       // Register Shift + A as global hotkey. 
            lightsAreOff = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                if (lightsAreOff)
                {
                    changeLight(true, "11");
                    changeLight(true, "12");
                    changeLight(true, "13");
                    changeLight(true, "14");
                    lightsAreOff = false;
                }
                else
                {
                    changeLight(false, "11");
                    changeLight(false, "12");
                    changeLight(false, "13");
                    changeLight(false, "14");
                    lightsAreOff = true;
                }
            }
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            changeLight(true, "11");
            changeLight(true, "12");
            changeLight(true, "13");
            changeLight(true, "14");

        }

        private void changeLight(bool onLight, string lightID)
        {
            string postURL = "http://192.168.1.121/api/OvFtwPEsjav8Rf25pWrntUd7p7MBQhzyUllRch6M/lights/";
            postURL += lightID;
            postURL += "/state";

            var uri = new Uri(postURL);
            var state = new
            {
                on = onLight,
                bri = (int)brightnessTrackBar.Value,
                hue = Properties.Settings.Default.hue,
                sat = Properties.Settings.Default.saturation,
            };

            var jsonObj = JsonConvert.SerializeObject(state);

            var client = new WebClient();
            client.UploadStringAsync(uri, "PUT", jsonObj);
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            changeLight(false, "11");
            changeLight(false, "12");
            changeLight(false, "13");
            changeLight(false, "14");

        }

        private void colourSelectButton_Click(object sender, EventArgs e)
        {
            int[] customValues;
            ColorDialog colourDialog = new ColorDialog();
            if (Properties.Settings.Default.customValues == "")
            {
                customValues = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                string customColours = arrayString(customValues);
                Properties.Settings.Default.customValues = customColours;
            }
            else
            {
                customValues = stringArray(Properties.Settings.Default.customValues);
            }
            colourDialog.CustomColors = customValues;
            DialogResult result = colourDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Properties.Settings.Default.customValues = arrayString(colourDialog.CustomColors);
                Color setColour = colourDialog.Color;
                this.BackColor = colourDialog.Color;
                int hue = Convert.ToUInt16(setColour.GetHue() * 65536/360);
                int brightness = Convert.ToInt16(setColour.GetBrightness() * 255);
                int saturation = Convert.ToInt16(setColour.GetSaturation() * 255);
                Properties.Settings.Default.hue = hue;
                Properties.Settings.Default.brightness = brightness;
                Properties.Settings.Default.saturation = saturation;
                Properties.Settings.Default.formColour = colourDialog.Color;
                brightnessTrackBar.Value = brightness;
                Properties.Settings.Default.Save();
            }
            changeLight(true, "11");
            changeLight(true, "12");
            changeLight(true, "13");
            changeLight(true, "14");

        }

        private string arrayString(int[] stringValues)
        {
            return String.Join(",", stringValues.Select(i => i.ToString()).ToArray());
        }

        private int[] stringArray(string stringValues)
        {
            return stringValues.Split(',').Select(s => Int32.Parse(s)).ToArray();
            
        }

        private void onOffForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void brightnessTrackBar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void onOffForm_Load(object sender, EventArgs e)
        {
            brightnessTrackBar.Value = Properties.Settings.Default.brightness;
            this.BackColor = Properties.Settings.Default.formColour;
        }

        private void brightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.brightness = brightnessTrackBar.Value;
            changeLight(true, "11");
            changeLight(true, "3");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show("What the Ctrl+F?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
