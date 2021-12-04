using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5.GUI
{
    public partial class Form1 : Form
    {
        /*private bool singlePlay;
        private int fieldSize;*/
        public Form1()
        {
            InitializeComponent();
        }

        private void Chomp_Load(object sender, EventArgs e)
        {
            
        }

        private void ChooseGmMode(object sender, EventArgs e)
        {
            Button Bt = sender as Button;
            Program.singlePlay = (Bt.Name=="button1");
            /*button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;*/
            ReloadComponent();
            /*label1.Enabled = false;
            label1.Visible = false;*/
        }
        private void HideAll()
        {
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
            button5.Enabled = false;
            button5.Visible = false;
            button6.Enabled = false;
            button6.Visible = false;
            label1.Enabled = false;
            label1.Visible = false;
        }

        private void ChooseSize(object sender, EventArgs e)
        {
            Button Bt = sender as Button;
            Program.fieldSize = (Bt.Name=="button3"?5:Bt.Name=="button4"?6:Bt.Name=="button5"?7:8);
            Close();
        }
        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Style.Form1WindowSz = ClientSize;
            Style.UpdateForm1ElementSize();
            UpdateForm1ElementLocation();
        }
        
        private void UpdateForm1ElementLocation(){
            button1.Size = Style.GmModeButtonSz;
            button2.Size = Style.GmModeButtonSz;
            button3.Size = Style.FieldSzButtonSz;
            button4.Size = Style.FieldSzButtonSz;
            button5.Size = Style.FieldSzButtonSz;
            button6.Size = Style.FieldSzButtonSz;
            label1.Size = Style.Label1Sz;
            Style.Relocate(ref button1);
            Style.Relocate(ref button2);
            Style.Relocate(ref button3);
            Style.Relocate(ref button4);
            Style.Relocate(ref button5);
            Style.Relocate(ref button6);
            Style.Relocate(ref label1);
        }

        
    }
}