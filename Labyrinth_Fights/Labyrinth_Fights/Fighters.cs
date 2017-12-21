using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Fighters
    {
        FightersFactory factory;
        List<Fighter> fightersList;

        public Fighters(FightersFactory Factory)
        {
            fightersList = null;
            this.factory = Factory;
        }

        public Fighter AskForAFighter()
        {
            Fighter fighter = null ;
            if (fightersList == null)
            {
                fighter = factory.createFighter();
                fighter.SetId(0);
            }
            else
            {
                //Trouver l'id du fihgter en dernière position dans la list puis attribuer l'id du nouveau fighter (=celui de l'ancien +1)
            }
            return fighter;
        }
    }

}
