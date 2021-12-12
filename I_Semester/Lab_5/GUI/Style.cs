using System.Drawing;

namespace Lab5.GUI
{
    public static class Style
    {
        public static Color ButtonBgColor = Color.BlueViolet;
        public static Color ButtonFgColor = Color.AntiqueWhite;
        public static Color LabelBgColor = Color.BlueViolet;
        public static Color LabelFgColor = Color.AntiqueWhite;
        public static Color EmptyCellColor = Color.AntiqueWhite;
        public static Color P1SelectedCellColor = Color.DarkBlue;
        public static Color P1PassiveSelectedCellColor = Color.RoyalBlue;
        public static Color P2SelectedCellColor = Color.Red;
        public static Color P2PassiveSelectedCellColor = Color.PaleVioletRed;
        public static Color PoisonBgColor = Color.Black;
        public static Font PoisonFont = new ("Comic Sans MS", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
        public static Size FieldSzButtonSz = new (250, 60);
        public static Size GmModeButtonSz = new (183, 50);
        public static Size CellSize = new (50, 50);
        
        public static Size Label1Sz = new (370, 135);
        public static Size Form1WindowSz = new (900, 500);
        public static Font ButtonFont = new ("Comic Sans MS", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 204);
        public static Font F1LabelBigFont = new ("Comic Sans MS", 72F, FontStyle.Italic, GraphicsUnit.Point, 204);
        public static Font F2LabelFont = new ("Comic Sans MS", 25F, FontStyle.Italic, GraphicsUnit.Point, 204);

        
        public static void UpdateForm1ElementSize()
        {
            FieldSzButtonSz = new (GetNewForm1ElementWidth(245), GetNewForm1ElementHeight(60));
            GmModeButtonSz = new (GetNewForm1ElementWidth(185), GetNewForm1ElementHeight(50));
            Label1Sz = new (GetNewForm1ElementWidth(370), GetNewForm1ElementHeight(135));
            CellSize = new(GetNewForm1ElementWidth(50), GetNewForm1ElementHeight(50));
        }

        public static int GetNewForm1ElementWidth(int w)
        {
            return (int)(Form1WindowSz.Width*((double)w/900));
        }
        
        public static int GetNewForm1ElementHeight(int h)
        {
            return (int)(Form1WindowSz.Height*((double)h/500));
        }
    }
}