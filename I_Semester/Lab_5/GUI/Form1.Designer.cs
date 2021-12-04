namespace Lab5.GUI
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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            Style.UpdateForm1ElementSize();
            // 
            // button1
            // 
            this.button1.BackColor = Style.ButtonBgColor;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = Style.ButtonFont;
            this.button1.ForeColor = Style.ButtonFgColor;
            this.button1.Location = new System.Drawing.Point(265, 280);
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
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = Style.LabelFgColor;
            this.label1.Location = new System.Drawing.Point(265, 128);
            this.label1.Name = "label1";
            this.label1.Size = Style.Label1Sz;
            this.label1.TabIndex = 1;
            this.label1.Text = "Chomp!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = Style.ButtonBgColor;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = Style.ButtonFont;
            this.button2.ForeColor = Style.ButtonFgColor;
            this.button2.Location = new System.Drawing.Point(452, 280);
            this.button2.Name = "button2";
            this.button2.Size = Style.GmModeButtonSz;
            this.button2.TabIndex = 2;
            this.button2.Text = "2 players\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ChooseGmMode);
            // 
            // Form1
            //
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.Form1_SizeChanged);
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

        private void ReloadComponent()
        {
            // 
            // button3
            // 
            this.button3.BackColor = Style.ButtonBgColor;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = Style.ButtonFont;
            this.button3.ForeColor = Style.ButtonFgColor;
            this.button3.Location = new System.Drawing.Point(Style.FieldSzButtonX, 100);
            this.button3.Name = "button3";
            this.button3.Size = Style.FieldSzButtonSz;
            this.button3.TabIndex = 3;
            this.button3.Text = "5x4";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ChooseSize);
            // 
            // button4
            // 
            this.button4.BackColor = Style.ButtonBgColor;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = Style.ButtonFont;
            this.button4.ForeColor = Style.ButtonFgColor;
            this.button4.Location = new System.Drawing.Point(Style.FieldSzButtonX, 165);
            this.button4.Name = "button4";
            this.button4.Size = Style.FieldSzButtonSz;
            this.button4.TabIndex = 4;
            this.button4.Text = "6x5";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.ChooseSize);
            // 
            // button5
            // 
            this.button5.BackColor = Style.ButtonBgColor;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = Style.ButtonFont;
            this.button5.ForeColor = Style.ButtonFgColor;
            this.button5.Location = new System.Drawing.Point(Style.FieldSzButtonX, 230);
            this.button5.Name = "button5";
            this.button5.Size = Style.FieldSzButtonSz;
            this.button5.TabIndex = 5;
            this.button5.Text = "7x6";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.ChooseSize);
            // 
            // button6
            // 
            this.button6.BackColor = Style.ButtonBgColor;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = Style.ButtonFont;
            this.button6.ForeColor = Style.ButtonFgColor;
            this.button6.Location = new System.Drawing.Point(Style.FieldSzButtonX, 295);
            this.button6.Name = "button6";
            this.button6.Size = Style.FieldSzButtonSz;
            this.button6.TabIndex = 6;
            this.button6.Text = "8x7";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.ChooseSize);
            this.Controls.Clear();
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
        }

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        

        private System.Windows.Forms.Label label1;
        
        #endregion
    }
}