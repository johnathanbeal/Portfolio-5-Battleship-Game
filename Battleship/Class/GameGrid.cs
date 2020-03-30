using System;
using System.Collections.Generic;
using System.Drawing;

namespace Battleship
{
    public class GameGrid
    {
        public GameGrid(Random rand)
        {
            Random = rand;
            for (int i = 0; i < _grid.Length; i++)
            {
                _grid[i] = new bool[10];
                for (int k = 0; k < _grid[i].Length; k++)
                {
                    _grid[i][k] = false;
                }
            }

            var shipOrientation = ShipPosition.IsShipVertical();
            var verticalStartIndex = ShipPosition.VerticalStarterIndex((bool)shipOrientation);
            var horizontalStartIndex = ShipPosition.HorizontalStarterIndex((bool)shipOrientation);

            _grid = ShipPosition.DefineShipLocation(_grid, shipOrientation, verticalStartIndex, horizontalStartIndex);
        }

        Random Random;

        private bool[][] _grid = new bool[10][];

        public bool CheckForHit(int row, int column)
        {
            return _grid[row - 1][column - 1];
        }
        
        public List<Point> GivePlayerShipCoordinates()
        {
            int _counter = 0;
            List<Point> _coordinates = new List<Point>();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (_grid[x][y])
                    {
                        _coordinates.Add(new Point(x, y));
                        _counter++;
                    }
                }
            }
            return _coordinates;
        }
    }
}
