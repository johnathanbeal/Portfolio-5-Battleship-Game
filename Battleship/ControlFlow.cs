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
        public void CheckNumberOf(int _turnCounter)
        {
            if (_turnCounter == MAXNUMBEROFHITSPERGAME)
            {
                Console.WriteLine("You sunk my battleship!\n");
            }
            else
            {
                Console.WriteLine("Number of hits is " + _turnCounter + "\n");
            }
        }

        public void IsItTheEnd(int _hitCounter, int _turnCounter)
        {
            if (_hitCounter == MAXNUMBEROFHITSPERGAME || _turnCounter == NUMBEROFTURNSPERGAME)
            {
                Console.WriteLine("GAME OVER!!!\n");
            }
            else
            {
                Console.WriteLine("The Game is Not Over!\n");
            }
        }

        public void HandleInput(bool[,,] gameOnBoolArray, out int output)
        {
            bool inputIsNotVerifiedAsValid = true;
            string gridPoint = "";
            while (inputIsNotVerifiedAsValid)
            {
                Console.WriteLine("SELECT A NUMBER BETWEEN 1 AND 10\n");
                gridPoint = Console.ReadLine() + "\n";

                if (int.TryParse(gridPoint, out output) == true)
                {
                    if (output > 10 || output < 1)
                    {
                        Console.WriteLine("You selected a number greater than 10 or less than 1.  Epic fail.\n");
                    }
                    else
                    {
                        inputIsNotVerifiedAsValid = false;
                        Console.WriteLine("You selected number " + output + " for this turn\n");
                    }
                }
                else if (gridPoint == "CHEATCODE\n")
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
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("The input is not a whole number\n");
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

        public bool CheckForHit(GameGrid _game, bool[,,] _gameBoolArray, Point _point, int _inputOne, int _inputTwo)
        {
            Console.WriteLine("CHECKING FOR HIT\n");

            var shipWasHit = AttemptWorkflow(_game, _gameBoolArray, _point, _inputOne, _inputTwo);
            return shipWasHit;
        }

        private bool AttemptWorkflow(GameGrid _gamePlay, bool[,,] _gameBoard, Point _point, int _inputOne, int _inputTwo)
        {
            var battleshipWasHit = false;
            //int _turnCounterLocalScope;
            //int _hitCounterLocalScope;
            var attemptsRecord = _gamePlay.GetAttemptsRecord();

            if (attemptsRecord.Any(r => r == _point))
            {
                Console.WriteLine("You have already attempted to hit at these coordinates\n");
                //_turnCounterLocalScope = _turnCounter + 1;
                //_hitCounterLocalScope = _hitCounter;
                //return battleshipWasHit;
            }
            else if (AttemptWasAHit(_gameBoard, _inputOne, _inputTwo))
            {
                //var attemptsList = attemptsRecord.ToList();
                
                    
                    //else
                    //{
                        battleshipWasHit = true;

                        //_turnCounterLocalScope = _turnCounter + 1;
                        Console.WriteLine("ITS A HIT!!!\n");
                        return battleshipWasHit;
                   // }                
            }
            else if (!AttemptWasAHit(_gameBoard, _inputOne, _inputTwo))
            {
                //var attemptsRecord = _gamePlay.GetAttemptsRecord();
                ////foreach (Point xy in attemptsRecord)
                ////{
                //    if (attemptsRecord.Any(r => r == _point))
                //    {
                //        Console.WriteLine("You have already attempted to hit at these coordinates\n");
                //        //_turnCounter++;
                //        return battleshipWasHit;
                //    }
                //    else
                //    {
                        //_gamePlay.SetAttemptsRecord(_inputOne, _inputTwo, _turnCounter);
                        //_hitCounter++;
                        //_turnCounter++;
                        Console.WriteLine("You missed!\n");
                        //return battleshipWasHit;
                    //}
                //}
            }
            else
            {
                Console.WriteLine("The input was unknown\n");
                //battleshipWasHit = null;
                //return battleshipWasHit;
            }
            return false;
        }

        private bool AttemptWasAHit(bool[,,] _gameBoolArray, int _inputOne, int _intputTwo)
        {
            var wasAHit = _gameBoolArray[_inputOne - 1, _intputTwo - 1, HasAShip];

            return wasAHit;
        }

        //private Tuple<int, int> AttemptWorkflowMiss(GameGrid _gamePlay, bool[,,] _gameBoard, Point _point, int _inputOne, int _inputTwo, int _turnCounter, int _hitCounter)
        //{

        //    Tuple<int, int> _turnCount_hitCount = new Tuple<int, int>(_turnCounter, _hitCounter);
        //    return _turnCount_hitCount;
        //}

    }
}
