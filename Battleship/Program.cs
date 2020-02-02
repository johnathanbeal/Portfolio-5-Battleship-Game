using System;
using System.Drawing;
using System.Text.RegularExpressions;

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
            ControlFlow Control = new ControlFlow();
            
            Console.WriteLine("PLAY BATTLESHIP!\n");
            int turnCounter = 1;
            int hitCounter = 0;

            //int turnCountOut;
            //int hitCountOut;

            int[] output = new int[2];
            int urOut;

            while (turnCounter < 9 && hitCounter < 5)
            {
                Console.WriteLine("This is turn number " + turnCounter + "\n");

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("SELECT A NUMBER BETWEEN 1 AND 10\n");
                    string gridPointInput = Console.ReadLine();

                    // Part 2: call Regex.Match.
                    Match match = Regex.Match(gridPointInput, @"([A-Za-z0-9\-]+)",
                        RegexOptions.IgnoreCase);

                    // Part 3: check the Match for Success.
                    if (match.Success && int.TryParse(gridPointInput, out urOut) != true)
                    {
                        Control.HandleInput(gameOn, output[i], gridPointInput);
                        i--;
                    }
                    else if (gridPointInput == "CHEATCODE")
                    {
                        Control.HandleInput(gameOn, output[i], gridPointInput);
                        i--;
                    }
                    else if (output[i] > 10 || output[i] < 1)
                    {
                        Control.HandleInput(gameOn, output[i], gridPointInput);
                        i--;
                    }
                    else
                    {
                        output[i] = Control.HandleInput(gameOn, output[i], gridPointInput);
                    }
                }
                

                Point thisPoint = new Point(output[0] - 1, output[1] - 1);

                var battleshipWasHit = Control.CheckForHit(gameGrid, gameBoardBoolArray, thisPoint, output[0] - 1, output[1] - 1);//do I need to subtract 1 from each output?

                //gameGrid.SetAttemptsRecord(output[0], output[1], turnCounter);
                gameGrid.SetAttemptsRecord(thisPoint, HitClass.ifBattleShipAttempt(battleshipWasHit));
                if (battleshipWasHit)
                {
                    hitCounter++;
                    Console.WriteLine("You have " + hitCounter + " hits!\n");
                }
                if (turnCounter < 8)
                {
                    turnCounter++;
                }
                else
                {
                    break;
                }
            }

            Control.CheckNumberOf(hitCounter);

            Control.IsItTheEnd(hitCounter, turnCounter);
        }
    }
}
