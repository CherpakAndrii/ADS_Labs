using System;
using System.Windows.Forms;
using Lab5.Algo;

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
            if (sender is Button button)
            {
                button.BackColor = gm.MoveCtr % 2 == 0
                    ? Style.P1SelectedCellColor
                    : Style.P2SelectedCellColor;
                button.Text = Convert.ToString(gm.MoveCtr % 2 + 1);
                gm.Colored++;
                button.Click -= MakeChoice;
                
                string[] coordinates = button.Name.Split("; ", StringSplitOptions.RemoveEmptyEntries);
                int i = int.Parse(coordinates[0]);
                int j = int.Parse(coordinates[1]);
                for (int ctrI = i; ctrI < Game.FieldSize - 1; ctrI++)
                {
                    for (int ctrJ = j; ctrJ < Game.FieldSize; ctrJ++)
                    {
                        if (ctrI==i && ctrJ==j) continue;
                        if (Field[ctrI, ctrJ].BackColor == Style.EmptyCellColor)
                        {
                            Field[ctrI, ctrJ].BackColor = gm.MoveCtr % 2 == 0
                                ? Style.P1PassiveSelectedCellColor
                                : Style.P2PassiveSelectedCellColor;
                            gm.Colored++;
                            Field[ctrI, ctrJ].Enabled = false;
                        }
                    }
                }
                gm.MoveDone(i, j);
                button.Refresh();
                if (gm.Colored >= (Game.FieldSize - 1) * Game.FieldSize - 1)
                {
                    GameOver(Field[0, 0], EventArgs.Empty);
                }
                else if (gm.MoveCtr % 2 == 1 && Game.SinglePlay) gm.MakeMove();
            }
        }
        private void GameOver(object sender, EventArgs e)
        {
            int winner = gm.MoveCtr%2==0 ? 2 : 1;
            Controls.Clear();
            Controls.Add(button1);
            Controls.Add(button2);
            label1.Text = $@"Player{winner} wins!";
            Controls.Add(label1);
        }
        private void ToMenu(object sender, EventArgs e)
        {
            Program.ToMenu = true;
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