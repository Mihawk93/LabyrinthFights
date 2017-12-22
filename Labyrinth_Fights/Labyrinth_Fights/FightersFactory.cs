using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class FightersFactory
    {
        public Fighter createFighter(Position pos) // Crée les combatants 2.0
        {
            Fighter fighter = new Fighter(pos);
            return fighter;

        }
    }
}
