using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            GameGrid gameGrid = new GameGrid(random);
            ControlFlow ControlF = new ControlFlow(gameGrid);
            UserInput userInput = new UserInput();

            ControlF.GameOn(userInput);
            
        }
    }
}
