using System;
using System.Windows.Forms;
using Lab6.Algo;
using Lab6.GUI.Stylization;

namespace Lab6.GUI
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
        
        private void GameOver(object sender, EventArgs e)
        {
            int winner = gm.P2Score >= 100 ? 2 : 1;
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

        public void Skip(object sender, EventArgs e)
        {
            if (gm.MoveCtr % 2 == 1) gm.P1Score += gm.CurrentMoveScore;
            else gm.P2Score += gm.CurrentMoveScore;
            gm.CurrentMoveScore = 0;
            gm.MoveCtr++;
            label7.Text = "0";
            label2.Text = $"Player1's score: {gm.P1Score}";
            label3.Text = $"Player2\'s score: {gm.P2Score}";
            label5.Text = $"Player{(gm.MoveCtr%2==1 ? 1 : 2)}";
            label4.BackColor = label5.BackColor = label6.BackColor = label7.BackColor = button3.BackColor =
                button4.BackColor = (gm.MoveCtr % 2 == 1 ? Style.P1MoveColor : Style.P2MoveColor);
            Refresh();
            if (gm.P1Score >= 100 || gm.P2Score >= 100) GameOver(sender, e);
            else if (Game.SinglePlay && gm.MoveCtr % 2 == 0) gm.MakeMove();
        }
        
        private void GiveUp(object sender, EventArgs e)
        {
            gm.P2Score = 101;
            GameOver(sender, e);
        }

        public void Throw(object sender, EventArgs e)
        {
            int r = rand.Next(1, 7);
            MessageBox.Show($"Dice choice: {r}");
            if (r == 1)
            {
                gm.CurrentMoveScore = 0;
                Skip(sender, e);
            }
            else
            {
                gm.CurrentMoveScore += r;
                label7.Text = "" + gm.CurrentMoveScore;
                Refresh();
            }
        }
    }
}