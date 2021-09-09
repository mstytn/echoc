using System;
using System.Linq;

namespace echoc
{
    public static class HelpDisplay
    {
        /// <summary>
        /// Just displays help for echoc command.
        /// </summary>
        public static void ShowHelp()
        {
            //Store current background & foreground color
            ConsoleColor f = Console.ForegroundColor;
            ConsoleColor b = Console.BackgroundColor;
            Console.WriteLine(" Usage:");
            Console.WriteLine("   echoc -c:foreground:background SOMETEXT SOME OTHER TEXT -r SOME NORMAL TEXT");
            Console.WriteLine("      -f:foregroundcolor -b:backgroundcolor only changes dedicated color.");
            Console.WriteLine("        to change both use -c:foreground:background");
            Console.WriteLine("   i.e: echoc -c:2:14 Some text -f:4 some other text -r normal text");
            Console.Write("        echoc ");
            Console.ForegroundColor = (ConsoleColor)2;
            Console.BackgroundColor = (ConsoleColor)14;
            Console.Write("Some text");
            Console.BackgroundColor = b;
            Console.ForegroundColor = (ConsoleColor)4;
            Console.Write(" some other text");
            Console.BackgroundColor = b;
            Console.ForegroundColor = f;
            Console.Write(" normal text");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Other oprtions:");
            Console.WriteLine("      -s Removes white space before the word when parsing as string.");
            Console.WriteLine("      -r Resets the default color.".PadLeft(3));
            Console.WriteLine("      -w Prints white space.".PadLeft(3));
            Console.WriteLine("      -w:count Prints white space in count quantity.");
            Console.WriteLine("");
            var n = Enum.GetNames(typeof(ConsoleColor)).ToArray<string>();
            Console.WriteLine("Color Codes:");
            for (var i = 0; i < n.Length; i++)
            {
                Console.WriteLine($"   {i,2}:   {n[i]}");
            }

        }
    }
}