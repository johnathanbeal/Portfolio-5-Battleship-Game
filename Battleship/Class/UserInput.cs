using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class UserInput
    {
        GameGrid GameGrid;
        public bool inputIsANumber { get; private set; }

        public UserInput(GameGrid gameGrid)
        {
            GameGrid = gameGrid;
        }

        public int ProcessUserInput(RowOrColumn rowOrColumn, string mock = null)
        {
            var rowNumber = -1;
            inputIsANumber = false;
            do
            {
                Console.WriteLine($"SELECT A {rowOrColumn.ToString().ToUpper()} NUMBER BETWEEN 1 AND 10\n");
                var input = mock ?? Console.ReadLine();
                inputIsANumber = int.TryParse(input, out rowNumber);
                if (input == "CHEATCODE")
                {
                    DisplayCheatCode();
                    continue;
                }
                else if(inputIsANumber && rowNumber > 1 && rowNumber <= 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(input + " is not a valid number.");
                }
            } while (!inputIsANumber || rowNumber < 1 || rowNumber > 10);
            return rowNumber;
        }

        public void DisplayCheatCode()
        {           
           foreach (var coordinates in GameGrid.GivePlayerShipCoordinates())
           {
               Console.WriteLine("Coordinates " + coordinates.ToString() + " have a ship" + "\n");
           }          
        }
    }
}
