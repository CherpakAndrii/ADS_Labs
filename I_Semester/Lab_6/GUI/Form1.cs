using System;
using System.Windows.Forms;
using Lab6.Algo;

namespace Lab6.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Chomp_Load(object sender, EventArgs e)
        {
            
        }

        private void ChooseGmMode(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Game.SinglePlay = (button.Name == "button1");
                Program.Form1Closed = false;
                Close();
            }
        }
    }
}