using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    public class Fighter
    {
        int id;
        int dégats;
        int hp;

        public Position pos;
        public List<Weapon> weapons = new List<Weapon>();
        bool offensif;

        public List<Position> voisinsLibres = new List<Position>();
        public List<Position> Visitees = new List<Position>();
        public Stack<Position> Chemin = new Stack<Position>();

        public bool nordVisite = false;
        public bool sudVisite = false;
        public bool ouestVisite = false;
        public bool estVisite = false;

        public Fighter (Position pos)
        {
            this.pos = pos;
            this.dégats = 10;
            this.hp = 100;
            this.weapons = new List<Weapon>();
            this.offensif = false;
        }

        public Position Nord()
        {
            Position nord = new Position(pos.coord_X - 1, this.pos.coord_Y);
            return nord;
        }

        public Position Sud()
        {
            Position sud = new Position(pos.coord_X + 1, this.pos.coord_Y);
            return sud;
        }

        public Position Est()
        {
            Position est = new Position(pos.coord_X, this.pos.coord_Y+1);
            return est;
        }

        public Position Ouest()
        {
            Position ouest = new Position(pos.coord_X, this.pos.coord_Y-1);
            return ouest;
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
