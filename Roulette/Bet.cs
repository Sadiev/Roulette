namespace Roulette
{
    class Bet
    {
        public int BetNumber { get; set; }
        public int Percent { get; set; }
        public decimal BetAmount { get; set; }
        public string BetType { get; set; }

        public void Betting(string bet, decimal betAmount, params int[] splitCorner)
        {
            if (BetAmount<=Global.Blance)
              
            switch (bet)
            {
                case "R3":
                    AddBets(3, 37, 3, 40, betAmount, bet);
                    break;
                case "R2":
                    AddBets(2, 36, 3, 40, betAmount, bet);
                    break;
                case "R1":
                    AddBets(1, 35, 3, 40, betAmount, bet);
                    break;
                case "C1":
                    AddBets(1, 4, 1, 60, betAmount, bet);
                    break;
                case "C2":
                    AddBets(4, 7, 1, 60, betAmount, bet);
                    break;
                case "C3":
                    AddBets(7, 10, 1, 60, betAmount, bet);
                    break;
                case "C4":
                    AddBets(10, 13, 1, 60, betAmount, bet);
                    break;
                case "C5":
                    AddBets(13, 16, 1, 60, betAmount, bet);
                    break;
                case "C6":
                    AddBets(16, 19, 1, 60, betAmount, bet);
                    break;
                case "C7":
                    AddBets(19, 22, 1, 60, betAmount, bet);
                    break;
                case "C8":
                    AddBets(22, 25, 1, 60, betAmount, bet);
                    break;
                case "C9":
                    AddBets(25, 28, 1, 60, betAmount, bet);
                    break;
                case "C10":
                    AddBets(28, 31, 1, 60, betAmount, bet);
                    break;
                case "C11":
                    AddBets(31, 34, 1, 60, betAmount, bet);
                    break;
                case "C12":
                    AddBets(34, 37, 1, 60, betAmount, bet);
                    break;
                case "C13":
                    AddBets(1, 7, 1, 50, betAmount, bet);
                    break;
                case "C14":
                    AddBets(7, 13, 1, 50, betAmount, bet);
                    break;
                case "C15":
                    AddBets(13, 19, 1, 50, betAmount, bet);
                    break;
                case "C16":
                    AddBets(19, 25, 1, 50, betAmount, bet);
                    break;
                case "C17":
                    AddBets( 25, 31, 1, 50, betAmount, bet);
                    break;
                case "C18":
                    AddBets(31, 37, 1, 50, betAmount, bet);
                    break;
                case "A":
                    AddBets(1,13,1,40,betAmount,bet);
                    break;
                case "B":
                    AddBets(13, 25, 1, 40, betAmount, bet);
                    break;
                case "C":
                    AddBets(25, 37, 1, 40, betAmount, bet);
                    break;
                case "L":
                    AddBets(1, 19, 1, 30, betAmount, bet);
                    break;
                case "H":
                    AddBets(19, 37, 1, 30, betAmount, bet);
                    break;
                case "00":
                    AddBets(37, 38, 1, 100, betAmount, bet);
                    break;
                case "RED": 
                    AddBets(Color.Red, bet, 50, betAmount);
                    break;
                case "BLACK":
                    AddBets(Color.Black, bet, 50, betAmount);
                    break;
                case "ODD": case "EVEN":
                        AddBets(1, 37, 1, 50, betAmount, bet);
                    break;
                case "SPLIT": case "CORNER":
                        AddBets(bet, betAmount, splitCorner);
                        break;
                    default:
                    if (int.TryParse(bet, out int number))
                    {
                        if (number >= 0 && number<=36)
                        {
                            Global.Bets.Add(new Bet() { BetNumber = number, Percent = 100, BetAmount = betAmount, BetType = bet });
                            Global.Blance -= betAmount;
                            Global.TotalBet += betAmount;
                            Screen.Menu("Enter 'S' to spin the wheel or enter another bet > ".PadRight(130, ' '));
                           
                        }
                    }
                        Screen.Menu("NOT a valide bet! Enter 'S' to spin the wheel or enter a bet > ".PadRight(130, ' '));
                 break;
            }
            else
                Screen.Menu("Sorry you don't have enough money! Enter 'S' to spin the wheel or enter a bet > ".PadRight(130, ' '));

        }
        void AddBets(int begin, int end, int step, int percent, decimal betAmount, string bet)
        {
            Bet temp;
            for (int i = begin; i < end; i+=step)
            {
                switch (bet)
                {
                    case "ODD":
                        if (i % 2 == 0) continue;
                        break;
                    case "EVEN":
                        if (i % 2 != 0) continue;
                        break;
                    default:
                        break;
                }
                temp = Global.Bets.Find(x => x.BetType == bet && x.BetNumber == i);
                if (temp==null)
                {
                    Global.Bets.Add(new Bet() { BetNumber = i, Percent = percent, BetAmount = betAmount, BetType = bet });
                }
                else
                {
                    temp.BetAmount += betAmount;
                }
            }
            Global.Blance -= betAmount;
            Global.TotalBet += betAmount;
            Screen.Menu("Enter 'S' to spin the wheel or enter another bet > ".PadRight(130, ' '));
        }

        void AddBets(Color c, string bet, int percent, decimal betAmount)//Color bets
        {
            Bet temp=null;
            for (int i = 1; i < Global.BetNumbers.Length; i++)
            {
                if (Global.BetNumbers[i] == c)
                { 
                temp = Global.Bets.Find(x => x.BetType == bet && x.BetNumber == i);
                if (temp == null)
                {
                    Global.Bets.Add(new Bet() { BetNumber = i, Percent = percent, BetAmount = betAmount, BetType = bet });
                }
                else
                {
                    temp.BetAmount += betAmount;
                }
                }
            }
            Global.Blance -= betAmount;
            Global.TotalBet += betAmount;
            Screen.Menu("Enter 'S' to spin the wheel or enter another bet > ".PadRight(130, ' '));
        }

        void AddBets(string bet, decimal betAmount, params int[] splitCorner)//SPLIT and CORNER
        {
            Bet temp = null;
            for (int i = 0; i < splitCorner.Length; i++)
            {               
                temp = Global.Bets.Find(x => x.BetType == bet && x.BetNumber == splitCorner[i]);
                if (temp == null)
                {
                    Global.Bets.Add(new Bet() { BetNumber = splitCorner[i], Percent = bet=="SPLIT"?90:80, BetAmount = betAmount, BetType = bet });
                }
                else
                {
                    temp.BetAmount += betAmount;
                }
            }
            Global.Blance -= betAmount;
            Global.TotalBet += betAmount;
            Screen.Menu("Enter 'S' to spin the wheel or enter another bet > ".PadRight(130, ' '));
        }
    }
}
