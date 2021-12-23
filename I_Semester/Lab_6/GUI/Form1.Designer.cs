using Lab6.GUI.Stylization;

namespace Lab6.GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = Style.ButtonBgColor;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = Style.ButtonFont;
            this.button1.ForeColor = Style.ButtonFgColor;
            this.button1.Location = Locations.Button1StartLocation;
            this.button1.Name = "button1";
            this.button1.Size = Style.GmModeButtonSz;
            this.button1.TabIndex = 0;
            this.button1.Text = "1 player";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ChooseGmMode);
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.BackColor = Style.LabelBgColor;
            this.label1.Font = Style.F1LabelBigFont;
            this.label1.ForeColor = Style.LabelFgColor;
            this.label1.Location = Locations.Label1StartLocation;
            this.label1.Name = "label1";
            this.label1.Size = Style.Label1Sz;
            this.label1.TabIndex = 1;
            this.label1.Text = "Pig!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = Style.ButtonBgColor;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = Style.ButtonFont;
            this.button2.ForeColor = Style.ButtonFgColor;
            this.button2.Location = Locations.Button2StartLocation;
            this.button2.Name = "button2";
            this.button2.Size = Style.GmModeButtonSz;
            this.button2.TabIndex = 2;
            this.button2.Text = "2 players\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ChooseGmMode);
            // 
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = false;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = Style.Form1WindowSz;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chomp";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Chomp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;

        public System.Windows.Forms.Label label1;

        #endregion
    }
}