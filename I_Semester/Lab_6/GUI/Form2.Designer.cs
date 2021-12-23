using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lab6.Algo;
using Lab6.GUI.Stylization;

namespace Lab6.GUI
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            rand = new();
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
            this.button1.TabIndex = 9;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ToMenu);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.BlueViolet;
            this.label1.Font = Style.ButtonFont;
            this.label1.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.label1.Location = Locations.Label1StartLocation;
            this.label1.Name = "label1";
            this.label1.Size = Style.Label1Sz;
            this.label1.TabIndex = 10;
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
            this.button2.TabIndex = 11;
            this.button2.Text = "Restart";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Restart);
            // 
            // label2
            // 
            this.label2.BackColor = Style.P1MoveColor;
            this.label2.Font = Style.LeftPanelFont;
            this.label2.ForeColor = Style.LeftPanelFgColor;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = Style.LeftPanelStandardLabelSize;
            this.label2.TabIndex = 0;
            this.label2.Text = "Player1\'s score: 0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = Style.P2MoveColor;
            this.label3.Font = Style.LeftPanelFont;
            this.label3.ForeColor = Style.LeftPanelFgColor;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = Style.LeftPanelStandardLabelSize;
            this.label3.TabIndex = 1;
            this.label3.Text = "Player2\'s score: 0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = Style.P1MoveColor;
            this.label4.Font = Style.LeftPanelFont;
            this.label4.ForeColor = Style.LeftPanelFgColor;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = Style.LeftPanelStandardLabelSize;
            this.label4.TabIndex = 2;
            this.label4.Text = "Current player:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.BackColor = Style.P1MoveColor;
            this.label5.Font = Style.LeftPanelFont;
            this.label5.ForeColor = Style.LeftPanelFgColor;
            this.label5.Location = new System.Drawing.Point(12, 190);
            this.label5.Name = "label5";
            this.label5.Size = Style.LeftPanelStandardLabelSize;
            this.label5.TabIndex = 3;
            this.label5.Text = "Player1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = Style.P1MoveColor;
            this.label6.Font = Style.LeftPanelFont;
            this.label6.ForeColor = Style.LeftPanelFgColor;
            this.label6.Location = new System.Drawing.Point(12, 253);
            this.label6.Name = "label6";
            this.label6.Size = Style.LeftPanel2LineLabelSize;
            this.label6.TabIndex = 4;
            this.label6.Text = "Current player\'s score:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            this.label7.BackColor = Style.P1MoveColor;
            this.label7.Font = Style.LeftPanelFont;
            this.label7.ForeColor = Style.LeftPanelFgColor;
            this.label7.Location = new System.Drawing.Point(12, 306);
            this.label7.Name = "label7";
            this.label7.Size = Style.LeftPanelStandardLabelSize;
            this.label7.TabIndex = 5;
            this.label7.Text = "0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button3
            // 
            this.button3.BackColor = Style.P1MoveColor;
            this.button3.Font = Style.LeftPanelFont;
            this.button3.ForeColor = Style.LeftPanelFgColor;
            this.button3.Location = Locations.Button3StartLocation;
            this.button3.Name = "button3";
            this.button3.Size = Style.LeftPanelButtonSize;
            this.button3.TabIndex = 6;
            this.button3.Text = "Throw the dice";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Throw);
            // 
            // button4
            // 
            this.button4.BackColor = Style.P1MoveColor;
            this.button4.Font = Style.LeftPanelFont;
            this.button4.ForeColor = Style.LeftPanelFgColor;
            this.button4.Location = Locations.Button4StartLocation;
            this.button4.Name = "button4";
            this.button4.Size = Style.LeftPanelButtonSize;
            this.button4.TabIndex = 7;
            this.button4.Text = "Skip";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Skip);
            // 
            // button5
            // 
            this.button5.BackColor = Style.LeftPanelBgColor;
            this.button5.Font = Style.LeftPanelFont;
            this.button5.ForeColor = Style.LeftPanelFgColor;
            this.button5.Location = Locations.Button5StartLocation;
            this.button5.Name = "button5";
            this.button5.Size = Style.LeftPanelButtonSize;
            this.button5.TabIndex = 8;
            this.button5.Text = "Give up";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.GiveUp);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = Style.Form1WindowSz;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pig";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Chomp_Load);
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.Button button3, button4, button5;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1, button2;
        private System.Windows.Forms.Label label1, label2, label3, label4, label6, label7;
        private Game gm;
        private Random rand;

        #endregion
    }
}