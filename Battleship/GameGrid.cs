using System;
using System.Collections.Generic;
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

        public int HasAShip { get { return hasAShip; }  private set { } }
        public int HasAHit { get { return hasAHit; } private set { } }

        private Hit[,] attemptsRecord = new Hit[8, 2];

        public Hit GetAttemptsRecord(int x, int y)
        {
            return attemptsRecord[x - 1, y - 1];
        }

        public void SetHitsRecord(int x, int y, Hit hit)
        {         
            attemptsRecord[x - 1, y - 1] = hit; 
        }



        //public int HasAHit { get; set; }

        private int VerticalStarterIndex()
        {
            return Random.Next(0, 5);
        }

        private int HorizontalStarterIndex()
        {
            return Random.Next(0, 5);
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

        private bool[,,] DefineShipLocation(bool[,,] booly, bool? shipIsVertical, int verticalStart, int horizontalStart)
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

        public bool[,,] CheckForHit(bool[,,] buul, int x, int y)
        {
            if (buul[x - 1, y - 1, hasAShip] == true)
                buul[x - 1, y - 1, hasAHit] = true;

            return buul;
        }

        public bool[,,] GameOn(bool[,,] boolArray)
        {
            
            Console.WriteLine("Game On!");

            //var boardIsAllFalse = DefineBoardAsAllFalse(PairOfBools);

            var shipOrientation = IsShipVertical();
            var verticalStartIndex = VerticalStarterIndex();
            var horizontalStartIndex = HorizontalStarterIndex();

            var boardHasShip = DefineShipLocation(boolArray, shipOrientation, verticalStartIndex, horizontalStartIndex);
            return boolArray;
        }
    }
}
