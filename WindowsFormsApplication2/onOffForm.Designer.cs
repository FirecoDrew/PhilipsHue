namespace WindowsFormsApplication2
{
    partial class onOffForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(onOffForm));
            this.onButton = new System.Windows.Forms.Button();
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.offButton = new System.Windows.Forms.Button();
            this.colourSelectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // onButton
            // 
            this.onButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onButton.Image = ((System.Drawing.Image)(resources.GetObject("onButton.Image")));
            this.onButton.Location = new System.Drawing.Point(12, 12);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(235, 237);
            this.onButton.TabIndex = 0;
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // brightnessTrackBar
            // 
            this.brightnessTrackBar.Location = new System.Drawing.Point(12, 330);
            this.brightnessTrackBar.Maximum = 255;
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size(370, 45);
            this.brightnessTrackBar.TabIndex = 1;
            this.brightnessTrackBar.Scroll += new System.EventHandler(this.brightnessTrackBar_Scroll);
            this.brightnessTrackBar.ValueChanged += new System.EventHandler(this.brightnessTrackBar_ValueChanged);
            // 
            // offButton
            // 
            this.offButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offButton.Location = new System.Drawing.Point(253, 12);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(129, 237);
            this.offButton.TabIndex = 0;
            this.offButton.Text = "Off";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // colourSelectButton
            // 
            this.colourSelectButton.Image = ((System.Drawing.Image)(resources.GetObject("colourSelectButton.Image")));
            this.colourSelectButton.Location = new System.Drawing.Point(12, 255);
            this.colourSelectButton.Name = "colourSelectButton";
            this.colourSelectButton.Size = new System.Drawing.Size(370, 59);
            this.colourSelectButton.TabIndex = 2;
            this.colourSelectButton.UseVisualStyleBackColor = true;
            this.colourSelectButton.Click += new System.EventHandler(this.colourSelectButton_Click);
            // 
            // onOffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 387);
            this.Controls.Add(this.colourSelectButton);
            this.Controls.Add(this.brightnessTrackBar);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.onButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "onOffForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onOffForm_FormClosing);
            this.Load += new System.EventHandler(this.onOffForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.Button colourSelectButton;
    }
}

