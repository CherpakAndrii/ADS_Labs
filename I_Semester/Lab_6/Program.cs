using System;
using System.Windows.Forms;
using Lab6.GUI;

namespace Lab6
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static bool ToMenu = true, Form1Closed, Form2Closed;
       
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (!Form1Closed && !Form2Closed)
            {
                Form2Closed = true;
                if (ToMenu)
                {
                    Form1Closed = true;
                    Application.Run(new Form1());
                }
                ToMenu = false;
                if (!Form1Closed) Application.Run(new Form2());
            }
        }
    }
}