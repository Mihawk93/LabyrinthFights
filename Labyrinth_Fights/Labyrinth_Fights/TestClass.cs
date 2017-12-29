using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
    class TestClass
    {
        public char[,] TestInitialisation(Labyrinthe maze, string file)
        {
            List<string> liststring = maze.ReadFile(file);
            char[,] matchar = maze.ConvertListStringToMatChar(liststring);
            return matchar;
        }

        public void TestDisplays()
        {
            string file = "..\\..\\mazeGenerator.txt";
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, file);
            Cell[,] cells = maze.CharToCell(matchar);
            //maze.DisplayList(liststring);
            //maze.Displaychar(matchar);
            maze.Display(cells);
        }
        public void TestListPositionLibre()
        {
            string file = "..\\..\\mazeJoute.txt";
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, file);
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            foreach (Position position in positionsLibres)
            {
                Console.WriteLine(position);
            }
        }
        public void TestSpawnCombatant()
        {
            string file = "..\\..\\mazeJoute.txt";
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, file);
            Cell[,] cells = maze.CharToCell(matchar);
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
            Fighter fighter1 = fighterStore.AskForAFighter(rdmPosFighter1);
            positionsLibres.Remove(fighter1.pos);
            maze.Displaychar(matchar);
        }

        public void TestSpawnWeapon()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\mazeGenerator.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.Displaychar(matchar);
            Console.WriteLine();
            Random rand = new Random();
            int index = rand.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index);
            maze.Displaychar(matchar);
        }

        public void TestRépartionCombatant()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\mazeGenerator.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            FightersFactory factory = new FightersFactory();
            Fighters fighterStore = new Fighters(factory);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.Displaychar(matchar);
            Console.WriteLine();
            maze.RepartitionCombatants(matchar, positionsLibres, fighterStore);
            maze.Displaychar(matchar);
        }

        public void TestRépartionWeapon()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\mazeGenerator.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            WeaponsFactory factory = new WeaponsFactory();
            Weapons weaponsStore = new Weapons(factory);
            maze.Displaychar(matchar);
            Console.WriteLine();
            maze.RepartitionWeapon(matchar, positionsLibres, weaponsStore);
            maze.Displaychar(matchar);
        }

        public void TestDeplacement()
        {

            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\theMaze.txt");
            Cell[,] cells = maze.CharToCell(matchar);
            FightersFactory factory = new FightersFactory();
            Fighters fighterStore = new Fighters(factory);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            maze.RepartitionCombatants(matchar, positionsLibres, fighterStore);
            maze.Displaychar(matchar);
            Console.WriteLine();

            Fighter fighter1 = fighterStore.fightersList[0];
            Fighter fighter2 = fighterStore.fightersList[1];
            Fighter fighter3 = fighterStore.fightersList[2];
            maze.Displaychar(matchar);
            Console.WriteLine();
            while (matchar[fighter1.Est().coord_X, fighter1.Est().coord_Y] != '2' && matchar[fighter2.Est().coord_X, fighter2.Est().coord_Y] != '2' && matchar[fighter3.Est().coord_X, fighter3.Est().coord_Y] != '2')
            {
                matchar = maze.Deplacement(matchar, fighter1);
                matchar = maze.Deplacement(matchar, fighter2);
                matchar = maze.Deplacement(matchar, fighter3);
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
            }
            if (matchar[fighter1.Est().coord_X, fighter1.Est().coord_Y] == '2')
            {
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = '0';
                fighter1.pos = fighter1.Est();
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.Write("End of the game");
            }
            if (matchar[fighter2.Est().coord_X, fighter2.Est().coord_Y] == '2')
            {
                matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = '0';
                fighter2.pos = fighter2.Est();
                matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.Write("End of the game");
            }
            if (matchar[fighter3.Est().coord_X, fighter3.Est().coord_Y] == '2')
            {
                matchar[fighter3.pos.coord_X, fighter3.pos.coord_Y] = '0';
                fighter3.pos = fighter3.Est();
                matchar[fighter3.pos.coord_X, fighter3.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.Write("End of the game");
            }
        }

        public void TestRamasserWeapon()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\theMaze.txt");
            Cell[,] cells = maze.CharToCell(matchar);

            FightersFactory factory = new FightersFactory();
            Fighters fighterStore = new Fighters(factory);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            Random rand = new Random();
            int index = rand.Next(positionsLibres.Count);
            maze.SpawnCombatant(matchar, positionsLibres, index);
            Position rdmPosFighter = positionsLibres[index];
            Fighter fighter = fighterStore.AskForAFighter(rdmPosFighter);
            positionsLibres.Remove(fighter.pos);
            maze.Displaychar(matchar);

            WeaponsFactory factory2 = new WeaponsFactory();
            Weapons weaponStore = new Weapons(factory2);
            Random rand2 = new Random();
            int index2 = rand2.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index2);
            Position rdmPosWeapon = positionsLibres[index2 - 1];
            Weapon weapon = weaponStore.AskForWeapon(rdmPosWeapon);
            positionsLibres.Remove(weapon.pos);
            maze.Displaychar(matchar);
            Console.WriteLine("Position du fighter" + fighter.pos);
            Console.WriteLine("Nombre de fighter" + fighterStore.fightersList.Count());

            while (matchar[fighter.Sud().coord_X, fighter.Sud().coord_Y] != '2')
            {

                Weapon weap = maze.ChercheWeapon(weaponStore.ListWeapons, fighter);

                if (weap.pos.coord_X != 0 && weap.pos.coord_Y != 0)
                {
                    fighter.weapons.Add(weap);
                    weap.pos.coord_X = 0;
                    weap.pos.coord_Y = 0;
                }
                matchar = maze.Deplacement(matchar, fighter);
                Console.WriteLine("Nombre de fighter" + fighterStore.fightersList.Count());
                maze.Displaychar(matchar);
                Console.Clear();

                Console.WriteLine("Position du fighter" + fighter.pos);
                Console.WriteLine("rdmposweapon:" + rdmPosWeapon);
                Console.WriteLine(weap.pos);
            }
            if (matchar[fighter.Sud().coord_X, fighter.Sud().coord_Y] == '2')
            {
                maze.Displaychar(matchar);
                matchar[fighter.pos.coord_X, fighter.pos.coord_Y] = '0';
                fighter.pos = fighter.Sud();
                matchar[fighter.pos.coord_X, fighter.pos.coord_Y] = 'X';
                Console.ReadKey();
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine();
                Console.Write("Arme du fighter: ");
                Console.WriteLine(fighter.weapons.Count());
                Console.Write("Arme dans la liste: ");
                Console.WriteLine(weaponStore.ListWeapons.Count());
                Console.Write("End of the game");
            }

        }

        public void TestCombat()
        {
            Labyrinthe maze = new Labyrinthe();
            char[,] matchar = TestInitialisation(maze, "..\\..\\mazeJoute.txt");
            Cell[,] cells = maze.CharToCell(matchar);

            FightersFactory factory = new FightersFactory();
            Fighters fighterStore = new Fighters(factory);
            List<Position> positionsLibres = maze.PositionLibres(cells);
            Random rand = new Random();
            int index = rand.Next(positionsLibres.Count);
            maze.SpawnCombatant(matchar, positionsLibres, index);
            Position rdmPosFighter1 = positionsLibres[index];
            Fighter fighter1 = fighterStore.AskForAFighter(rdmPosFighter1);
            positionsLibres.Remove(fighter1.pos);
            maze.Displaychar(matchar);
            Random rand1 = new Random();
            int index1 = rand1.Next(positionsLibres.Count);
            maze.SpawnCombatant(matchar, positionsLibres, index1);
            Position rdmPosFighter2 = positionsLibres[index1];
            Fighter fighter2 = fighterStore.AskForAFighter(rdmPosFighter2);
            positionsLibres.Remove(fighter2.pos);
            maze.Displaychar(matchar);

            WeaponsFactory factory2 = new WeaponsFactory();
            Weapons weaponStore = new Weapons(factory2);
            Random rand2 = new Random();
            int index2 = rand2.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index2);
            Position rdmPosWeapon = positionsLibres[index2];
            Weapon weapon = weaponStore.AskForWeapon(rdmPosWeapon);
            positionsLibres.Remove(weapon.pos);
            maze.Displaychar(matchar);

            Random rand3 = new Random();
            int index3 = rand3.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index3);
            Position rdmPosWeapon2 = positionsLibres[index3];
            Weapon weapon2 = weaponStore.AskForWeapon(rdmPosWeapon2);
            positionsLibres.Remove(weapon2.pos);

            Random rand4 = new Random();
            int index4 = rand4.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index4);
            Position rdmPosWeapon3 = positionsLibres[index4];
            Weapon weapon3 = weaponStore.AskForWeapon(rdmPosWeapon3);
            positionsLibres.Remove(weapon3.pos);

            Random rand5 = new Random();
            int index5 = rand5.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index5);
            Position rdmPosWeapon4 = positionsLibres[index5];
            Weapon weapon4 = weaponStore.AskForWeapon(rdmPosWeapon4);
            positionsLibres.Remove(weapon4.pos);

            Random rand6 = new Random();
            int index6 = rand6.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index6);
            Position rdmPosWeapon5 = positionsLibres[index6];
            Weapon weapon5 = weaponStore.AskForWeapon(rdmPosWeapon5);
            positionsLibres.Remove(weapon5.pos);

            Random rand7 = new Random();
            int index7 = rand7.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index7);
            Position rdmPosWeapon6 = positionsLibres[index7];
            Weapon weapon6 = weaponStore.AskForWeapon(rdmPosWeapon6);
            positionsLibres.Remove(weapon6.pos);

            Random rand8 = new Random();
            int index8 = rand8.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index8);
            Position rdmPosWeapon7 = positionsLibres[index8];
            Weapon weapon7 = weaponStore.AskForWeapon(rdmPosWeapon7);
            positionsLibres.Remove(weapon7.pos);

            Random rand9 = new Random();
            int index9 = rand9.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index9);
            Position rdmPosWeapon8 = positionsLibres[index9];
            Weapon weapon8 = weaponStore.AskForWeapon(rdmPosWeapon8);
            positionsLibres.Remove(weapon8.pos);

            Random rand10 = new Random();
            int index10 = rand10.Next(positionsLibres.Count);
            maze.SpawnWeapon(matchar, positionsLibres, index10);
            Position rdmPosWeapon9 = positionsLibres[index10];
            Weapon weapon9 = weaponStore.AskForWeapon(rdmPosWeapon9);
            positionsLibres.Remove(weapon9.pos);

           

            maze.Displaychar(matchar);
            Console.WriteLine("Position du fighter 1: " + fighter1.pos);
            Console.WriteLine("Position du fighter 2: " + fighter2.pos);
            Console.WriteLine("Nombre de fighter" + fighterStore.fightersList.Count());

            while (matchar[fighter1.Sud().coord_X, fighter1.Sud().coord_Y] != '2' && matchar[fighter2.Sud().coord_X, fighter2.Sud().coord_Y] != '2')
            {

                Weapon weap1 = maze.ChercheWeapon(weaponStore.ListWeapons, fighter1);
                Weapon weap2 = maze.ChercheWeapon(weaponStore.ListWeapons, fighter2);

                if (weap1.pos.coord_X != 0 && weap1.pos.coord_Y != 0)
                {
                    fighter1.weapons.Add(weap1);
                    fighter1.Dégats += weap1.dégats;
                    weap1.pos.coord_X = 0;
                    weap1.pos.coord_Y = 0;
                }
                if (weap2.pos.coord_X != 0 && weap2.pos.coord_Y != 0)
                {
                    fighter2.weapons.Add(weap2);
                    fighter2.Dégats += weap2.dégats;
                    weap2.pos.coord_X = 0;
                    weap2.pos.coord_Y = 0;
                }

                matchar = CheckFight(matchar, fighterStore, fighter1, fighter2);

                if(fighter1.Hp>0)
                matchar = maze.Deplacement(matchar, fighter1);

                matchar = CheckFight(matchar, fighterStore, fighter1, fighter2);

                if(fighter2.Hp>0)
                matchar = maze.Deplacement(matchar, fighter2);

                matchar = CheckFight(matchar, fighterStore, fighter1, fighter2);

                Console.WriteLine("Nombre de fighter" + fighterStore.fightersList.Count());
                maze.Displaychar(matchar);


                Console.WriteLine("Position du fighter 1: " + fighter1.pos);
                Console.WriteLine("Dégat du fighter 1: " + fighter1.Dégats);
                Console.WriteLine("PV du fighter 1: " + fighter1.Hp);
                Console.WriteLine("Position du fighter 2: " + fighter2.pos);
                Console.WriteLine("Dégat du fighter 2: " + fighter2.Dégats);
                Console.WriteLine("PV du fighter 2: " + fighter2.Hp);
                Console.WriteLine("rdmposweapon:" + rdmPosWeapon);

                Console.ReadKey();
                Console.Clear();
            }
            if (matchar[fighter1.Sud().coord_X, fighter1.Sud().coord_Y] == '2')
            {
                maze.Displaychar(matchar);
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = '0';
                fighter1.pos = fighter1.Sud();
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = 'X';
                Console.ReadKey();
                Console.Clear();
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine();
                Console.Write("Arme du fighter: ");
                Console.WriteLine(fighter1.weapons.Count());
                Console.Write("Arme dans la liste: ");
                Console.WriteLine(weaponStore.ListWeapons.Count());
                Console.Write("End of the game");
            }

        }
        public char[,] CheckFight(char[,] matchar, Fighters fighterStore, Fighter fighter1, Fighter fighter2)
        {
            if (fighter2.pos.coord_X == fighter1.pos.coord_X && fighter2.pos.coord_Y == fighter1.pos.coord_Y && fighter2.weapons.Count() != 0 && fighter1.weapons.Count() != 0)
            {
                while (fighter1.Hp > 0 && fighter2.Hp > 0)
                {
                    //maze.Combat(matchar, fighter1, fighter2);
                    fighter1.Hp = fighter1.Hp - fighter2.Dégats;
                    if (fighter1.Hp <= 0)
                    {
                        fighter1.Dégats = 0;
                        fighterStore.fightersList.Remove(fighter1);
                        matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = '0';
                        Console.WriteLine("Fighter2 a gagné le combat");
                    }
                    if (fighter2.Hp <= 0)
                    {
                        fighter2.Dégats = 0;
                        fighterStore.fightersList.Remove(fighter2);
                        matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = '0';
                        Console.WriteLine("Fighter1 a gagné le combat");
                    }

                    fighter2.Hp = fighter2.Hp - fighter1.Dégats;
                    Console.WriteLine("Fighter1 attaque fighter2");
                    if (fighter1.Hp <= 0)
                    {   
                        fighter1.Dégats = 0;
                        fighterStore.fightersList.Remove(fighter1);
                    }
                    if (fighter2.Hp <= 0)
                    {
                        fighter2.Dégats = 0;
                        fighterStore.fightersList.Remove(fighter2);
                    }
                }

            }
            else
            {

                if (fighter1.pos.coord_X == fighter2.pos.coord_X && fighter1.pos.coord_Y == fighter2.pos.coord_Y && fighter1.weapons.Count() != 0)
                {
                    //maze.Combat(matchar, fighter1, fighter2);
                    fighter2.Hp = fighter2.Hp - fighter1.Dégats;
                    Console.WriteLine("Fighter1 attaque fighter2");
                }
                if (fighter2.pos.coord_X == fighter1.pos.coord_X && fighter2.pos.coord_Y == fighter1.pos.coord_Y && fighter2.weapons.Count() != 0)
                {
                    //maze.Combat(matchar, fighter1, fighter2);
                    fighter1.Hp = fighter1.Hp - fighter2.Dégats;
                    Console.WriteLine("Fighter2 attaque fighter1");
                }
            }
            return matchar;
        }


    }

}
