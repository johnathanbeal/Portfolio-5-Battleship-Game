using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ra = new Random();
            GameGrid gameGrid = new GameGrid(ra);
            gameGrid.GameOn();
            Console.WriteLine("Hello World!");
        }
    }
}
