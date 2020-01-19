using System;
using System.Drawing;

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
                    else if (firstGridPoint == "CHEATCODE")
                    {
                        for(int x = 0; x < 10; x++)
                        {
                            for (int y = 0; y < 10; y++)
                            {
                                if (gameOn[x,y,0])
                                {
                                    Console.WriteLine("Coordinates " + x + ", " + y + " have a ship");
                                }
                            }
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
                    else if (secondGridPoint == "CHEATCODE")
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            for (int y = 0; y < 10; y++)
                            {
                                if (gameOn[x, y, 0])
                                {
                                    Console.WriteLine("Coordinates " + x + ", " + y + " have a ship");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The input is not a whole number");
                    }
                }
                
                Console.WriteLine("CHECKING FOR HIT");
                Point thisPoint = new Point(outputOne - 1, outputTwo - 1);
                //int attemptsCounter = 0;

                bool[,,] gameResults = gameGrid.CheckForHit(gameBoardBoolArray, outputOne,outputTwo);

                if (gameResults[outputOne - 1, outputTwo - 1, gameGrid.HasAHit])
                {
                    var attemptsRecord = gameGrid.GetAttemptsRecord();
                    foreach (Point xy in attemptsRecord)
                    {
                        if (xy == thisPoint)
                        {
                            Console.WriteLine("You have already attempted to hit at these coordinates");
                            turnCounter++;
                        }
                        else
                        {
                            gameGrid.SetAttemptsRecord(outputOne, outputTwo, turnCounter);
                            hitCounter++;
                            Console.WriteLine("ITS A HIT!!!");
                            break;
                        }
                    }
                    
                    
                }
                else if (!gameResults[outputOne - 1, outputTwo - 1, gameGrid.HasAHit])
                {
                    var attemptsRecord = gameGrid.GetAttemptsRecord();
                    foreach (Point xy in attemptsRecord)
                    {
                        if (xy == thisPoint)
                        {
                            Console.WriteLine("You have already attempted to hit at these coordinates");
                            turnCounter++;
                            break;
                        }
                    }
                    
                    gameGrid.SetAttemptsRecord(outputOne, outputTwo, turnCounter);
                    Console.WriteLine("You Missed!");
                }
                else
                {
                    Console.WriteLine("Your input resulted in an unknown error");
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
