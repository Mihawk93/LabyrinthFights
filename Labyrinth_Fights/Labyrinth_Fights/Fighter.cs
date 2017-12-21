using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Fighter
    {
        protected int id;
        int dégats;
        int hp;
        int coord_X;
        int coord_Y;
        List<Weapon> weapons;
        bool offensif;

        public Fighter (int X , int Y)
        {
            this.coord_X = X;
            this.coord_Y = Y;
            dégats = 10;
            hp = 100;
            weapons = new List<Weapon>();
            bool offensif = false;
        }

        public int GetId()
        {
            return this.id;
        }

        public void SetId(int ID)
        {
            this.id = ID;
        }
    }
}
