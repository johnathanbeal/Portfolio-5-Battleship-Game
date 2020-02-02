using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;

namespace Battleship
{
    public class ControlFlow
    {
        private int hasAShip = 0;
        private int hasAHit = 1;

        public int HasAShip { get { return hasAShip; } private set { } }
        public int HasAHit { get { return hasAHit; } private set { } }


        const int MAXNUMBEROFHITSPERGAME = 5;
        const int NUMBEROFTURNSPERGAME = 8;
        public string CheckNumberOf(int _hitCounter)
        {
            string message;
            if (_hitCounter == MAXNUMBEROFHITSPERGAME)
            {
                message = "You sunk my battleship!\n";
                Console.WriteLine(message.ToUpper());
                return message;
            }
            else
            {
                message = "Number of hits is " + _hitCounter + "\n";
                Console.WriteLine(message);
                return message;
            }
        }

        public string IsItTheEnd(int _hitCounter, int _turnCounter)
        {
            string message;
            if (_hitCounter == MAXNUMBEROFHITSPERGAME || _turnCounter == NUMBEROFTURNSPERGAME)
            {
                message = "GAME OVER!!!\n";
                Console.WriteLine(message);
            }
            else
            {
                message = "The Game is Not Over!\n";
                Console.WriteLine(message);
            }
            return message;
        }

        public int HandleInput(bool[,,] gameOnBoolArray, int output, string gridPoint)
        {
            bool gridPointHasNotBeenConvertedToValidInt = true;

            int i = 0;
            while (gridPointHasNotBeenConvertedToValidInt && i < 10)
            {
                gridPointHasNotBeenConvertedToValidInt = !ParseGridPoint(gridPoint, out output, gameOnBoolArray);
                i++;
            }
            //output = int.Parse(gridPoint);
            return output;
        }

        public bool ParseGridPoint(string _userInput, out int _output, bool[,,] _gameOnBoolArray)
        {
            string[] _messages;

            if (int.TryParse(_userInput, out _output) == true)
            {
                if (ConsoleMessage(_output, _userInput, out _messages, _gameOnBoolArray)[0].Contains("You selected number") && (_output < 1 || _output > 10))
                {
                    Console.WriteLine(_messages[0]);
                    return false;
                }
                else if (ConsoleMessage(_output, _userInput, out _messages, _gameOnBoolArray)[0].Contains("You selected number") && (_output > 1 && _output < 10))
                {
                    Console.WriteLine(_messages[0]);
                    return true;
                }
                else
                {
                    Console.WriteLine(_messages[0]);
                    return !false;
                }
            }
            else if (_userInput == "CHEATCODE")
            {
                for (int x = 0; x < 5; x++)
                {
                    var cheatCodeMessages = CHEATCODE(_gameOnBoolArray);
                    Console.WriteLine(cheatCodeMessages[x]);
                }
                return !false;
            }
            else
            {
                ConsoleMessage(_output, _userInput, out _messages, _gameOnBoolArray);
                Console.WriteLine(_messages[0]);
                return !false;
            }
        }

        public string[] ConsoleMessage(int? _output, string _consoleReadlineInput, out string[] _message, bool[,,] _gameOnBoolArray)
        {
            _message = new string[5];
            int thisInt;
            try
            {
                thisInt = (int)_output;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                thisInt = 0;
            }


            if (_consoleReadlineInput == "CHEATCODE")
            {
                _message = CHEATCODE(_gameOnBoolArray);
                return _message;
            }
            else if (int.TryParse(_consoleReadlineInput, out thisInt) && (_output > 10 || _output < 1))
            {
                _message[0] = "You selected a number greater than 10 or less than 1.  Epic fail.\n";
                return _message;
            }
            else if (_output < 10 && _output >= 1)
            {
                _message[0] = "You selected number " + _output + " for this turn\n";
                return _message;
            }
            else
            {
                _message[0] = "The input is not correct";
                return _message;
            }
        }

        public string[] CHEATCODE(bool[,,] _gameOnBoolArray)
        {
            int _counter = 0;
            string[] _insideMessage = new string[5];

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (_gameOnBoolArray[x, y, 0])
                    {
                        _insideMessage[_counter] = "Coordinates " + x + ", " + y + " have a ship";
                        _counter++;
                    }
                }
            }
            return _insideMessage;
        }

        //private bool[,,] CheckForHit(bool[,,] buul, int x, int y)
        //{
        //    if (buul[x - 1, y - 1, hasAShip] == true)
        //        buul[x - 1, y - 1, hasAHit] = true;

        //    return buul;
        //}

        public bool CheckForHit(GameGrid _game, bool[,,] _gameBoolArray, Point _point, int _inputOne, int _inputTwo)
        {
            Console.WriteLine("CHECKING FOR HIT\n");

            var shipWasHit = AttemptWorkflow(_game, _gameBoolArray, _point, _inputOne, _inputTwo);
            return shipWasHit;
        }

        private bool AttemptWorkflow(GameGrid _gamePlay, bool[,,] _gameBoard, Point _point, int _inputOne, int _inputTwo)
        {
            var battleshipWasHit = false;
            var attemptsRecord = _gamePlay.GetAttemptsList();

            if (attemptsRecord.Any(r => r.Item1 == _point))
            {
                Console.WriteLine("You have already attempted to hit at these coordinates\n");
            }
            else if (AttemptWasAHit(_gameBoard, _inputOne, _inputTwo))
            {                
                battleshipWasHit = true;
                Console.WriteLine("ITS A HIT!!!\n");
                return battleshipWasHit;
            }
            else if (!AttemptWasAHit(_gameBoard, _inputOne, _inputTwo))
            {
               
                Console.WriteLine("You missed!\n");
            }
            else
            {
                Console.WriteLine("The input was unknown\n");
            }
            return false;
        }

        private bool AttemptWasAHit(bool[,,] _gameBoolArray, int _inputOne, int _intputTwo)
        {
            bool wasAHit;
            try
            {
                wasAHit = _gameBoolArray[_inputOne, _intputTwo, HasAShip];
            }
            catch(System.IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                throw new System.ArgumentOutOfRangeException("index parameter is out of range.", ex);
            }

            return wasAHit;
        }
    }
}
