using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Wuerfel
{
    internal class Program
    {
        static string _wuerfel = "0";
        static string _color = "false";
        static void Main(string[] args)
        {
            bool gamerun = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dungeons and Dragons Dice");
            Console.ResetColor();
            Console.WriteLine();
            ColorSwitch();

            while (gamerun)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dungeons and Dragons Dice");
                Console.ResetColor();

                _wuerfel = "0";

                while (_wuerfel == "0")
                {
                    Console.WriteLine();
                    Console.WriteLine("what dice do you want to throw?");
                    Console.WriteLine("D100[1], D20[2], D12[3], D10[5], D8[7], D6[6], D4[4]");
                    _wuerfel = Console.ReadLine();
                    _wuerfel = _wuerfel.ToLower();

                    switch (_wuerfel)
                    {
                        case "101": for (int count = 0; count < 101; count++) { Console.Write("."); } _wuerfel = "0";  break;
                        case "1":
                        case "d100":
                        case "100": _wuerfel = "d100"; Wuerfe(); break;
                        case "2":
                        case "d20":
                        case "20": _wuerfel = "d20"; Wuerfe(); break;
                        case "3":
                        case "d12":
                        case "12": _wuerfel = "d12"; Wuerfe(); break;
                        case "5":
                        case "d10":
                        case "10": _wuerfel = "d10"; Wuerfe(); break;
                        case "7":
                        case "d8":
                        case "8": _wuerfel = "d8"; Wuerfe(); break;
                        case "d6":
                        case "6": _wuerfel = "d6"; Wuerfe(); break;
                        case "d4": 
                        case "4": _wuerfel = "d4"; Wuerfe(); break;
                        default: Console.WriteLine("wrong input!"); _wuerfel = "0"; break;
                    }

                }

            }

        }

        // Farb setzungs Methode
        public static void ColorSwitch()
        {
            if (_color == "false")
            {
                Console.WriteLine("what dicecolor do you want to have:");
                Console.WriteLine("blue, cyan, green, red, magenta, yellow, white");

                bool colorChange = true;
                while (colorChange)
                {
                    _color = Console.ReadLine();
                    _color = _color.ToLower();

                    if (_color == "b" || _color == "bl" || _color == "blu" || _color == "blue")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; colorChange = false; _color = "blau";
                    }
                    else if (_color == "c" || _color == "cy" || _color == "cya" || _color == "cyan")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan; colorChange = false; _color = "cyan";
                    }
                    else if (_color == "g" || _color == "gr" || _color == "gre" || _color == "gree" || _color == "green")
                    {
                        Console.ForegroundColor = ConsoleColor.Green; colorChange = false; _color = "gruen";
                    }
                    else if (_color == "r" || _color == "re" || _color == "red")
                    {
                        Console.ForegroundColor = ConsoleColor.Red; colorChange = false; _color = "rot";
                    }
                    else if (_color == "m" || _color == "ma" || _color == "mag" || _color == "mage" || _color == "magen" || _color == "magent" || _color == "magenta")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta; colorChange = false; _color = "lila";
                    }
                    else if (_color == "y" || _color == "ye" || _color == "yel" || _color == "yell" || _color == "yello" || _color == "yellow")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; colorChange = false; _color = "gelb";
                    }
                    else if (_color == "w" || _color == "wh" || _color == "whi" || _color == "whit" || _color == "white")
                    {
                        Console.ForegroundColor = ConsoleColor.White; colorChange = false; _color = "weiss";
                    }
                    else if (_color == "black")
                    {
                        Console.ForegroundColor = ConsoleColor.Black; colorChange = false; _color = "schwarz";
                    }
                    else
                    { 
                        Console.WriteLine("wrong input!");
                    }

                }

            }
            else
            {
                switch (_color)
                {
                    case "blau": Console.ForegroundColor = ConsoleColor.Blue; break;
                    case "cyan": Console.ForegroundColor = ConsoleColor.Cyan; break;
                    case "gruen": Console.ForegroundColor = ConsoleColor.Green; break;
                    case "rot": Console.ForegroundColor = ConsoleColor.Red; break;
                    case "lila": Console.ForegroundColor = ConsoleColor.Magenta; break;
                    case "gelb": Console.ForegroundColor = ConsoleColor.Yellow; break;
                    case "weiss": Console.ForegroundColor = ConsoleColor.White; break;
                    case "schwarz": Console.ForegroundColor = ConsoleColor.Black; break;
                    default: Console.WriteLine("Error while reading dicecolor! Please set again!"); _color = "false"; ColorSwitch(); break;
                }

            }

        }
        // Methode für die Anzahl der Würfe
        static void Wuerfe()
        {
            Dice d100 = new Dice(100);
            Dice d20 = new Dice(20);
            Dice d12 = new Dice(12);
            Dice d10 = new Dice(10);
            Dice d8 = new Dice(8);
            Dice d6 = new Dice(6);
            Dice d4 = new Dice(4);

            int wuerfe = 1;
            while (wuerfe == 0)
            {
                Console.WriteLine("How many times do you want to throw your dice? (Default = 1)");
                try
                {
                    wuerfe = int.Parse(Console.ReadLine());
                }
                catch
                {
                    wuerfe = 0;
                    Console.WriteLine("Wrong input!");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (wuerfe < 50)
                {
                    string rlly;
                    Console.WriteLine($"Do you really want to roll {wuerfe} times?");
                    Console.WriteLine("Y/N");
                    bool run = true;
                    while (run)
                    {
                        rlly = Console.ReadLine();
                        rlly = rlly.ToLower();

                        switch (rlly)
                        {
                            case "n":
                            case "no": wuerfe = 0; run = false; break;
                            case "y": 
                            case "yes": run = false; break;
                            default: Console.WriteLine("wrong input!"); Console.ReadKey(); Console.Clear(); break;
                        }

                    }

                }

            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dungeons and Dragons Dice");
            int summe = 0;
            for (int count = 0; count < wuerfe; count++)
            {
                int reture = 0;
                switch (_wuerfel)
                {
                    case "d100": reture = d100.Wuerfel(); break;
                    case "d20": reture = d20.Wuerfel(); break;
                    case "d12": reture = d12.Wuerfel(); break;
                    case "d10": reture = d10.Wuerfel(); break;
                    case "d8": reture = d8.Wuerfel(); break;
                    case "d6": reture = d6.Wuerfel(); break;
                    case "d4": reture = d4.Wuerfel(); break;
                }
                summe += reture;
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.Write("The Summe is ");
            ColorSwitch();
            Console.WriteLine(summe);

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Do you want to throw THIS dice again?");
            Console.WriteLine("Y/N");
            string reroll = Console.ReadLine();
            reroll = reroll.ToLower();
            switch (reroll)
            {
                case "yes":
                case "y": Wuerfe(); break;
                case "no":
                case "n": break;
                default: break;
            }

        }


    }
    // Würfel Klasse
    public class Dice
    {
        int _dice;
        public Dice(int max) { _dice = max + 1; }
        public int Wuerfel()
        {
            Random zahl = new Random();

            Program.ColorSwitch();
            Console.WriteLine();

            int wurf = zahl.Next(1, 101);
            Console.WriteLine(wurf);

            return wurf;
        }

    }

}
