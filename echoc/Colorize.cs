using System;

namespace echoc
{
    public static class Colorize
    {
        public static bool FirstWord { get; private set; } = true;
        public static ConsoleColor DefaultForegroundColor { get; set; } = Console.ForegroundColor;
        public static ConsoleColor DefaultBackgroundColor { get; set; } = Console.BackgroundColor;

        public static void Run(string[] args)
        {
            ResetCursorPosIfNeeded();
            foreach (var arg in args)
            {
                if (arg.StartsWith("-c"))
                {
                    ColorizeConsole(arg);
                }
                else if (arg.StartsWith("-f"))
                {
                    ColorizeConsole(arg, ColorizeType.Foreground);
                }
                else if (arg.StartsWith("-b"))
                {
                    ColorizeConsole(arg, ColorizeType.Background);
                }
                else if (string.Equals(arg, "-r", StringComparison.OrdinalIgnoreCase))
                {
                    Reset();
                }
                else if (string.Equals(arg, "-s", StringComparison.OrdinalIgnoreCase))
                {
                    FirstWord = true;
                }
                else if (arg.StartsWith("-w"))
                {
                    GiveSomeSpace(arg);
                }
                else
                {
                    WriteToConsole(arg);
                }
            }
            Reset();
            Console.WriteLine();
        }

        private static void ResetCursorPosIfNeeded()
        {
            if (Console.CursorLeft > 0)
                Console.WriteLine();
        }

        private static void ColorizeConsole(string cArg, ColorizeType colorizeType = ColorizeType.Both)
        {
            var cols = Array.Empty<string>();
            switch (colorizeType)
            {
                case ColorizeType.Both:
                    cols = cArg.Split(':');
                    if (cols.Length > 1)
                    {
                        if (cols.Length == 3)
                        {
                            if (GetColorFromString(cols[1], cols[2], out ConsoleColor[] oColor))
                            {
                                Spacer();
                                Console.ForegroundColor = oColor[0];
                                Console.BackgroundColor = oColor[1];
                            }
                        }
                    }
                    break;
                case ColorizeType.Foreground:
                    cols = cArg.Split(':');
                    if (cols.Length > 1)
                    {
                        if (cols.Length == 2)
                        {
                            if (GetColorFromString(cols[1], DefaultForegroundColor, out ConsoleColor of))
                            {
                                Spacer();
                                Console.ForegroundColor = of;
                            }
                        }
                    }
                    break;
                case ColorizeType.Background:
                    cols = cArg.Split(':');
                    if (cols.Length > 1)
                    {
                        if (cols.Length == 2)
                        {
                            if (GetColorFromString(cols[1], DefaultBackgroundColor, out ConsoleColor ob))
                            {
                                Spacer();
                                Console.BackgroundColor = ob;
                            }
                        }
                    }
                    break;
            }
        }

        private static void Spacer()
        {
            if (!FirstWord) { Console.Write(" "); FirstWord = true; }
        }

        private static bool GetColorFromString(string fc, string bc, out ConsoleColor[] color)
        {
            ConsoleColor _fc;
            ConsoleColor _bc;
            color = new ConsoleColor[] { DefaultForegroundColor , DefaultBackgroundColor };
            if (Int32.TryParse(fc, out int colf))
            {
                if (colf < 16 && colf > -1)
                {
                    _fc = (ConsoleColor)colf;
                    if (Int32.TryParse(bc, out int colb))
                    {
                        if (colb < 16 && colb > -1)
                        {
                            _bc = (ConsoleColor)colb;
                            color = new ConsoleColor[] { _fc, _bc };
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static void GiveSomeSpace(string arg)
        {
            if (arg.Contains(":"))
            {
                var w = arg.Split(':');
                if (w.Length > 1)
                {
                    if (Int32.TryParse(w[1], out int whitesp))
                    {
                        Console.Write("".PadLeft(whitesp));
                    }
                }
            }
            else { Console.Write(" "); }
        }

        private static bool GetColorFromString(string c, ConsoleColor def, out ConsoleColor color)
        {
            color = def;
            if (Int32.TryParse(c, out int col))
            {
                if (col < 16 && col > -1)
                {
                    color = (ConsoleColor)col;
                    return true;
                }
            }
            return false;
        }

        private static void WriteToConsole(string arg)
        {
            Spacer();
            Console.Write(arg);
            FirstWord = false;
        }

        public static void Reset()
        {
            Console.ForegroundColor = DefaultForegroundColor;
            Console.BackgroundColor = DefaultBackgroundColor;
        }
    }

    public enum ColorizeType
    {
        Both,
        Foreground,
        Background
    }
}
