using System.Drawing;
using System.Windows.Forms;

namespace Lab5.GUI
{
    public static class Style
    {
        public static Color ButtonBgColor = Color.BlueViolet;
        public static Color ButtonFgColor = Color.AntiqueWhite;
        public static Color LabelBgColor = Color.BlueViolet;
        public static Color LabelFgColor = Color.AntiqueWhite;
        public static Size FieldSzButtonSz = new (250, 60);
        public static Size GmModeButtonSz = new (183, 50);
        public static Size Label1Sz = new (370, 135);
        public static Size Form1WindowSz = new (900, 500);
        public static int FieldSzButtonX = 325;
        public static Font ButtonFont = new ("Comic Sans MS", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 204);
        
        public static void UpdateForm1ElementSize()
        {
            FieldSzButtonSz = new (getNewForm1ElementWidth(245), getNewForm1ElementHeight(60));
            GmModeButtonSz = new (getNewForm1ElementWidth(185), getNewForm1ElementHeight(50));
            Label1Sz = new (getNewForm1ElementWidth(370), getNewForm1ElementHeight(135));
            FieldSzButtonX = Form1WindowSz.Width / 2 - FieldSzButtonSz.Width / 2;
        }

        public static int getNewForm1ElementWidth(int w)
        {
            return (int)(Form1WindowSz.Width*((double)w/900));
        }
        
        public static int getNewForm1ElementHeight(int h)
        {
            return (int)(Form1WindowSz.Height*((double)h/500));
        }
        
        public static void Relocate(ref Button Element)
        {
            int currentX = Element.Location.X;
            int currentY = Element.Location.Y;
            Element.Location = new Point(Style.getNewForm1ElementWidth(currentX), Style.getNewForm1ElementHeight(currentY));
        }
        
        public static void Relocate(ref Label Element)
        {
            int currentX = Element.Location.X;
            int currentY = Element.Location.Y;
            Element.Location = new Point(Style.getNewForm1ElementWidth(currentX), Style.getNewForm1ElementHeight(currentY));
        }
    }
}