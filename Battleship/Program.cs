using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ra = new Random();
            GameGrid gameGrid = new GameGrid(ra);
            bool[,,] boolArray = new bool[10, 10, 2];
            var gameOn = gameGrid.GameOn(boolArray);
            var KeepPlaying = true;
            
            Console.WriteLine("PLAY BATTLESHIP!");
            int turnCounter = 0;
            while(KeepPlaying)
            {
                Console.WriteLine("This is turn number " + turnCounter);
                Console.WriteLine("SELECT A FIRST POINT ON THE GRID");
                var firstGridPoint = Console.ReadLine();
                Console.WriteLine("SELECT A SECOND POINT ON THE GRID");
                var secondGridPoint = Console.ReadLine();
                int outputOne;
                if(int.TryParse(firstGridPoint, out outputOne) == true)
                {
                    Console.WriteLine("You selected number ");
                }
                int outputTwo;
                if (int.TryParse(secondGridPoint, out outputTwo) == true)
                {
                    Console.WriteLine("You selected number ");
                }
                gameGrid.CheckForHit(boolArray,outputOne,outputTwo);
                Console.WriteLine("CHECKING FOR HIT");
                turnCounter++;
            }
            
            
        }
    }
}
