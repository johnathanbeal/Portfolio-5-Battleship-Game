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
            
            Console.WriteLine("PLAY BATTLESHIP!");
            int turnCounter = 1;
            int hitCounter = 0;

            int turnCountOut;
            int hitCountOut;

            int outputOne;
            int outputTwo;

            while (turnCounter < 9 && hitCounter < 5)
            {
                Console.WriteLine("This is turn number " + turnCounter);

                Control.HandleInput(gameOn, out outputOne);

                Control.HandleInput(gameOn, out outputTwo);

                Point thisPoint = new Point(outputOne - 1, outputTwo - 1);

                Control.CheckForHitWorkflow(gameGrid, gameBoardBoolArray, thisPoint, outputOne, outputTwo, turnCounter, hitCounter, out hitCountOut, out turnCountOut);

                hitCounter = hitCountOut;
                turnCounter = turnCountOut;

            }

            Control.CheckNumberOf(hitCounter);

            Control.IsItTheEnd(turnCounter);
        }
    }
}
