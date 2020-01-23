using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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
        public void CheckNumberOf(int _turnCounter)
        {
            if (_turnCounter == MAXNUMBEROFHITSPERGAME)
            {
                Console.WriteLine("You sunk my battleship!");
            }
            else
            {
                Console.WriteLine("Number of hits is " + _turnCounter);
            }
        }

        public void IsItTheEnd(int _hitCounter)
        {
            if (_hitCounter == NUMBEROFTURNSPERGAME)
            {
                Console.WriteLine("GAME OVER!!!");
            }
            else
            {
                Console.WriteLine("The Game is Not Over!");
            }
        }

        public void HandleInput(bool[,,] gameOnBoolArray, out int output)
        {
            bool inputIsNotVerifiedAsValid = true;
            string gridPoint = "";
            while (inputIsNotVerifiedAsValid)
            {
                Console.WriteLine("SELECT A NUMBER BETWEEN 1 AND 10");
                gridPoint = Console.ReadLine();

                if (int.TryParse(gridPoint, out output) == true)
                {
                    if (output > 10 || output < 1)
                    {
                        Console.WriteLine("You selected a number greater than 10 or less than 1.  Epic fail.");
                    }
                    else
                    {
                        inputIsNotVerifiedAsValid = false;
                        Console.WriteLine("You selected number " + output + " for this turn");
                    }
                }
                else if (gridPoint == "CHEATCODE")
                {
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (gameOnBoolArray[x, y, 0])
                            {
                                Console.WriteLine("Coordinates " + x + ", " + y + " have a ship");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The input is not a whole number");
                }
            }
            output = int.Parse(gridPoint);

        }

        private bool[,,] CheckForHit(bool[,,] buul, int x, int y)
        {
            if (buul[x - 1, y - 1, hasAShip] == true)
                buul[x - 1, y - 1, hasAHit] = true;

            return buul;
        }

        public void CheckForHitWorkflow(GameGrid _game, bool[,,] _gameBoolArray, Point _point, int _inputOne, int _inputTwo, int _turnCounter, int _hitCounter, out int _turnCounterOut, out int _hitCounterOut)
        {
            Console.WriteLine("CHECKING FOR HIT");

            var _turnCount_HeadCount = AttemptWorkflowHit(_game, _gameBoolArray, _point, _inputOne, _inputTwo, _turnCounter, _hitCounter);
            _turnCounterOut = _turnCount_HeadCount.Item1;
            _hitCounterOut = _turnCount_HeadCount.Item2;

            var _headCount_TurnCount = AttemptWorkflowMiss(_game, _gameBoolArray, _point, _inputOne, _inputTwo, _turnCounter, _hitCounter);
            _turnCounterOut = _headCount_TurnCount.Item1;
            _hitCounterOut = _turnCount_HeadCount.Item2;
        }

        private bool AttemptWasAHit(bool[,,] _gameBoolArray, int _inputOne, int _intputTwo)
        {
            return _gameBoolArray[_inputOne - 1, _intputTwo - 1, HasAHit];
        }

        private Tuple<int, int> AttemptWorkflowHit(GameGrid _gamePlay, bool[,,] _gameBoard, Point _point, int _inputOne, int _inputTwo, int _turnCounter, int _hitCounter)
        {

            int _turnCounterLocalScope;
            int _hitCounterLocalScope;
            if (AttemptWasAHit(_gameBoard, _inputOne, _inputTwo))
            {
                var attemptsRecord = _gamePlay.GetAttemptsRecord();
                foreach (Point xy in attemptsRecord)
                {
                    if (xy == _point)
                    {
                        Console.WriteLine("You have already attempted to hit at these coordinates");
                        _turnCounterLocalScope = _turnCounter + 1;
                        _hitCounterLocalScope = _hitCounter;
                        break;
                    }
                    else
                    {
                        _gamePlay.SetAttemptsRecord(_inputOne, _inputTwo, _turnCounter);
                        _hitCounter++;
                        _turnCounterLocalScope = _turnCounter + 1;
                        Console.WriteLine("ITS A HIT!!!");
                        break;
                    }
                }
            }
            Tuple<int, int> _turnCount_hitCount = new Tuple<int, int>(_turnCounter, _hitCounter);
            return _turnCount_hitCount;
        }



        private Tuple<int, int> AttemptWorkflowMiss(GameGrid _gamePlay, bool[,,] _gameBoard, Point _point, int _inputOne, int _inputTwo, int _turnCounter, int _hitCounter)
        {
            if (!AttemptWasAHit(_gameBoard, _inputOne, _inputTwo))
            {
                var attemptsRecord = _gamePlay.GetAttemptsRecord();
                foreach (Point xy in attemptsRecord)
                {
                    if (xy == _point)
                    {
                        Console.WriteLine("You have already attempted to hit at these coordinates");
                        _turnCounter++;
                        break;
                    }
                    else
                    {
                        _gamePlay.SetAttemptsRecord(_inputOne, _inputTwo, _turnCounter);
                        _hitCounter++;
                        _turnCounter++;
                        Console.WriteLine("You missed!");
                        break;
                    }
                }              
            }
            Tuple<int, int> _turnCount_hitCount = new Tuple<int, int>(_turnCounter, _hitCounter);
            return _turnCount_hitCount;
        }

    }
}
