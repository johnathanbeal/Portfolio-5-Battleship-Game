using Battleship;
using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Drawing;

[assembly: InternalsVisibleTo("BattleshipTests.ControlFlowTests")]


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

        [Fact]
        public void HandleInput_CorrectInputExpectsIntBetween1And10()
        {
            Random ra = new Random();
            
            int input = ra.Next(1, 10);

            var validInputList = new List<string> {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", 
            //"CHEATCODE"
            };

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            var result = control.HandleInput(gameBoardBoolArray, input, validInputList[ra.Next(validInputList.Count)]);
            Assert.True(result > 0 && result < 11);
        }

        [Fact]
        public void HandleInput_IncorrectExceedsInputExpects()
        {
            Random ra = new Random();

            int input1 = ra.Next(-10, -1);
            int input2 = ra.Next(11, 20);

            var inputs = new List<int> { input1, input2 };
            var index = ra.Next(0, 1);
            var input = inputs[index];

            var validInputList = new List<string> {
                "-1", "-2", "-3", "-4", "-5", "-6", "-7", "-8", "-9", "-10",
                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" 
            };

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            var result = control.HandleInput(gameBoardBoolArray, input, validInputList[ra.Next(validInputList.Count)]);
            Assert.True(result > 0 || result < 11);
        }

        [Fact]
        public void HandleInput_CheatcodeInputExpectsIntOF0()
        {
            Random ra = new Random();

            int input = ra.Next(1, 10);

            var validInputList = new List<string> {
            "CHEATCODE"
            };

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            var result = control.HandleInput(gameBoardBoolArray, input, validInputList[ra.Next(validInputList.Count)]);
            Assert.True(result == 0);
        }

        [Fact]
        public void ParseGridPoint_Message_ReturnsTrueIfInputIsCheatCodeMessage()
        {
            Random ra = new Random();

            int input = ra.Next(1, 10);

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            string[] noMessage = new string[2];

            var result = control.GridPointMessage(0, "CHEATCODE", out noMessage, gameBoardBoolArray);
            Assert.True(result);
        }

        [Fact]
        public void ParseGridPoint_Message_ReturnsFalseIfInputExceeds10()
        {
            Random ra = new Random();

            int input = ra.Next(11, 100);

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            string[] noMessage = new string[2];

            var result = control.GridPointMessage(input, "", out noMessage, gameBoardBoolArray);
            Assert.False(result);
        }

        [Fact]
        public void ParseGridPoint_Message_ReturnsFalseIfInputLessThan1()
        {
            Random ra = new Random();

            int input = ra.Next(-100, 0);

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            string[] noMessage = new string[2];

            var result = control.GridPointMessage(input, "", out noMessage, gameBoardBoolArray);
            Assert.False(result);
        }

        [Fact]
        public void ParseGridPoint_Message_ReturnsTrueIfInputBetween1And10()
        {
            Random ra = new Random();

            int input = ra.Next(1, 10);

            Randomness randomy = new Randomness();
            var randomString = randomy.RandomString(14, true);

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            string[] noMessage = new string[2];

            var result = control.GridPointMessage(null, randomString, out noMessage, gameBoardBoolArray);
            Assert.True(result);
        }

        [Fact]
        public void ParseGridPoint_Message_ExpectedMessageReceivedWhenInputStringIsCheatcode()
        {
            Random ra = new Random();

            int input = ra.Next(1, 10);

            GameGrid gameGrid = new GameGrid(ra);
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];
            var gameOn = gameGrid.GameOn(gameBoardBoolArray);

            var expectedString = "CHEATCODE";

            ControlFlow control = new ControlFlow();

            string[] _message = new string[2];

            var result = control.GridPointMessage(input, expectedString, out _message, gameOn);

            for (int i = 0; i < 5; i++)
            {
                Assert.Contains("Coordinates ", _message[i]);
                Assert.Contains(", ", _message[i]);
                Assert.Contains(" have a ship", _message[i]);
            }
        }

        [Fact]
        public void ParseGridPoint_Message_ExpectedMessageReceivedIfInputExceeds10()
        {
            Random ra = new Random();

            int input = ra.Next(11, 100);

            var expectedString = "You selected a number greater than 10 or less than 1.  Epic fail.\n";

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            string[] _message = new string[2];

            var result = control.GridPointMessage(input, "", out _message, gameBoardBoolArray);
            Assert.Equal(expectedString, _message[0]);
        }

        [Fact]
        public void ParseGridPoint_Message_ExpectedMessageReceivedIfInputLessThan1()
        {
            Random ra = new Random();

            int input = ra.Next(-100, 0);

            var expectedString = "You selected a number greater than 10 or less than 1.  Epic fail.\n";

            ControlFlow control = new ControlFlow();
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            string[] _message = new string[2];

            var result = control.GridPointMessage(input, "", out _message, gameBoardBoolArray);
            Assert.Equal(expectedString, _message[0]);
        }

        [Fact]
        public void AttemptWasAHit_ReturnsTrueWhenAttemptIsAHit()
        {
            Random ra = new Random();

            GameGrid gameGrid = new GameGrid(ra);
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];
            var gameOn = gameGrid.GameOn(gameBoardBoolArray);

            ControlFlow control = new ControlFlow();
            //control.
        }

        [Theory]
        [InlineData(0, 1, true)]
        [InlineData(0, 2, true)]
        [InlineData(0, 3, true)]
        [InlineData(0, 4, true)]
        [InlineData(0, 5, true)]
        [InlineData(0, 6, true)]
        [InlineData(1, 0, true)]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, true)]
        [InlineData(1, 3, true)]
        [InlineData(1, 4, true)]
        [InlineData(1, 5, true)]
        [InlineData(1, 6, true)]
        [InlineData(1, 7, true)]
        [InlineData(1, 8, true)]
        [InlineData(1, 9, true)]
        [InlineData(2, 0, true)]
        [InlineData(2, 1, true)]
        [InlineData(2, 2, true)]
        [InlineData(2, 3, true)]
        [InlineData(2, 4, true)]
        [InlineData(2, 5, true)]
        [InlineData(2, 6, true)]
        [InlineData(2, 7, true)]
        [InlineData(2, 8, true)]
        [InlineData(2, 9, true)]
        [InlineData(3, 0, true)]
        [InlineData(3, 1, true)]
        [InlineData(3, 2, true)]
        [InlineData(3, 3, true)]
        [InlineData(3, 4, true)]
        [InlineData(3, 5, true)]
        [InlineData(3, 6, true)]
        [InlineData(3, 7, true)]
        [InlineData(3, 8, true)]
        [InlineData(3, 9, true)]
        [InlineData(4, 0, true)]
        [InlineData(4, 1, true)]
        [InlineData(4, 2, true)]
        [InlineData(4, 3, true)]
        [InlineData(4, 4, true)]
        [InlineData(4, 5, true)]
        [InlineData(4, 6, true)]
        [InlineData(4, 7, true)]
        [InlineData(4, 8, true)]
        [InlineData(4, 9, true)]
        [InlineData(5, 0, true)]
        [InlineData(5, 1, true)]
        [InlineData(5, 2, true)]
        [InlineData(5, 3, true)]
        [InlineData(5, 4, true)]
        [InlineData(5, 5, true)]
        [InlineData(5, 6, true)]
        [InlineData(5, 7, true)]
        [InlineData(5, 8, true)]
        [InlineData(5, 9, true)]

        public void CheckForHit_WhenHitReturnsTrue(int x, int y, bool shipOrientation)
        {
            Random r = new Random();

            GameGrid gameGrid = new GameGrid(r);
            bool[,,] gameBoardBoolArray = new bool[10, 10, 2];

            var boardHasShip = gameGrid.DefineShipLocation(gameBoardBoolArray, shipOrientation, x, y);

            ControlFlow groundControl = new ControlFlow();

            Point thisPoint = new Point(x - 1, y - 1);

            var attemptWasAHit = groundControl.CheckForHit(gameGrid, boardHasShip, thisPoint, x, y);

            Assert.True(attemptWasAHit);
        }
    }
}
