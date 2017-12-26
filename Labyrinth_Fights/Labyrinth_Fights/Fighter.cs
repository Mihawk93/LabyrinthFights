using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Fighter
    {
        int id;
        int dégats;
        int hp;

        public Position pos;
        List<Weapon> weapons;
        bool offensif;


        public Fighter (Position pos)
        {
            this.pos = pos;
            this.dégats = 10;
            this.hp = 100;
            this.weapons = new List<Weapon>();
            this.offensif = false;
        }


        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        public int Dégats
        {
            get { return dégats; }
            set { dégats = value; }

        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }


        public Position Pos
        {
            get { return pos; }
            set { pos = value; }

        }

        public bool Offensif
        {
            get { return offensif; }
            set { offensif = value; }

        }




    }
}
