using Battleship;
using System;
using Xunit;

namespace BattleshipTests
{
    public class ControlFlowTests
    {
        [Fact]
        public void CheckNumberOf_WritesNumberOfHitsWhenHitCountIsBelow5()
        {
            Random random = new Random();

            int randomInt = random.Next(1,4);

            ControlFlow control = new ControlFlow();

            var readMessage = control.CheckNumberOf(randomInt);

            var expectedMessage = "Number of hits is " + randomInt + "\n";

            Assert.Equal(expectedMessage, readMessage);
        }

        [Fact]
        public void CheckNumberOf_WritesYouSunkMyBattleshipWhenHitCountIs5()
        {
            const int MAXNUMBEROFHITSPERGAME = 5;

            ControlFlow control = new ControlFlow();

            var readMessage = control.CheckNumberOf(MAXNUMBEROFHITSPERGAME);

            var expectedMessage = "You sunk my battleship!\n";

            Assert.Equal(expectedMessage, readMessage);
        }

        [Fact]
        public void IsItTheEnd_WritesGameOver_WhenHitCountIs5()
        {
            const int MAXNUMBEROFHITSPERGAME = 5;
            Random random = new Random();

            int turnCount = random.Next(1, 8);

            ControlFlow control = new ControlFlow();

            var readMessage = control.IsItTheEnd(MAXNUMBEROFHITSPERGAME, turnCount);

            var expectedMessage = "GAME OVER!!!\n";

            Assert.Equal(expectedMessage, readMessage);
        }

        [Fact]
        public void IsItTheEnd_WritesGameOver_WhenTurnCountIs8()
        {
            const int NUMBEROFTURNSPERGAME = 8;
            Random random = new Random();

            int hitCount = random.Next(1, 8);

            ControlFlow control = new ControlFlow();

            var readMessage = control.IsItTheEnd(hitCount, NUMBEROFTURNSPERGAME);

            var expectedMessage = "GAME OVER!!!\n";

            Assert.Equal(expectedMessage, readMessage);
        }
    }
}
