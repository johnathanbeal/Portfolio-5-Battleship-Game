using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class UserInput
    {
        public UserInput()
        { 
        
        }

        public int ProcessUserInput(BattleshipEnum rowOrColumn)
        {
            Console.WriteLine($"SELECT A {rowOrColumn.ToString().ToUpper()} NUMBER BETWEEN 1 AND 10\n");
            string rowInput = Console.ReadLine();
            int rowNumber;
            var inputIsANumber = int.TryParse(rowInput, out rowNumber);

            while(!inputIsANumber || rowNumber < 1 || rowNumber > 10)
            {
                Console.WriteLine(rowInput + " is not a valid number.");
                Console.WriteLine($"SELECT A {rowOrColumn.ToString().ToUpper()} NUMBER BETWEEN 1 AND 10\n");
                rowInput = Console.ReadLine();
                inputIsANumber = int.TryParse(rowInput, out rowNumber);
            }

            return rowNumber;
        }


    }
}
