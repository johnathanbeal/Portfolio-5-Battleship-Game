using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class UserInput
    {
        GameGrid GameGrid;

        public UserInput(GameGrid gameGrid)
        {
            GameGrid = gameGrid;
        }

        public int ProcessUserInput(RowOrColumn rowOrColumn)
        {
            int rowNumber = -1;
            var inputIsValid = false;
            while (!inputIsValid)
            {
                Console.WriteLine($"SELECT A {rowOrColumn.ToString().ToUpper()} NUMBER BETWEEN 1 AND 10\n");
                string input = Console.ReadLine();
                if (input == "CHEATCODE")
                {
                    DisplayCheatCode();
                    continue;
                }
               
                var inputIsANumber = int.TryParse(input, out rowNumber);

                while ((!inputIsANumber || rowNumber < 1 || rowNumber > 10) && input != "CHEATCODE")
                {
                    Console.WriteLine(input + " is not a valid number.");
                    Console.WriteLine($"SELECT A {rowOrColumn.ToString().ToUpper()} NUMBER BETWEEN 1 AND 10\n");
                    input = Console.ReadLine();
                    inputIsANumber = int.TryParse(input, out rowNumber);
                }
                inputIsValid = true;
            }
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
