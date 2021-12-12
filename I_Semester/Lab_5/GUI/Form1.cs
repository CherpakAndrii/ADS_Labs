using System;
using System.Windows.Forms;

namespace Lab5.GUI
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
            Button button = sender as Button;
            if (button != null)
            {
                Program.SinglePlay = (button.Name == "button1");
                ReloadComponent();
            }
        }

        private void ChooseSize(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Program.FieldSize = (button.Name == "button3" ? 5 :
                    button.Name == "button4" ? 6 :
                    button.Name == "button5" ? 7 : 8);
                if (Program.SinglePlay) ReloadComponent2();
                else
                {
                    Program.Form1Closed = false;
                    Close();
                }
            }
        }

        private void ChooseDifficulty(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Program.Difficulty = (button.Name == "button7" ? 1 :
                    button.Name == "button8" ? 2 :
                    button.Name == "button9" ? 3 : 4);
            }
            Program.Form1Closed = false;
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
            Locations.Relocate(button1);
            Locations.Relocate(button2);
            Locations.Relocate(button3);
            Locations.Relocate(button4);
            Locations.Relocate(button5);
            Locations.Relocate(button6);
            Locations.Relocate(button7);
            Locations.Relocate(button8);
            Locations.Relocate(button9);
            Locations.Relocate(button10);
            Locations.Relocate(label1);
        }

        
    }
}