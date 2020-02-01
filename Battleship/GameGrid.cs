using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship
{
    public class GameGrid
    {
        public GameGrid(Random rand)
        {
            Random = rand;
        }

        public Random Random { get; set; }

        private int hasAShip = 0;
        private int hasAHit = 1;

        public int HasAShip { get { return hasAShip; } private set { } }
        public int HasAHit { get { return hasAHit; } private set { } }

        private Point[] attemptsRecord = new Point[10];

        public Point[] GetAttemptsRecord()
        {
            return attemptsRecord;
        }

        public void SetAttemptsRecord(int x, int y, int attempt)
        {         
            attemptsRecord[attempt - 1] = new Point(x - 1, y - 1); 
        }

        //public int HasAHit { get; set; }

        private int VerticalStarterIndex(bool shipIsVertical)
        {
            if(shipIsVertical)
            {
                return Random.Next(0, 5);
            }
            else
            {
                return Random.Next(0, 9);
            }
        }

        private int HorizontalStarterIndex(bool shipIsVertical)
        {
            if (shipIsVertical)
            {
                return Random.Next(0, 9);
            }
            else
            {
                return Random.Next(0, 5);
            }
        }

        private enum ShipOrientation
        {
            Vertical,
            Horizontal
        }

        private bool? IsShipVertical()
        {
            Array orientations = Enum.GetValues(typeof(ShipOrientation));
            ShipOrientation randomOrientation = (ShipOrientation)orientations.GetValue(Random.Next(orientations.Length));
            if (randomOrientation == ShipOrientation.Vertical)
                return true;
            else if (randomOrientation == ShipOrientation.Horizontal)
                return false;
            else
                return null;
        }

        public bool[,,] DefineBoardAsAllFalse(bool[,,] pairOfBool)
        {           
            for (int x = 0; x< 10; x++)
            {
                for (int y = 0; y< 10; y++)
                {
                    for (int z = 0; z< 2; z++)
                    {
                        pairOfBool[x, y, z] = false;
                    }
}
            }
            return pairOfBool;
        }       

        public bool[,,] DefineShipLocation(bool[,,] booly, bool? shipIsVertical, int verticalStart, int horizontalStart)
        {
            
            if((bool)shipIsVertical)
            {
                booly[verticalStart, horizontalStart, hasAShip] = true;
                booly[verticalStart + 1, horizontalStart, hasAShip] = true;
                booly[verticalStart + 2, horizontalStart, hasAShip] = true;
                booly[verticalStart + 3, horizontalStart, hasAShip] = true;
                booly[verticalStart + 4, horizontalStart, hasAShip] = true;
            }
            else
            {
                booly[verticalStart, horizontalStart + 0, hasAShip] = true;
                booly[verticalStart, horizontalStart + 1, hasAShip] = true;
                booly[verticalStart, horizontalStart + 2, hasAShip] = true;
                booly[verticalStart, horizontalStart + 3, hasAShip] = true;
                booly[verticalStart, horizontalStart + 4, hasAShip] = true;
            }
            return booly;

        }

        public bool[,,] GameOn(bool[,,] boolArray)
        {           
            Console.WriteLine("Game On!\n");

            //var boardIsAllFalse = DefineBoardAsAllFalse(PairOfBools);

            var shipOrientation = IsShipVertical();
            var verticalStartIndex = VerticalStarterIndex((bool)shipOrientation);
            var horizontalStartIndex = HorizontalStarterIndex((bool)shipOrientation);

            var boardHasShip = DefineShipLocation(boolArray, shipOrientation, verticalStartIndex, horizontalStartIndex);
            return boardHasShip;
        }
    }
}
