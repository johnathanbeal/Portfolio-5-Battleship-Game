using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Battleship
{
    class Program
    {
        static Random random;
        static GameGrid gameGrid;
        static ControlFlow ControlF;
        static UserInput userInput;

        static void Main(string[] args)
        {
            random = new Random();
            gameGrid = new GameGrid(random);
            ControlF = new ControlFlow(gameGrid);
            userInput = new UserInput(gameGrid);

            Console.WriteLine("PLAY BATTLESHIP!\n");
            StartGame(userInput);
            
        }

        public static void StartGame(UserInput userInput)
        {
            while (ControlF.TurnCounter < 9 && ControlF.HitCounter < 5)
            {
                int rowNumber;
                int columnNumber;

                Console.WriteLine("This is turn number " + ControlF.TurnCounter + "\n");

                rowNumber = userInput.ProcessUserInput(RowOrColumn.Row);

                columnNumber = userInput.ProcessUserInput(RowOrColumn.Column);

                var shipWasHit = gameGrid.CheckForHit(rowNumber, columnNumber);
                Console.WriteLine(ControlF.ShipWasHit(shipWasHit));

                ControlF.TurnCounter++;
            }

            Console.WriteLine(ControlF.DisplayGameResults());
        }
    }
}
