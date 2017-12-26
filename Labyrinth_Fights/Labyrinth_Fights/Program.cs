using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialisation
            string file = "..\\..\\mazeJoute.txt";
            Labyrinthe maze = new Labyrinthe();
            List<string> liststring = maze.ReadFile(file);
            char[,] matchar = maze.ConvertListStringToMatChar(liststring);
            Cell[,] cells = maze.CharToCell(matchar);

            maze.Displaychar(matchar);
            
            Console.WriteLine();

            //Spawn Combatant
            List<Position> positionsLibres = maze.PositionLibres(cells);
            foreach (Position pose in positionsLibres)
            {
                Console.Write(pose);
            }
            Console.WriteLine();

            Random rand = new Random();
            int index = rand.Next(positionsLibres.Count);
            Position rdmPosFighter1 = positionsLibres[index];
            //Console.WriteLine(rdmPosition);
            FightersFactory factoryFighter = new FightersFactory();
            Fighters fighterStore = new Fighters(factoryFighter);
            Fighter fighter1= fighterStore.AskForAFighter(rdmPosFighter1);
            positionsLibres.Remove(fighter1.pos);
            Console.WriteLine();
            Console.WriteLine(rdmPosFighter1);
            Console.WriteLine(fighter1.pos);
            Console.WriteLine();

            matchar[rdmPosFighter1.coord_X, rdmPosFighter1.coord_Y] = 'X';


            maze.Displaychar(matchar);
            foreach (Position pose in positionsLibres)
            {
                Console.Write(pose);
            }
            Console.WriteLine();

            index = rand.Next(positionsLibres.Count);
            Position rdmPosFighter2 = positionsLibres[index];
            //Console.WriteLine(rdmPosition);
            Fighter fighter2 = fighterStore.AskForAFighter(rdmPosFighter2);
            positionsLibres.Remove(fighter2.pos);
            matchar[rdmPosFighter2.coord_X, rdmPosFighter2.coord_Y] = 'X';

            maze.Displaychar(matchar);
            Console.WriteLine(rdmPosFighter2);
            Console.WriteLine(fighter2.pos);

            foreach (Position pose in positionsLibres)
            {
                Console.Write(pose);
            }
            Console.WriteLine();



            //spawn un objet
            index = rand.Next(positionsLibres.Count);
            Position rdmPosWeapon = positionsLibres[index];
            WeaponsFactory factoryWeapon = new WeaponsFactory();
            Weapons weaponStore = new Weapons(factoryWeapon);
            Weapon weapon1 = weaponStore.AskForWeapon(rdmPosWeapon);
            positionsLibres.Remove(weapon1.pos);
            if (weapon1 is Epee)
            {
                matchar[rdmPosWeapon.coord_X, rdmPosWeapon.coord_Y] = 'E';

            }
            if (weapon1 is Dague)
            {
                matchar[rdmPosWeapon.coord_X, rdmPosWeapon.coord_Y] = 'D';

            }
            if (weapon1 is Hache)
            {
                matchar[rdmPosWeapon.coord_X, rdmPosWeapon.coord_Y] = 'H';

            }
            if (weapon1 is Lance)
            {
                matchar[rdmPosWeapon.coord_X, rdmPosWeapon.coord_Y] = 'L';

            }




            maze.Displaychar(matchar);
            Console.WriteLine();
            Console.WriteLine(rdmPosWeapon);

            foreach (Position pose in positionsLibres)
            {
                Console.Write(pose);
            }
            Console.WriteLine();

            Console.ReadKey();
        }


    }
}
