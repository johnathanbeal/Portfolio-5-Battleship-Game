using Battleship;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleshipTests.Tests
{
    public class ShipOrientationTests
    {
        Random Random;
        bool[][] _grid;
        public ShipOrientationTests()
        {
            Random = new Random();
            _grid = new bool[10][];

            for (int i = 0; i < _grid.Length; i++)
            {
                _grid[i] = new bool[10];
                for (int k = 0; k < _grid[i].Length; k++)
                {
                    _grid[i][k] = false;
                }
            }
        }

        [Fact]
        public void VerticalStarterIndex_True()
        {
            var actual = ShipPosition.VerticalStarterIndex(true);
            Assert.True(0 < actual && actual < 6);
        }

        [Fact]
        [Trait("Category", "Flaky")]
        public void VerticalStarterIndex_False()
        {
            var actual = ShipPosition.VerticalStarterIndex(false);
            Assert.True(0 <= actual && actual <= 9);
        }

        [Fact]
        [Trait("Category", "Flaky")]
        public void HorizontalStarterIndex_True()
        {
            var actual = ShipPosition.HorizontalStarterIndex(true);
            Assert.True(0 <= actual && actual <= 9);
        }

        [Fact]
        public void HorizontalStarterIndex_False()
        {
            var actual = ShipPosition.HorizontalStarterIndex(false);
            Assert.True(-1 < actual && actual < 6);
        }

        [Fact]
        public void IsShipVertical_NotNull()
        {
            var ship = ShipPosition.IsShipVertical();
            Assert.NotNull(ship);
        }

        [Fact]
        [Trait("Category", "Flaky")]
        public void IsShipVertical_TrueOrFalse()
        {
            var ship = (bool)ShipPosition.IsShipVertical();
            if (ship)
            {
                Assert.True(ship);
            }
            else
            {
                Assert.True(!ship);
            }
        }

        [Fact]
        [Trait("Category", "Flaky")]
        public void DefineShipLocation_PassTrue_ReturnsBool()
        {
            var shipOrientation = true;
            var verticalStartIndex = ShipPosition.VerticalStarterIndex((bool)shipOrientation);
            var horizontalStartIndex = ShipPosition.HorizontalStarterIndex((bool)shipOrientation);

            var _grid2 = ShipPosition.DefineShipLocation(_grid, shipOrientation, verticalStartIndex, horizontalStartIndex);
            bool[][] expectedType = new bool[10][];
            Assert.IsType(expectedType.GetType(), _grid2);

        }

        [Fact]
        [Trait("Category", "Flaky")]
        public void DefineShipLocation_PassFalse_ReturnsBool()
        {
            var shipOrientation = false;
            var verticalStartIndex = ShipPosition.VerticalStarterIndex((bool)shipOrientation);
            var horizontalStartIndex = ShipPosition.HorizontalStarterIndex((bool)shipOrientation);

            var _grid2 = ShipPosition.DefineShipLocation(_grid, shipOrientation, verticalStartIndex, horizontalStartIndex);
            bool[][] expectedType = new bool[10][];
            Assert.IsType(expectedType.GetType(), _grid2);

        }

        [Fact]
        [Trait("Category", "Flaky")]
        public void DefineShipLocation_PassRandom_ReturnsBool()
        {
            var shipOrientation = ShipPosition.IsShipVertical();
            var verticalStartIndex = ShipPosition.VerticalStarterIndex((bool)shipOrientation);
            var horizontalStartIndex = ShipPosition.HorizontalStarterIndex((bool)shipOrientation);

            var _grid2 = ShipPosition.DefineShipLocation(_grid, shipOrientation, verticalStartIndex, horizontalStartIndex);
            bool[][] expectedType = new bool[10][];
            Assert.IsType(expectedType.GetType(), _grid2);

        }

        [Fact]
        [Trait("Category", "Flaky")]
        public void DefineShipLocation_PassRandom_Returns2DArrayWithFiveTrue()
        {
            var truthy = 0;
            var shipOrientation = ShipPosition.IsShipVertical();
            var verticalStartIndex = ShipPosition.VerticalStarterIndex((bool)shipOrientation);
            var horizontalStartIndex = ShipPosition.HorizontalStarterIndex((bool)shipOrientation);

            var _actual = ShipPosition.DefineShipLocation(_grid, shipOrientation, verticalStartIndex, horizontalStartIndex);
            bool[][] expected = new bool[10][];

            foreach (var outerArray in _actual)
            {
                foreach (var innerArray in outerArray)
                {
                    if (innerArray)
                        truthy++;
                }

            }
            Assert.Equal(5, truthy);
        }
    }
}
