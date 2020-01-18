using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ra = new Random();
            GameGrid gameGrid = new GameGrid(ra);
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];
            var gameOn = gameGrid.GameOn(gameBoardBoolArray);
            
            Console.WriteLine("PLAY BATTLESHIP!");
            int turnCounter = 1;
            int hitCounter = 0;

            int outputOne = -1;
            int outputTwo = -1;

            while (turnCounter < 9 && hitCounter < 5)
            {
                Console.WriteLine("This is turn number " + turnCounter);
                
                bool inputOneIsNotVerifiedAsValid = true;
                while (inputOneIsNotVerifiedAsValid)
                {
                    Console.WriteLine("SELECT A NUMBER BETWEEN 1 AND 10");
                    
                    var firstGridPoint = Console.ReadLine();
                    if (int.TryParse(firstGridPoint, out outputOne) == true)
                    {
                        if (outputOne > 10 || outputOne < 1)
                        {
                            Console.WriteLine("You selected a number greater than 10 or less than 1.  Epic fail.");
                        }
                        {
                            inputOneIsNotVerifiedAsValid = false;
                            Console.WriteLine("You selected number " + outputOne + " for your first gridpoint for this turn");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("The input is not a whole number");
                    }
                }

                bool inputTwoIsNotVerifiedAsValid = true;
                while (inputTwoIsNotVerifiedAsValid)
                {
                    Console.WriteLine("SELECT A NUMBER BETWEEN 1 AND 10");
                    
                    var secondGridPoint = Console.ReadLine();
                    if (int.TryParse(secondGridPoint, out outputTwo) == true)
                    {
                        if (outputTwo > 10 || outputOne < 1)
                        {
                            Console.WriteLine("You selected a number greater than 10 or less than 1.  Epic fail.");
                        }
                        {
                            inputTwoIsNotVerifiedAsValid = false;
                            Console.WriteLine("You selected number " + outputTwo + " for your second gridpoint for this turn");
                        }
                    }
                }
                
                Console.WriteLine("CHECKING FOR HIT");

                bool[,,] gameResults = gameGrid.CheckForHit(gameBoardBoolArray, outputOne,outputTwo);

                if (gameResults[outputOne - 1, outputTwo - 1, gameGrid.HasAHit])
                {
                    if (gameGrid.GetAttemptsRecord(outputOne - 1, outputTwo - 1) != Hit.NoTry )
                    {
                        Console.WriteLine("You have already attempted to hit at these coordinates");
                    }
                    gameGrid.SetHitsRecord(outputOne, outputTwo, Hit.Hit);
                    hitCounter++;
                    Console.WriteLine("ITS A HIT!!!");
                }
                else if (!gameResults[outputOne - 1, outputTwo - 1, gameGrid.HasAHit])
                {
                    if (gameGrid.GetAttemptsRecord(outputOne - 1, outputTwo - 1) != Hit.NoTry)
                    {
                        Console.WriteLine("You have already attempted to hit at these coordinates");
                    }
                    gameGrid.SetHitsRecord(outputOne, outputTwo, Hit.Miss);
                    Console.WriteLine("You Missed!");
                }

                turnCounter++;
            }
            
            if (hitCounter == 5)
            {
                Console.WriteLine("You sunk my battleship!");
            }

            if (turnCounter == 8)
            {
                Console.WriteLine("GAME OVER!!!");
            }
        }
    }
}
