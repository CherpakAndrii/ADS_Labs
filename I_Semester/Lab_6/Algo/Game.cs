using System;
using System.Threading;
using Lab6.GUI;

namespace Lab6.Algo
{
    public class Game
    {
        public static bool SinglePlay;
        public int MoveCtr, P1Score, P2Score, CurrentMoveScore;
        private readonly Form2 _form;

         public Game(Form2 form)
         {
             _form = form;
             MoveCtr = 1;
             P1Score = 0;
             P2Score = 0;
             CurrentMoveScore = 0;
         }
         
         public void MakeMove()
         {
             int throwCtr = 0;
             _form.button3.Visible = _form.button4.Visible = _form.button5.Visible = false;
             while (MoveCtr % 2 == 0 && ChooseThrowOrNot(throwCtr))
             {
                 if (MoveCtr % 2 == 1) return;
                 Thread.Sleep(1500);
                 _form.Throw(_form.button3, EventArgs.Empty);
                 throwCtr++;
             }
             if (MoveCtr % 2 == 0) _form.Skip(_form.button3, EventArgs.Empty);
             _form.button3.Visible = _form.button4.Visible = _form.button5.Visible = true;
         }
         
         private bool ChooseThrowOrNot(int ctr)
         {
             if (P2Score + CurrentMoveScore >= 100) return false;
             return Math.Pow(5.0/6, ctr)*(1-CurrentMoveScore/20) > 0.5;
         }
    }
}