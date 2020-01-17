using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Parabool
    {
        public Parabool(bool hasAShip, bool hasAHit)
        {
            HasAShip = hasAShip;
            HasAHit = hasAHit;
        }

        public bool HasAShip { get; private set; }

        public bool HasAHit { get; private set; }
    }
}
