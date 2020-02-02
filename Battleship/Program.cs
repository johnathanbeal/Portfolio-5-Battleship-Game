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
            ControlFlow Control = new ControlFlow();
            
            Console.WriteLine("PLAY BATTLESHIP!\n");
            int turnCounter = 1;
            int hitCounter = 0;

            //int turnCountOut;
            //int hitCountOut;

            int[] output = new int[2];

            while (turnCounter < 9 && hitCounter < 5)
            {
                Console.WriteLine("This is turn number " + turnCounter + "\n");

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("SELECT A NUMBER BETWEEN 1 AND 10\n");
                    string gridPoint = Console.ReadLine();

                    output[i] = Control.HandleInput(gameOn, output[i], gridPoint);
                    if(gridPoint == "CHEATCODE")
                    {
                        i--;
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
