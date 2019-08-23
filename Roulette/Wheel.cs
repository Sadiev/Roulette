using System;
using System.Threading;

namespace Roulette
{
    class Wheel
    {
        public void Spin()
        {
            Random rand = new Random();
            int winNumber = -1;
            int sleepTime = 5;
            for (int i = 0; i < 20; i++)
            {
                winNumber =rand.Next(0, 37);
                Screen.Print(85, 5, $"-=>>> {winNumber} <<<=-", ConsoleColor.Magenta, 15);
                Console.Beep(494, 300);
                Thread.Sleep(sleepTime);
                sleepTime += 5;
            }
            Screen.WinSound();
            decimal winTotal = 0;
            foreach (var bet in Global.Bets)
            {
                if (bet.BetNumber == winNumber)
                {
                    winTotal +=((bet.Percent*bet.BetAmount)/100)+bet.BetAmount;
                }
            }
            Screen.Print(85, 7, $"You won ${winTotal}", ConsoleColor.Magenta, 15);
            Global.Blance += winTotal;
            Global.TotalBet = 0;
            Global.Bets.Clear();
            Screen.Menu("Enter 'S' to spin the wheel or enter your bet > ".PadRight(130, ' '));
        }
        public void PrintBets()
        {
            Screen.Print(110, 1, "Your bets:", ConsoleColor.Yellow);
            for (int i = 0; i < 13; i++)
            {
                Screen.Print(110, Console.CursorTop + 1, new string(' ', 25));
            }
            Console.SetCursorPosition(110, 2);
            //foreach (var bet in Global.Bets.Select(x => new { x.BetType, x.BetAmount }).Distinct())
            //{
            //    Screen.Print(110, Console.CursorTop + 1, $"Pleced {bet.BetAmount} on {bet.BetType}");
            //}
            foreach (var bet in Global.Bets)
            {
                Console.SetCursorPosition(110, Console.CursorTop + 1);
                Console.Write($"Pleced {bet.BetAmount} on {bet.BetType} - {bet.BetNumber}");
            }
        }
        
        public void PrintBetsTable()
        {
            Console.SetCursorPosition(0, 2);
            for (int i = 1; i < Global.BetNumbers.Length; i++)
            {
                Console.BackgroundColor = (Global.BetNumbers[i] == Color.Red) ? ConsoleColor.Red : ConsoleColor.Black;
                Console.Write($"  {i}".PadRight(6, ' '));
                if (Console.CursorTop == 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft, 2);
                }
                else
                {
                    Console.SetCursorPosition(Console.CursorLeft - 6, Console.CursorTop - 1);
                }
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" - R1");
            Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop - 1);
            Console.Write(" - R2");
            Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop - 1);
            Console.Write(" - R3");

            Console.SetCursorPosition(0, 3);
            Console.ResetColor();

            Console.WriteLine("                  0                 |                 00                 ");

            Console.WriteLine(new string('=', 73));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* C1  | C2  | C3  | C4  | C5  | C6  | C7  | C8  | C9  | C10 | C11 | C12 *");
            Console.WriteLine(new string('*', 73));
            Console.WriteLine("*   C13     |    C14    |    C15    |    C16    |    C17    |    C18    *");
            Console.WriteLine(new string('*', 73));
            Console.WriteLine("*     1 to 12 - A       |     13 to 24 - B      |     25 to 36 - C      *");


            Console.WriteLine(new string('*', 73));
            Console.WriteLine("*           1 to 18 - L             |             19 to 36 - H          *");

            Console.WriteLine(new string('*', 73));
            Console.WriteLine("*  RED   |    BLACK   |   ODD   |    EVEN    |    SPLIT    |    CORNER  *");

            Console.WriteLine(new string('*', 73));
            //Console.WriteLine("Numbers: the number of the bin");
            //Console.WriteLine("Evens / Odds: even or odd numbers");
            //Console.WriteLine("Reds / Blacks: red or black colored numbers");
            //Console.WriteLine("Lows / Highs: low(1 – 18) or high(19 – 38) numbers.");
            //Console.WriteLine("Dozens: row thirds, 1 – 12, 13 – 24, 25 – 36");
            //Console.WriteLine("Columns: first, second, or third columns");
            //Console.WriteLine("Street: rows, e.g., 1 / 2 / 3 or 22 / 23 / 24");
            //Console.WriteLine("Numbers: double rows, e.g., 1 / 2 / 3 / 4 / 5 / 6 or 22 / 23 / 24 / 25 / 26 / 26");
            //Console.WriteLine("Split: at the edge of any two contiguous numbers, e.g., 1 / 2, 11 / 14, and 35 / 36");
            //Console.WriteLine("Corner: at the intersection of any four contiguous numbers, e.g., 1 / 2 / 4 / 5, or 23 / 24 / 26 / 27");
        }

    }
}
