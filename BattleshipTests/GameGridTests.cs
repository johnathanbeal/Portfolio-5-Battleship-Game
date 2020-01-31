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
        public void GetAttemptsRecord_ReturnsTypeArrayOfPoint()
        {
            Random r = new Random();
            GameGrid gamer = new GameGrid(r);

            var result = gamer.GetAttemptsRecord();

            Assert.IsType<Point[]>(gamer.GetAttemptsRecord());
        }

        //public void SetAttemptsRecord_Retu
    }
}
