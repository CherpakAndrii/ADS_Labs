using System;
using System.Windows.Forms;

namespace Lab5.GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Chomp_Load(object sender, EventArgs e)
        {
            
        }

        public void MakeChoice(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = gm.movectr % 2 == 0
                    ? Style.P1SelectedCellColor
                    : Style.P2SelectedCellColor;
                button.Text = Convert.ToString(gm.movectr % 2 + 1);
                gm.colored++;
                button.Click -= MakeChoice;
                
                string[] Coordinates = button.Name.Split("; ", StringSplitOptions.RemoveEmptyEntries);
                int I = int.Parse(Coordinates[0]);
                int J = int.Parse(Coordinates[1]);
                for (int i = I; i < Program.FieldSize - 1; i++)
                {
                    for (int j = J; j < Program.FieldSize; j++)
                    {
                        if (i==I && j==J) continue;
                        if (Field[i, j].BackColor == Style.EmptyCellColor)
                        {
                            Field[i, j].BackColor = gm.movectr % 2 == 0
                                ? Style.P1PassiveSelectedCellColor
                                : Style.P2PassiveSelectedCellColor;
                            gm.colored++;
                            Field[i, j].Enabled = false;
                        }
                    }
                }
                gm.movectr++;
                if (gm.colored >= (Program.FieldSize - 1) * Program.FieldSize - 1)
                {
                    Refresh();
                    GameOver(Field[0, 0], EventArgs.Empty);
                }
                else if (gm.movectr % 2 == 1 && Program.SinglePlay)
                {
                    switch (Program.Difficulty)
                    {
                        case 1: 
                            gm.MoveE(this);
                            break;
                        case 2: 
                            gm.MoveN();
                            break;
                        case 3: 
                            gm.MoveH();
                            break;
                        case 4: 
                            gm.MoveI();
                            break;
                    }
                   
                }
            }
        }
        private void GameOver(object sender, EventArgs e)
        {
            int winner = gm.movectr%2==0 ? 2 : 1;
            Controls.Clear();
            Controls.Add(button1);
            Controls.Add(button2);
            label1.Text = $"Player{winner} wins!";
            Controls.Add(label1);
        }
        private void ToMenu(object sender, EventArgs e)
        {
            Program.toMenu = true;
            Program.Form2Closed = false;
            Close();
        }
        
        private void Restart(object sender, EventArgs e)
        {
            Program.Form2Closed = false;
            Close();
        }
    }
}