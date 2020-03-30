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
        Random Random;
        GameGrid GameGrid;

        public GameGridTests()
        {
            Random = new Random();
            GameGrid = new GameGrid(Random);
        }
        
        [Fact]
        public void CheckForHit_ReturnsFiveTrue()
        {
            short hits = 0;
            for (int x = 1; x < 10; x++ )
            {
                for (int y = 1; y < 10; y++)
                {
                    if(GameGrid.CheckForHit(x, y))
                        hits++;
                }
            }
            Assert.True(hits == 5);
        }

        [Fact]
        public void GivePlayerShipCoordinates_ReturnsListOfFivePoints()
        {
            var points = GameGrid.GivePlayerShipCoordinates();
            Assert.Equal(5, points.Count);
        }
    }
}
