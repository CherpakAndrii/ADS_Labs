using System.Collections.Generic;
using System.Windows.Forms;
using Lab5.Algo;

namespace Lab5.GUI
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            gm = new(this);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            Field = new Button[Game.FieldSize - 1, Game.FieldSize];
            for (int i = 0; i < Game.FieldSize - 1; i++)
            {
                for (int j = 0; j < Game.FieldSize; j++)
                {
                    Field[i, j] = new Button();
                    Field[i,j].Cursor = System.Windows.Forms.Cursors.Hand;
                    Field[i,j].ForeColor = Style.ButtonFgColor;
                    Field[i,j].Location = new System.Drawing.Point(
                        Locations.Cell00StartLocation.X+(Style.CellSize.Width+1)*j, 
                        Locations.Cell00StartLocation.Y+(Style.CellSize.Height+1)*i);
                    Field[i,j].Name = $"{i}; {j}";
                    Field[i,j].Size = Style.CellSize;
                    Field[i,j].TabIndex = i*(Game.FieldSize-1) + j + 1;
                    Field[i,j].UseVisualStyleBackColor = false;
                    if (!(i==0 && j==0))
                    {
                        Field[i, j].BackColor = Style.EmptyCellColor;
                        Field[i, j].Text = "";
                        Field[i, j].Font = Style.ButtonFont;
                        Field[i, j].Click += new System.EventHandler(this.MakeChoice);
                    }
                    this.Controls.Add(Field[i,j]);
                }
            }
            
            Field[0, 0].BackColor = Style.PoisonBgColor;
            Field[0, 0].Font = Style.PoisonFont;
            Field[0, 0].Text = "Lose";
            Field[0, 0].Click += new System.EventHandler(this.GameOver);
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
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ToMenu);
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.BackColor = Style.LabelBgColor;
            this.label1.Font = Style.F2LabelFont;
            this.label1.ForeColor = Style.LabelFgColor;
            this.label1.Location = Locations.Label1StartLocation;
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
            this.button2.Location = Locations.Button2StartLocation;
            this.button2.Name = "button2";
            this.button2.Size = Style.GmModeButtonSz;
            this.button2.TabIndex = 2;
            this.button2.Text = "Restart";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Restart);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = Style.Form1WindowSz;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chomp";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Chomp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        public System.Windows.Forms.Button[,] Field;

        private System.Windows.Forms.Button button1, button2;
        private System.Windows.Forms.Label label1;
        private Game gm;
        #endregion
    }
}