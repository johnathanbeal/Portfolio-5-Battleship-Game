using System;
using Battleship.Constants;

namespace Battleship
{
    public class ControlFlow
    {
        public int TurnCounter = 1;
        public int HitCounter = 0;

        GameGrid gameGrid;

        public ControlFlow(GameGrid _gameGrid)
        {
            gameGrid = _gameGrid;
        }       

        public string ShipWasHit(bool shipWasHit)
        {
            if (shipWasHit == true)
            {
                HitCounter++;
                return "ITS A HIT!!!\n";
            }
            else
            {
                return "You missed!\n";
            }
        }
       
        public string DisplayGameResults()
        {
            if (HitCounter == Battleship.Constants.Constants.MAXNUMBEROFHITSPERGAME)
            {
                return "You sunk my battleship!";
            }
            else if (TurnCounter > Battleship.Constants.Constants.NUMBEROFTURNSPERGAME)
            {
                return "Game Over!";
            }
            else
            {
                return "Start Over.";
            }
        }
    }
}
