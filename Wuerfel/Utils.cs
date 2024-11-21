using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wuerfel
{
    internal class Utils
    {
        public static void ColorSeceltionRenderMenue(string[] options, int selectedIndex)
        {
            for (int count = 0; count < options.Length; count++)
            {
                if (count == selectedIndex)
                {
                    switch (options[count])
                    {
                        case "Black":
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black; break;
                        case "Blue":
                            Console.ForegroundColor = ConsoleColor.Blue; break;
                        case "Cyan":
                            Console.ForegroundColor = ConsoleColor.Cyan; break;
                        case "Gray":
                            Console.ForegroundColor = ConsoleColor.Gray; break;
                        case "Green":
                            Console.ForegroundColor = ConsoleColor.Green; break;
                        case "Magenta":
                            Console.ForegroundColor = ConsoleColor.Magenta; break;
                        case "Red":
                            Console.ForegroundColor = ConsoleColor.Red; break;
                        case "White":
                            Console.ForegroundColor = ConsoleColor.White; break;
                        case "Yellow":
                            Console.ForegroundColor = ConsoleColor.Yellow; break;
                    }
                    Console.WriteLine(options[count]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(options[count]);
            }

        }
        public static void RenderMenue(string[] options, int selectedIndex)
        {
            for (int count = 0; count < options.Length; count++)
            {
                if (count == selectedIndex)
                {
                    Program.InvertColorSwitch();
                    Console.WriteLine(options[count]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(options[count]);
            }

        }
        public static int UpdateSelection(int currentSelection, ConsoleKey key, string[] options)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    return currentSelection == 0 ? 0 : --currentSelection;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    return currentSelection == options.Length - 1 ? options.Length - 1 : ++currentSelection;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.D1:
                    return currentSelection = 0;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                case ConsoleKey.End:
                case ConsoleKey.Escape:
                    return currentSelection = options.Length - 1;
                default:
                    return currentSelection;
            }

        }
    }

}
