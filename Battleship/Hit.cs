using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public enum Hit
    {
        NoTry,
        Miss,
        Hit
    }

    public static class HitClass
    {
        public static Hit ifBattleShipAttempt(bool wasAHit)
        {
            if (wasAHit)
            {
                return Hit.Hit;
            }
            else if (!wasAHit)
            {
                return Hit.Miss;
            }
            else
            {
                return Hit.NoTry;

            }
        }
    }

    
}
