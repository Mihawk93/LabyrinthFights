using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class FightersFactory
    {
        public Fighter createFighter(int X, int Y)
        {
            Fighter fighter = new Fighter(X,Y);
            return fighter;
        }
    }
}
