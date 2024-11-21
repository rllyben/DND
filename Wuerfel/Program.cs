using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Wuerfel
{
    internal class Program
    {
        static List<Dice> throwList = new List<Dice>();

        static bool colorSet = false;
        static ConsoleColor coloration;
        static void Main(string[] args)
        {
            ColorSwitch();
            while (MainMenue()) ;
        }
        public static void ColorSwitch()
        {
            if (!colorSet)
                coloration = ColorSwitchSet();

            if (coloration == ConsoleColor.Black)
                Console.BackgroundColor = ConsoleColor.White;

            Console.ForegroundColor = coloration;
        }
        public static void InvertColorSwitch()
        {
            if (!colorSet)
                coloration = ColorSwitchSet();

            if (coloration == ConsoleColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
                Console.ForegroundColor = ConsoleColor.Black;

            Console.BackgroundColor = coloration;
        }
        public static ConsoleColor ColorSwitchSet()
        {
            colorSet = true;
            int selection = 0;
            string[] menueOptions = { "Black", "Blue", "Cyan", "Gray", "Green", "Magenta", "Red", "White", "Yellow" };
            ConsoleKey selectionSwitch;

            do
            {
                PrintTitle();
                Console.WriteLine(" Colorselection Menue");
                Utils.ColorSeceltionRenderMenue(menueOptions, selection);

                selectionSwitch = Console.ReadKey().Key;
                selection = Utils.UpdateSelection(selection, selectionSwitch, menueOptions);

            } while (selectionSwitch != ConsoleKey.Enter && selectionSwitch != ConsoleKey.Escape);

            switch (selection)
            {
                case 0:
                    return ConsoleColor.Black;
                case 1:
                    return ConsoleColor.Blue;
                case 2:
                    return ConsoleColor.Cyan;
                case 3:
                    return ConsoleColor.Gray;
                case 4:
                    return ConsoleColor.Green;
                case 5:
                    return ConsoleColor.Magenta;
                case 6:
                    return ConsoleColor.Red;
                case 7:
                    return ConsoleColor.White;
                case 8:
                    return ConsoleColor.Yellow;
            }
            return ConsoleColor.Gray;
        }
        static void PrintTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dungeons and Dragons Dice");
            Console.ResetColor();
            Console.WriteLine();
        }
        static bool MainMenue()
        {
            int selection = 0;
            string[] menueOptions = { "Show Previos Roles", "Rolle Dices", "Reselect Coloration", "Stop Program" };
            ConsoleKey selectionSwitch;

            do
            {
                PrintTitle();
                Console.WriteLine(" Main Menue");
                Utils.RenderMenue(menueOptions, selection);

                selectionSwitch = Console.ReadKey().Key;
                selection = Utils.UpdateSelection(selection, selectionSwitch, menueOptions);

            } while (selectionSwitch != ConsoleKey.Enter && selectionSwitch != ConsoleKey.Escape);

            switch (selection)
            {
                case 0: PrintThrowList(); break;
                case 1: DiceSelection(); break;
                case 2: colorSet = false; ColorSwitch(); break;
                case 3: return false;
            }
            return true;
        }
        static void DiceSelection()
        {
            while (true)
            {
                int selection = 0;
                string[] menueOptions = { "D100", "D20", "D12", "D10", "D8", "D6", "D4", "Back" };
                ConsoleKey selectionSwitch;

                do
                {
                    PrintTitle();
                    Console.WriteLine(" Main Menue");
                    Utils.RenderMenue(menueOptions, selection);

                    selectionSwitch = Console.ReadKey().Key;
                    selection = Utils.UpdateSelection(selection, selectionSwitch, menueOptions);

                } while (selectionSwitch != ConsoleKey.Enter && selectionSwitch != ConsoleKey.Escape);

                switch (selection)
                {
                    case 0: Dice d100 = new Dice(100); RollCountSelection(d100); break;
                    case 1: Dice d20 = new Dice(20); RollCountSelection(d20); break;
                    case 2: Dice d12 = new Dice(12); RollCountSelection(d12); break;
                    case 3: Dice d10 = new Dice(10); RollCountSelection(d10); break;
                    case 4: Dice d8 = new Dice(8); RollCountSelection(d8); break;
                    case 5: Dice d6 = new Dice(6); RollCountSelection(d6); break;
                    case 6: Dice d4 = new Dice(4); RollCountSelection(d4); break;
                    case 7: return;
                }

            }

        }
        static void PrintThrowList()
        {
            if (throwList.Count > 0)
            {
                for (int count = 0; count < throwList.Count; count++)
                {
                    Console.Write($"Dice D{throwList[count].Size}:\t");
                    for (int diceThrows = 0; diceThrows < throwList[count].Rolles.Count; diceThrows++)
                    {
                        Console.Write($"{throwList[count].Rolles[diceThrows]}, ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("You have no saved thrown dices yet!");
            }
            Console.WriteLine("\nClose this page with any Key:");
            Console.ReadKey();
        }
        static void RollCountSelection(Dice dice)
        {
            Console.WriteLine($"How often do you want to throw the D{dice.Size} Dice?\nDefault is 1\n");
            long throwCount = 0;
            while (!long.TryParse(Console.ReadLine(), out throwCount) || throwCount < 1)
            {
                throwCount = 1;
                break;
            }

            PrintTitle();
            Console.Write($"You've selectet an ");
            ColorSwitch();
            Console.Write($"D{dice.Size}");
            Console.ResetColor();
            Console.WriteLine(" Dice and throw it!\n");
            for (long count = 0; count < throwCount; count++)
            {
                DiceRoll(dice);
            }
            throwList.Add(dice);

            Console.WriteLine("\n If you like to trow the selected dice again enter Y if not just press Enter");

            char repeat = Console.ReadKey().KeyChar;
            repeat = char.ToLower(repeat);
            if (repeat == 'y')
            {
                RollCountSelection(dice);
            }

        }
        static void DiceRoll(Dice dice)
        {
            Random rnd = new Random();
            int diceThrow = rnd.Next(1, dice.Size + 1);
            Console.Write($"You rolled an ");
            ColorSwitch();
            Console.Write($"{diceThrow}");
            Console.ResetColor();
            Console.Write(" with an ");
            ColorSwitch();
            Console.Write($"D{dice.Size}");
            Console.ResetColor();
            Console.WriteLine("!");
            dice.Rolles.Add(diceThrow);
            if (dice.Rolles.Count > 100)
                dice.Rolles.RemoveAt(0);
        }

    }

}
