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
            Console.WriteLine("Dungeons and Dragons Würfel");
            Console.ResetColor();
            Console.WriteLine();
            ColorSwitch();

            while (gamerun)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dungeons and Dragons Würfel");
                Console.ResetColor();

                _wuerfel = "0";

                while (_wuerfel == "0")
                {
                    Console.WriteLine();
                    Console.WriteLine("Welchen Würfel willst du würfeln?");
                    Console.WriteLine("D100, D20, D12, D10, D8, D6, D4");
                    _wuerfel = Console.ReadLine();
                    _wuerfel = _wuerfel.ToLower();

                    switch (_wuerfel)
                    {
                        case "101": for (int count = 0; count < 101; count++) { Console.Write("."); } _wuerfel = "0";  break;
                        case "d100":
                        case "100": _wuerfel = "d100"; Wuerfe(); break;
                        case "d20":
                        case "20": _wuerfel = "d20"; Wuerfe(); break;
                        case "d12":
                        case "12": _wuerfel = "d12"; Wuerfe(); break;
                        case "d10":
                        case "10": _wuerfel = "d10"; Wuerfe(); break;
                        case "d8":
                        case "8": _wuerfel = "d8"; Wuerfe(); break;
                        case "d6":
                        case "6": _wuerfel = "d6"; Wuerfe(); break;
                        case "d4": 
                        case "4": _wuerfel = "d4"; Wuerfe(); break;
                        default: Console.WriteLine("Falsche Eingabe!"); _wuerfel = "0"; break;
                    }

                }

            }

        }

        // Farb setzungs Methode
        static void ColorSwitch()
        {
            if (_color == "false")
            {
                Console.WriteLine("Wähle deine Würfel Farbe:");
                Console.WriteLine("Blau, Cyan, Gruen, Rot, Lila, Gelb, Weiss");

                bool colorChange = true;
                while (colorChange)
                {
                    _color = Console.ReadLine();
                    _color = _color.ToLower();

                    switch (_color)
                    {
                        case "bl":
                        case "blau": Console.ForegroundColor = ConsoleColor.Blue; colorChange = false; _color = "blau"; break;
                        case "cy":
                        case "cyan": Console.ForegroundColor = ConsoleColor.Cyan; colorChange = false; _color = "cyan"; break;
                        case "gr":
                        case "gruen": Console.ForegroundColor = ConsoleColor.Green; colorChange = false; _color = "gruen"; break;
                        case "r":
                        case "rot": Console.ForegroundColor = ConsoleColor.Red; colorChange = false; _color = "rot"; break;
                        case "li":
                        case "lila": Console.ForegroundColor = ConsoleColor.Magenta; colorChange = false; _color = "lila"; break;
                        case "ge":
                        case "gelb": Console.ForegroundColor = ConsoleColor.Yellow; colorChange = false; _color = "gelb"; break;
                        case "we":
                        case "weiss": Console.ForegroundColor = ConsoleColor.White; colorChange = false; _color = "weiss"; break;
                        case "schwarz": Console.ForegroundColor= ConsoleColor.Black; colorChange = false; _color = "schwarz"; break;
                        default: Console.WriteLine("Falsche Eingabe"); break;
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
                    default: Console.WriteLine("Fehler beim Laden der Würfelfarbe! Bitte gib deine Würfelfarbe erneut an!"); _color = "false"; ColorSwitch(); break;
                }

            }

        }
        // Methode für die Anzahl der Würfe
        static void Wuerfe()
        {
            int wuerfe = 0;
            while (wuerfe == 0)
            {
                Console.WriteLine("Wie offt willst du deinen Würfel werfen?");
                try
                {
                    wuerfe = int.Parse(Console.ReadLine());
                }
                catch
                {
                    wuerfe = 0;
                    Console.WriteLine("Falsche Eingabe!");
                    Console.WriteLine();
                }

            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dungeons and Dragons Würfel");
            int summe = 0;
            for (int count = 0; count < wuerfe; count++)
            {
                int reture = 0;
                switch (_wuerfel)
                {
                    case "d100": reture = D100(); break;
                    case "d20": reture = D20(); break;
                    case "d12": reture = D12(); break;
                    case "d10": reture = D10(); break;
                    case "d8": reture = D8(); break;
                    case "d6": reture = D6(); break;
                    case "d4": reture = D4(); break;
                }
                summe += reture;
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.Write("Die Summe ist ");
            ColorSwitch();
            Console.WriteLine(summe);

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Willst du den Würfel erneut werfen?");
            Console.WriteLine("J/N");
            string reroll = Console.ReadLine();
            reroll = reroll.ToLower();
            switch (reroll)
            {
                case "ja":
                case "j": Wuerfe(); break;
                case "nein":
                case "n": break;
                default: break;
            }

        }
        // Würfel Methoden
        static int D100()
        {
            Random d100 = new Random();

            ColorSwitch();
            Console.WriteLine();

            int wurf = d100.Next(1, 101);
            Console.WriteLine(wurf);

            return wurf;
        }
        static int D20()
        {
            Random d20 = new Random();

            ColorSwitch();
            Console.WriteLine();

            int wurf = d20.Next(1, 21);
            Console.WriteLine(wurf);
            return wurf;
        }
        static int D12()
        {
            Random d12 = new Random();

            ColorSwitch();
            Console.WriteLine();

            int wurf = d12.Next(1, 13);
            Console.WriteLine(wurf);
            return wurf;
        }
        static int D10()
        {
            Random d10 = new Random();

            ColorSwitch();
            Console.WriteLine();

            int wurf = d10.Next(1, 11);
            Console.WriteLine(wurf);
            return wurf;
        }
        static int D8()
        {
            Random d8 = new Random();

            ColorSwitch();
            Console.WriteLine();

            int wurf = d8.Next(1, 9);
            Console.WriteLine(wurf);
            return wurf;
        }
        static int D6()
        {
            Random d6 = new Random();

            ColorSwitch();
            Console.WriteLine();

            int wurf = d6.Next(1, 7);
            Console.WriteLine(wurf);
            return wurf;
        }
        static int D4()
        {
            Random d4 = new Random();

            ColorSwitch();
            Console.WriteLine();

            int wurf = d4.Next(1, 5);
            Console.WriteLine(wurf);
            return wurf;
        }

    }

}
