using System;
using System.Windows.Media;

namespace ServerManagerFramework
{
    /// <summary>
    /// Server Manager Resources
    /// </summary>
    public static class SMR
    {
        /// <summary>
        /// Path for resources inside the project folder
        /// </summary>
        public static string DataPath => "pack://application:,,,/";
        /// <summary>
        /// Path to the folder where the Application is installed in
        /// </summary>
        public static string AppDirectory => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 
        /// </summary>
        public static Color Transparent => new();
        /// <summary>
        /// 
        /// </summary>
        public static Color Hover => new() { R = 255, G = 255, B = 255, A = 31 };
        /// <summary>
        /// 
        /// </summary>
        public static Color White => new() { R = 255, G = 255, B = 255, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Red => new() { R = 212, G = 68, B = 16, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color RedHover => new() { R = 231, G = 100, B = 58, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Stopping => new() { R = 188, G = 45, B = 0, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Green => new() { R = 0, G = 133, B = 64, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color GreenHover => new() { R = 13, G = 209, B = 100, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Starting => new() { R = 0, G = 107, B = 53, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Input => new() { R = 18, G = 18, B = 18, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color InputHover => new() { R = 14, G = 14, B = 14, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color DarkGray => new() { R = 30, G = 30, B = 30, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Gray => new() { R = 40, G = 40, B = 40, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color LightGray => new() { R = 48, G = 48, B = 48, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color FontColor => new() { R = 204, G = 204, B = 204, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color GrayHover => new() { R = 69, G = 69, B = 69, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Line => new() { R = 55, G = 55, B = 55, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color ScrollBarThumbHover => new() { R = 99, G = 99, B = 99, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Brightness1 => new() { R = 78, G = 78, B = 78, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Brightness2 => new() { R = 89, G = 89, B = 89, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Brightness3 => new() { R = 111, G = 111, B = 111, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Brightness4 => new() { R = 114, G = 114, B = 114, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Brightness5 => new() { R = 138, G = 138, B = 138, A = 255 };
        /// <summary>
        /// 
        /// </summary>
        public static Color Brightness6 => new() { R = 209, G = 209, B = 209, A = 255 };

        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush TransparentBrush => new(Transparent);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush HoverBrush => new(Hover);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush WhiteBrush => new(White);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush RedBrush => new(Red);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush RedHoverBrush => new(RedHover);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush StoppingBrush => new(Stopping);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush GreenBrush => new(Green);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush GreenHoverBrush => new(GreenHover);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush StartingBrush => new(Starting);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush InputBrush => new(Input);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush InputHoverBrush => new(InputHover);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush DarkGrayBrush => new(DarkGray);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush GrayBrush => new(Gray);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush LightGrayBrush => new(LightGray);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush FontColorBrush => new(FontColor);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush GrayHoverBrush => new(GrayHover);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush LineBrush => new(Line);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush ScrollBarThumbHoverBrush => new(ScrollBarThumbHover);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush Brightness1Brush => new(Brightness1);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush Brightness2Brush => new(Brightness2);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush Brightness3Brush => new(Brightness3);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush Brightness4Brush => new(Brightness4);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush Brightness5Brush => new(Brightness5);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush Brightness6Brush => new(Brightness6);

        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush transparentBrush = new(Transparent);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush hoverBrush = new(Hover);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush whiteBrush = new(White);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush redBrush = new(Red);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush redHoverBrush = new(RedHover);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush stoppingBrush = new(Stopping);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush greenBrush = new(Green);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush greenHoverBrush = new(GreenHover);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush startingBrush = new(Starting);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush inputBrush = new(Input);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush inputHoverBrush = new(InputHover);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush darkGrayBrush = new(DarkGray);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush grayBrush = new(Gray);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush lightGrayBrush = new(LightGray);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush fontColorBrush = new(FontColor);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush grayHoverBrush = new(GrayHover);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush lineBrush = new(Line);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush scrollBarThumbHoverBrush = new(ScrollBarThumbHover);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush brightness1Brush = new(Brightness1);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush brightness2Brush = new(Brightness2);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush brightness3Brush = new(Brightness3);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush brightness4Brush = new(Brightness4);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush brightness5Brush = new(Brightness5);
        /// <summary>
        /// 
        /// </summary>
        private static readonly SolidColorBrush brightness6Brush = new(Brightness6);
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush STransparentBrush => transparentBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SHoverBrush => hoverBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SWhiteBrush => whiteBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SRedBrush => redBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SRedHoverBrush => redHoverBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SStoppingBrush => stoppingBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SGreenBrush => greenBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SGreenHoverBrush => greenHoverBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SStartingBrush => startingBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SInputBrush => inputBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SInputHoverBrush => inputHoverBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SDarkGrayBrush => darkGrayBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SGrayBrush => grayBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SLightGrayBrush => lightGrayBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SFontColorBrush => fontColorBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SGrayHoverBrush => grayHoverBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SLineBrush => lineBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SScrollBarThumbHoverBrush => scrollBarThumbHoverBrush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SBrightness1Brush => brightness1Brush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SBrightness2Brush => brightness2Brush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SBrightness3Brush => brightness3Brush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SBrightness4Brush => brightness4Brush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SBrightness5Brush => brightness5Brush;
        /// <summary>
        /// 
        /// </summary>
        public static SolidColorBrush SBrightness6Brush => brightness6Brush;
    }
}
