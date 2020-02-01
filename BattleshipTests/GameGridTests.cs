using Battleship;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BattleshipTests.GameGridTests")]


namespace BattleshipTests
{
    public class GameGridTests
    {
        [Fact]
        public void GetAttemptsRecord_ReturnsTypeArrayOfPoint()
        {
            Random r = new Random();
            GameGrid gamer = new GameGrid(r);

            var result = gamer.GetAttemptsRecord();

            Assert.IsType<Point[]>(gamer.GetAttemptsRecord());
        }

        [Fact]
        public void SetAttemptsRecord_ReturnsExpectedPoint()
        {
            Random r = new Random();
            GameGrid grid = new GameGrid(r);

            var x = r.Next(1, 10);
            var y = r.Next(1, 10);

            var iteration = 1;

            grid.SetAttemptsRecord(x,y, iteration);

            var points = grid.GetAttemptsRecord();

            var expectedPoint = new Point(x - 1, y - 1);

            Assert.Equal(expectedPoint, points[iteration - 1]);
        }

        [Fact]
        public void SetAttemptsRecord_ReturnsExpectedPoints()
        {
            Random r = new Random();
            GameGrid grid = new GameGrid(r);

            int x;
            int y;

            for (int i = 1; i <= 5; i++)
            {
                x = r.Next(1, 10);
                y = r.Next(1, 10);

                grid.SetAttemptsRecord(x, y, i);

                x = x - 1;
                y = y - 1;

                var points = grid.GetAttemptsRecord();

                var expectedPoint = new Point(x, y);

                Assert.Equal(expectedPoint, points[i-1]);
            }
        }

        [Fact]
        public void DefineBoardAsAllFalse_ReturnsMultidimensionalBoolArrayAllFalse()
        {
            Random r = new Random();

            GameGrid gameNight = new GameGrid(r);

            bool[,,] gameBoard = new bool[10, 10, 2];

            var falsey = gameNight.DefineBoardAsAllFalse(gameBoard);

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Assert.False(falsey[x, y, z]);
                    }
                }
            }
        }

        [Fact]
        public void  DefineShipLocation_ReturnsShipLocation()
        {
            Random r = new Random();

            GameGrid gameNight = new GameGrid(r);

            var rBool = r.Next(0, 1) == 1 ? true : false;

            var shipOrientation = rBool;
            var verticalStartIndex = r.Next(0, 5);
            var horizontalStartIndex = r.Next(0, 5);

            bool[,,] boolArray = new bool[10, 10, 2];

            var starterBoard = gameNight.DefineBoardAsAllFalse(boolArray);

            var boardHasShip = gameNight.DefineShipLocation(boolArray, shipOrientation, verticalStartIndex, horizontalStartIndex);

            if(shipOrientation)
            {
                Assert.True(boardHasShip[verticalStartIndex, horizontalStartIndex, 0]);
                Assert.True(boardHasShip[verticalStartIndex + 1, horizontalStartIndex, 0]);
                Assert.True(boardHasShip[verticalStartIndex + 2, horizontalStartIndex, 0]);
                Assert.True(boardHasShip[verticalStartIndex + 3, horizontalStartIndex, 0]);
                Assert.True(boardHasShip[verticalStartIndex + 4, horizontalStartIndex, 0]);
            }
            else 
            {
                Assert.True(boardHasShip[verticalStartIndex, horizontalStartIndex, 0]);
                Assert.True(boardHasShip[verticalStartIndex, horizontalStartIndex + 1, 0]);
                Assert.True(boardHasShip[verticalStartIndex, horizontalStartIndex + 2, 0]);
                Assert.True(boardHasShip[verticalStartIndex, horizontalStartIndex + 3, 0]);
                Assert.True(boardHasShip[verticalStartIndex, horizontalStartIndex + 4, 0]);
            }
        }

        [Fact]
        public void GameOn_Returns_5True()
        {
            Random r = new Random();

            GameGrid gameNight = new GameGrid(r);

            bool[,,] boolArray = new bool[10, 10, 2];

            var boardWithShipLocation = gameNight.GameOn(boolArray);
            var truepointcount = 0;

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 2; z++)
                    {
                       var thisPoint = boardWithShipLocation[x, y, z];
                       if (thisPoint)
                        {
                            truepointcount++;
                        }
                    }
                }
            }
            Assert.Equal(5, truepointcount);
            
        }

        [Fact]
        public void GameOn_ErrorneousBoolReturns_()
        {
            Random r = new Random();

            GameGrid gameNight = new GameGrid(r);

            bool[,,] boolArray = new bool[0, 0, 0];

            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => gameNight.GameOn(boolArray));

            Assert.Equal("Index was outside the bounds of the array.", ex.Message);
          
        }
    }
}
