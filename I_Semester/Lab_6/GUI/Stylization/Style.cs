using System.Drawing;

namespace Lab6.GUI.Stylization
{
    public static class Style
    {
        public static Color ButtonBgColor = Color.BlueViolet;
        public static Color ButtonFgColor = Color.AntiqueWhite;
        public static Color LabelBgColor = Color.BlueViolet;
        public static Color LabelFgColor = Color.AntiqueWhite;
        public static Color LeftPanelBgColor = Color.BlueViolet;
        public static Color LeftPanelFgColor = Color.AntiqueWhite;
        public static Color P1MoveColor = Color.Navy;
        public static Color P2MoveColor = Color.RoyalBlue;
        public static Size GmModeButtonSz = new (183, 50);
        public static Size LeftPanelStandardLabelSize = new (179, 36);
        public static Size LeftPanelButtonSize = new (177, 46);
        public static Size LeftPanel2LineLabelSize = new (179, 53);
        
        public static Size Label1Sz = new (370, 135);
        public static Size Form1WindowSz = new (900, 500);
        
        public static readonly Font LeftPanelFont = new ("Comic Sans MS", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
        public static readonly Font ButtonFont = new ("Comic Sans MS", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 204);
        public static readonly Font F1LabelBigFont = new ("Comic Sans MS", 72F, FontStyle.Italic, GraphicsUnit.Point, 204);
    }
}