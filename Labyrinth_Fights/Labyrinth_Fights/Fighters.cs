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
        public List<Fighter> fightersList;

        public Fighters(FightersFactory Factory)
        {
            fightersList = new List<Fighter>();
            this.factory = Factory;
        }

        public Fighter AskForAFighter(Position position)
        {
            Fighter fighter = factory.CreateFighter(position);
            if (fightersList == null)
            {
                fighter.Id = 0;
            }
            else
            {
                fighter.Id = fightersList.Count;
            }
            fightersList.Add(fighter);
            return fighter;
        }
    }

}
