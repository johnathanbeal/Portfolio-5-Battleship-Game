using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public static class ShipPosition
    {
        
        public static int VerticalStarterIndex(bool shipIsVertical)
        {
            Random Random = new Random();

            if (shipIsVertical)
            {
                return Random.Next(0, 5);
            }
            else
            {
                return Random.Next(0, 9);
            }
        }

        public static int HorizontalStarterIndex(bool shipIsVertical)
        {
            Random Random = new Random();

            if (shipIsVertical)
            {
                return Random.Next(0, 9);
            }
            else
            {
                return Random.Next(0, 5);
            }
        }

        public static bool? IsShipVertical()
        {
            Random Random = new Random();

            return Random.NextDouble() > 0.5;
        }

        public static bool[][] DefineShipLocation(bool[][] _defineGamGrid, bool? shipIsVertical, int verticalStart, int horizontalStart)
        {

            if ((bool)shipIsVertical)
            {
                _defineGamGrid[verticalStart + 0][horizontalStart] = true;
                _defineGamGrid[verticalStart + 1][horizontalStart] = true;
                _defineGamGrid[verticalStart + 2][horizontalStart] = true;
                _defineGamGrid[verticalStart + 3][horizontalStart] = true;
                _defineGamGrid[verticalStart + 4][horizontalStart] = true;
            }
            else
            {
                _defineGamGrid[verticalStart][horizontalStart + 0] = true;
                _defineGamGrid[verticalStart][horizontalStart + 1] = true;
                _defineGamGrid[verticalStart][horizontalStart + 2] = true;
                _defineGamGrid[verticalStart][horizontalStart + 3] = true;
                _defineGamGrid[verticalStart][horizontalStart + 4] = true;
            }
            return _defineGamGrid;
        }

        

    }
}
