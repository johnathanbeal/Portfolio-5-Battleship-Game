using Battleship;
using System;
using Moq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Drawing;
using Xunit;

[assembly: InternalsVisibleTo("BattleshipTests.ControlFlowTests")]


namespace BattleshipTests
{
    public class ControlFlowTests
    {
        private Random R;
        private GameGrid GameGrid;
        private ControlFlow ControlFlow;

        public ControlFlowTests()
        {
            R = new Random();
            GameGrid = new GameGrid(R);
            ControlFlow = new ControlFlow(GameGrid);
        }

        [Fact]
        public void ShipWasHit_WhenTrueHitCounterIncreases()
        {            
            var plus_one = 1;
            var before = ControlFlow.HitCounter;
            ControlFlow.ShipWasHit(true);
            var after = ControlFlow.HitCounter;           
            Assert.Equal(after, before + plus_one);
        }

        [Fact]
        public void ShipWasHit_WhenFalseHitCounterDoesNotIncrease()
        {
            var before = ControlFlow.HitCounter;
            ControlFlow.ShipWasHit(false);
            var after = ControlFlow.HitCounter;
            Assert.Equal(after, before);
        }

        [Fact]
        public void ShipWasHit_WhenTrue_Returns_ItsAHit()
        {           
            var actual = ControlFlow.ShipWasHit(true);
            var expect = "ITS A HIT!!!\n";
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void ShipWasHit_WhenFalse_Returns_YouMissed()
        {
            var plus_one = 1;
            var before = ControlFlow.HitCounter;
            ControlFlow.ShipWasHit(true);
            var after = ControlFlow.HitCounter;
            Assert.Equal(after, before + plus_one);
        }

        [Fact]
        public void DisplayGameResults_Returns_YouSunkMyBattleship_WhenHitCounterEqualsMax()
        {
            ControlFlow.HitCounter = 5;
            var expect = "You sunk my battleship!";
            var actual = ControlFlow.DisplayGameResults();
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void DisplayGameResults_Returns_YouSunkMyBattleship_WhenHitCounterEqualsMax_AndTurnCountExceedsNumberOfTurnsAllowed()
        {
            ControlFlow.HitCounter = 5;
            ControlFlow.TurnCounter = 8 + 1;
            var expect = "You sunk my battleship!";
            var actual = ControlFlow.DisplayGameResults();
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void DisplayGameResults_Returns_YouSunkMyBattleship_WhenHitCounterEqualsMax_AndTurnCountLessThanNumberOfTurnsAllowed()
        {
            ControlFlow.HitCounter = 5;
            ControlFlow.TurnCounter = 8 - 1;
            var expect = "You sunk my battleship!";
            var actual = ControlFlow.DisplayGameResults();
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void DisplayGameResults_DoesNotReturn_YouSunkMyBattleship_WhenHitCounterDoesNotEqualsMax()
        {
            ControlFlow.HitCounter = RandomThings.NotMaxHits();
            var notExpected = "You sunk my battleship!";
            var actual = ControlFlow.DisplayGameResults();
            Assert.NotEqual(notExpected, actual);
        }

        [Fact]
        public void DisplayGameResults_DoesNotReturn_YouSunkMyBattleship_WhenHitCounterExceedsMax()
        {
            ControlFlow.HitCounter = 5 + 1;
            var notExpected = "You sunk my battleship!";
            var actual = ControlFlow.DisplayGameResults();
            Assert.NotEqual(notExpected, actual);
        }

        [Fact]
        public void DisplayGameResults_Returns_GameOver_WhenTurnCountExceedsNumberOfTurnsAllowed()
        {
            int maxTurns = 8;
            ControlFlow.HitCounter = RandomThings.NotMaxHits();
            ControlFlow.TurnCounter = maxTurns + 1;
            var expect = "Game Over!";
            var actual = ControlFlow.DisplayGameResults();
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void DisplayGameResults_DoesNotReturn_GameOver_WhenTurnCountDoesNotExceedsNumberOfTurnsAllowed()
        {
            ControlFlow.HitCounter = RandomThings.NotMaxHits();
            ControlFlow.TurnCounter = RandomThings.TurnCountOrLess();
            var notExpected = "Game Over!";
            var actual = ControlFlow.DisplayGameResults();
            Assert.NotEqual(notExpected, actual);
        }

        [Fact]
        public void DisplayGameResults_Returns_StartOver_WhenTurnCountDoesNotExceedsNumberOfTurnsAllowed()
        {
            ControlFlow.HitCounter = RandomThings.NotMaxHits();
            ControlFlow.TurnCounter = RandomThings.TurnCountOrLess();
            var expect = "Start Over.";
            var actual = ControlFlow.DisplayGameResults();
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void DisplayGameResults_DoesNotReturn_StartOver_WhenTurnCountExceedsNumberOfTurnsAllowed()
        {
            ControlFlow.HitCounter = RandomThings.NotMaxHits();
            ControlFlow.TurnCounter = RandomThings.TurnCountOrLess() + 10;
            var notExpected = "Start Over.";
            var actual = ControlFlow.DisplayGameResults();
            Assert.NotEqual(notExpected, actual);
        }
    }
}
