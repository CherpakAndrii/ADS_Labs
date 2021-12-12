using System;
using System.Windows.Forms;
using Lab5.GUI;

namespace Lab5
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static bool SinglePlay, toMenu = true, Form1Closed = false, Form2Closed = false;
        public static int FieldSize;
        public static int Difficulty;
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (!Form1Closed && !Form2Closed)
            {
                Form2Closed = true;
                if (toMenu)
                {
                    Form1Closed = true;
                    Application.Run(new Form1());
                }
                toMenu = false;
                if (!Form1Closed) Application.Run(new Form2());
               
            }
        }
    }
}