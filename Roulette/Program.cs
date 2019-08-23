using System.Linq;

namespace Roulette
{
    public enum Color { Red, Black, Green };

    class Program
    {
        static void Main(string[] args)
        {           
            new Global();//assign a random color for numbers
            new Wheel().PrintBetsTable();
            Screen.Menu("Enter 'S' to spin the wheel or enter your bet > ".PadRight(130, ' '));
        }
    }
}
