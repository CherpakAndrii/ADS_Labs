using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab5.GUI
{
    public static class Locations
    {
        public static Point Button1StartLocation = new(265, 280);
        public static Point Button2StartLocation = new(452, 280);
        public static Point Button3StartLocation = new(325, 100);
        public static Point Button4StartLocation = new(325, 165);
        public static Point Button5StartLocation = new(325, 230);
        public static Point Button6StartLocation = new(325, 295);
        public static Point Label1StartLocation = new(265, 128);
        public static Point Cell00StartLocation = new(265, 128);
        private static readonly Dictionary<string, Point> StartLocations = new ();

        public static void SetStartLocations()
        {
            if (StartLocations.Count == 0)
            {
                StartLocations.Add("button1", Button1StartLocation);
                StartLocations.Add("button2", Button2StartLocation);
                StartLocations.Add("button3", Button3StartLocation);
                StartLocations.Add("button4", Button4StartLocation);
                StartLocations.Add("button5", Button5StartLocation);
                StartLocations.Add("button6", Button6StartLocation);
                StartLocations.Add("button7", Button3StartLocation);
                StartLocations.Add("button8", Button4StartLocation);
                StartLocations.Add("button9", Button5StartLocation);
                StartLocations.Add("button10", Button6StartLocation);
                StartLocations.Add("label1", Label1StartLocation);
            }
        }
        public static void Relocate(/*ref*/ Button but)
        {
            but.Location = new Point(Style.GetNewForm1ElementWidth(StartLocations[but.Name].X), Style.GetNewForm1ElementHeight(StartLocations[but.Name].Y));
        }
        
        public static void Relocate(Label lbl)
        {
            lbl.Location = new Point(Style.GetNewForm1ElementWidth(StartLocations[lbl.Name].X), Style.GetNewForm1ElementHeight(StartLocations[lbl.Name].Y));
        }
    }
}