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
            string file = "..\\..\\theMaze.txt";
            Labyrinthe maze = new Labyrinthe();
            List<string> liststring = maze.ReadFile(file);
            char[,] matchar = maze.ConvertListStringToMatChar(liststring);
            Cell[,] cells = maze.CharToCell(matchar);
            List<Position> positionsLibres = maze.PositionLibres(cells);


            //Répartion Combatants
            FightersFactory factoryFighter = new FightersFactory();
            Fighters fighterStore = new Fighters(factoryFighter);
            maze.RepartitionCombatants(matchar, positionsLibres, fighterStore);

            //Répartion Weapons
            WeaponsFactory factoryWeapons = new WeaponsFactory();
            Weapons weaponStore = new Weapons(factoryWeapons);
            maze.RepartitionWeapon(matchar,positionsLibres, weaponStore);

            //Stockage des Combatants
            Fighter fighter1 = fighterStore.fightersList[0];
            Fighter fighter2 = fighterStore.fightersList[1];
            Fighter fighter3 = fighterStore.fightersList[2];

            //Stockage des Armes
            Weapon weapon1 = weaponStore.ListWeapons[0];
            Weapon weapon2 = weaponStore.ListWeapons[1];
            Weapon weapon3 = weaponStore.ListWeapons[2];

            //Boucle du jeu
            while (matchar[fighter1.Est().coord_X, fighter1.Est().coord_Y] != '2' && matchar[fighter2.Est().coord_X, fighter2.Est().coord_Y] != '2' && matchar[fighter3.Est().coord_X, fighter3.Est().coord_Y] != '2')
            {
                Weapon weap1 = maze.ChercheWeapon(weaponStore.ListWeapons, fighter1);
                Weapon weap2 = maze.ChercheWeapon(weaponStore.ListWeapons, fighter2);
                Weapon weap3 = maze.ChercheWeapon(weaponStore.ListWeapons, fighter3);

                if (weap1.pos.coord_X != 0 && weap1.pos.coord_Y != 0)
                {
                    fighter1.weapons.Add(weap1);
                    weap1.pos.coord_X = 0;
                    weap1.pos.coord_Y = 0;
                }
                if (weap2.pos.coord_X != 0 && weap2.pos.coord_Y != 0)
                {
                    fighter2.weapons.Add(weap2);
                    weap2.pos.coord_X = 0;
                    weap2.pos.coord_Y = 0;
                }
                if (weap3.pos.coord_X != 0 && weap3.pos.coord_Y != 0)
                {
                    fighter3.weapons.Add(weap3);
                    weap3.pos.coord_X = 0;
                    weap3.pos.coord_Y = 0;
                }

                matchar = maze.Deplacement(matchar, fighter1);
                matchar = maze.Deplacement(matchar, fighter2);
                matchar = maze.Deplacement(matchar, fighter3);
                Console.WriteLine("Nombre de fighter: " + fighterStore.fightersList.Count());
                Console.WriteLine("Position du fighter 1 : " + fighter1.pos);
                Console.WriteLine("Arme du fighter 1: " + fighter1.weapons.Count());
                Console.WriteLine("Position du fighter 2 : " + fighter2.pos);
                Console.WriteLine("Arme du fighter 2: " + fighter2.weapons.Count());
                Console.WriteLine("Position du fighter 3 : " + fighter3.pos);
                Console.WriteLine("Arme du fighter 3: " + fighter3.weapons.Count());
                Console.WriteLine();
                Console.WriteLine(weaponStore.ListWeapons.Count());
                foreach(Weapon weapon in weaponStore.ListWeapons)
                {
                    Console.WriteLine(weapon.pos);
                }
                maze.Displaychar(matchar);
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
                
                
            }

            //Condition pour finir la partie
            if (matchar[fighter1.Est().coord_X, fighter1.Est().coord_Y] == '2')
            {
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = '0';
                fighter1.pos = fighter1.Est();
                matchar[fighter1.pos.coord_X, fighter1.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.WriteLine("End of the game");
                Console.WriteLine("Combatant 1 a gagné");
            }
            if (matchar[fighter2.Est().coord_X, fighter2.Est().coord_Y] == '2')
            {
                matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = '0';
                fighter2.pos = fighter2.Est();
                matchar[fighter2.pos.coord_X, fighter2.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.WriteLine("End of the game");
                Console.WriteLine("Combatant 2 a gagné");
            }
            if (matchar[fighter3.Est().coord_X, fighter3.Est().coord_Y] == '2')
            {
                matchar[fighter3.pos.coord_X, fighter3.pos.coord_Y] = '0';
                fighter3.pos = fighter3.Est();
                matchar[fighter3.pos.coord_X, fighter3.pos.coord_Y] = 'X';
                Console.Clear();
                maze.Displaychar(matchar);
                Console.WriteLine("End of the game");
                Console.WriteLine("Combatant 3 a gagné");
            }


            Console.ReadKey();
        }


    }
}
