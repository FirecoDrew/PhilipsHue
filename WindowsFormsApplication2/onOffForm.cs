using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing;

namespace WindowsFormsApplication2
{
    public partial class onOffForm : Form
    {
        public onOffForm()
        {
            InitializeComponent();
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            changeLight(true, "11");
            changeLight(true, "3");

        }

        private void changeLight(bool onLight, string lightID)
        {
            string postURL = "http://192.168.1.15/api/OvFtwPEsjav8Rf25pWrntUd7p7MBQhzyUllRch6M/lights/";
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
            changeLight(false, "3");

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
            changeLight(true, "3");

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
    }
}
