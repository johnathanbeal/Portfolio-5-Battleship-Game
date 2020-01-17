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


        public int VerticalStarterIndex()
        {
            return Random.Next(0, 5);
        }

        public int HorizontalStarterIndex()
        {
            return Random.Next(0, 5);
        }

        public enum ShipOrientation
        {
            Vertical,
            Horizontal
        }

        public bool? IsShipVertical()
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

        public Parabool[,] DefineBoardAsAllFalse(Parabool[,] parabola)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    parabola[x, y].HasAShip = false;
                    parabola[x, y].HasAHit = false;
                }
            }
            return parabola;
        }       

        public Parabool[,] DefineShipLocation(Parabool[,] parabola, bool? shipIsVertical, int verticalStart, int horizontalStart)
        {
            if((bool)shipIsVertical)
            {
                parabola[verticalStart, horizontalStart].HasAShip = true;
                parabola[verticalStart + 1, horizontalStart].HasAShip = true;
                parabola[verticalStart + 2, horizontalStart].HasAShip = true;
                parabola[verticalStart + 3, horizontalStart].HasAShip = true;
                parabola[verticalStart + 4, horizontalStart].HasAShip = true;
            }
            else
            {
                parabola[verticalStart, horizontalStart + 0].HasAShip = true;
                parabola[verticalStart, horizontalStart + 1].HasAShip = true;
                parabola[verticalStart, horizontalStart + 2].HasAShip = true;
                parabola[verticalStart, horizontalStart + 3].HasAShip = true;
                parabola[verticalStart, horizontalStart + 4].HasAShip = true;
            }
            return parabola;

        }

        public void GameOn()
        {
            Parabool[,] PairOfBools = new Parabool[10, 10];

            Console.WriteLine("Game On!");

            var boardIsAllFalse = DefineBoardAsAllFalse(PairOfBools);

            var shipOrientation = IsShipVertical();
            var verticalStartIndex = VerticalStarterIndex();
            var horizontalStartIndex = HorizontalStarterIndex();

            var boardHasShip = DefineShipLocation(PairOfBools, shipOrientation, verticalStartIndex, horizontalStartIndex);
            
        }
    }
}
