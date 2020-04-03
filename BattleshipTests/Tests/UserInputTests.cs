using Battleship;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleshipTests.Tests
{
    public class UserInputTests
    {
        Random random;
        GameGrid gameGrid;
        ControlFlow ControlF;
        UserInput userInput;

        [Theory]
        [InlineData(RowOrColumn.Row, "1")]
        [InlineData(RowOrColumn.Row, "2")]
        [InlineData(RowOrColumn.Row, "3")]
        [InlineData(RowOrColumn.Row, "4")]
        [InlineData(RowOrColumn.Row, "5")]
        [InlineData(RowOrColumn.Row, "6")]
        [InlineData(RowOrColumn.Row, "7")]
        [InlineData(RowOrColumn.Row, "8")]
        [InlineData(RowOrColumn.Row, "9")]
        [InlineData(RowOrColumn.Row, "10")]
        [InlineData(RowOrColumn.Column, "1")]
        [InlineData(RowOrColumn.Column, "2")]
        [InlineData(RowOrColumn.Column, "3")]
        [InlineData(RowOrColumn.Column, "4")]
        [InlineData(RowOrColumn.Column, "5")]
        [InlineData(RowOrColumn.Column, "6")]
        [InlineData(RowOrColumn.Column, "7")]
        [InlineData(RowOrColumn.Column, "8")]
        [InlineData(RowOrColumn.Column, "9")]
        [InlineData(RowOrColumn.Column, "10")]
        public void ProcessUserInput_ValidInputs_ReturnTrue(RowOrColumn rowOrColumn, string number)
        {
            random = new Random();
            gameGrid = new GameGrid(random);
            ControlF = new ControlFlow(gameGrid);
            userInput = new UserInput(gameGrid);

            var validUserInput = userInput.ProcessUserInput(RowOrColumn.Row, number);
            Assert.True(validUserInput > 0 && validUserInput <= 10);
        }
    }
}
