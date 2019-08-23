using System;

namespace Roulette
{
    class Screen
    {
        public static void Print(int x, int y, string txt, ConsoleColor color=ConsoleColor.Gray, int maxTxt= 0)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(txt.PadRight(maxTxt, ' '));
            Console.ResetColor();
        }

        public static void WinSound()
        {
            Console.Beep(440, 300);
            Console.Beep(330, 300);
            Console.Beep(440, 300);
            Console.Beep(330, 300);
            Console.Beep(440, 300);
            Console.Beep(415, 300);
            Console.Beep(415, 300);
        }

        public static void Menu(string txt)
        {
            Print(85, 1, $"Balance ${Global.Blance}", ConsoleColor.Yellow, 15);
            Print(85, 3, $"Total Bet ${Global.TotalBet}", ConsoleColor.Yellow, 15);
            Wheel wheel = new Wheel();
            Bet bet = new Bet();
            wheel.PrintBets();

            Print(0, 15, txt, ConsoleColor.Blue);
            Console.SetCursorPosition(txt.Trim().Length + 1, 15);
            string betStr = Console.ReadLine().ToUpper();//get bet number or combination

            //decimal betAmount = GetAmout();

            switch (betStr)
            {
                case "S":
                    wheel.Spin();
                    break;
                case "SPLIT":
                    bet.Betting(betStr, GetAmout(), GetBet(betStr), GetBet(betStr));
                    break;
                case "CORNER":
                    bet.Betting(betStr, GetAmout(), GetBet(betStr), GetBet(betStr), GetBet(betStr), GetBet(betStr));
                    break;
                default:
                    bet.Betting(betStr, GetAmout());
                    break;
            }
        }

        private static decimal GetAmout()
        {
            decimal amount = 0;
            string txt = "Enter the desired amount for the bet > ".PadRight(130, ' ');
            Print(0, 15, txt, ConsoleColor.Blue);
            Console.SetCursorPosition(txt.Trim().Length + 1, 15);
            txt = "Please enter a valid amount > ".PadRight(130, ' ');
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Print(0, 15, txt, ConsoleColor.Blue);
                Console.SetCursorPosition(txt.Trim().Length + 1, 15);
            }

            while (Global.Blance<amount)
            {
                txt = "You do not have enough money for this bet! Please enter anothe amout or 'exit' to end the game > ".PadRight(130, ' ');
                Print(0, 15, txt, ConsoleColor.Blue);
                Console.SetCursorPosition(txt.Trim().Length + 1, 15);
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    txt = "Please enter a valid amount > ".PadRight(130, ' ');
                    Print(0, 15, txt, ConsoleColor.Blue);
                    Console.SetCursorPosition(txt.Trim().Length + 1, 15);
                }
            }
            return amount;
        }

        private static int GetBet(string bet)
        {
            int split = -1;
            string txt = $"Enter a bet for the {bet} > ".PadRight(130, ' ');
            Print(0, 15, txt, ConsoleColor.Blue);
            Console.SetCursorPosition(txt.Trim().Length + 1, 15);
            txt= $"Please enter a valid number for {bet} > ".PadRight(130, ' ');
            while (!int.TryParse(Console.ReadLine(), out split))
            {
                Print(0, 15, txt, ConsoleColor.Blue);
                Console.SetCursorPosition(txt.Trim().Length + 1, 15);
            }
            return split;
        }
    }
}
