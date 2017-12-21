using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Fights
{
 
    class Labyrinthe
    {
        //attributs
        public int width;
        public int length;
        string[] champs;
        char[,] MatriceFile;
        
        List<Position> nombreDePositionLibre;
        int[,] map;

        public void SetNombreDePositionLibre()
        {
            for(int i=0; i<map.GetLength(0);i++)
            {
                for(int j=0;j<map.GetLength(1);j++)
                {
                    if (map[i, j] == 0)
                    {
                        Position position = new Position(i, j);
                        nombreDePositionLibre.Add(position);
                    }
                        
                }
            }    
        }
        
        
        
        public void ReadAndStore(string fileName)
        {
            StreamReader input = null;
            string line;
            width = 0;
            length = 0;
            try
            {
                input = new StreamReader(fileName); //try to open the txt if it exists or try to read if we have the right to
                //throws exception otherwise

                while ((line = input.ReadLine()) != null)
                {
                    //line store the actual line

                    foreach (char letters in line)
                    {


                    }
                    champs = line.Split(';');
                    width = champs[0].Length;


                }
                Console.WriteLine();
                length++;

            }

            catch (Exception e)
            {
                Console.WriteLine("exception : " + e.Message);
            }

            finally
            {
                if (input != null)
                {
                    input.Close();
                }
            }


        }


        




        public void ReadFile(string fileName)
        {
            StreamReader input = null;
            string line;
            width = 0;
            length = 0;
            try
            {
                input = new StreamReader(fileName); //try to open the txt if it exists or try to read if we have the right to
                //throws exception otherwise

                while ((line = input.ReadLine()) != null)
                {
                    //line store the actual ligne
             
                    foreach (char letters in line) {

                        
                        
                                switch (letters)
                            {
                                case '1':
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("■");
                                    Console.ResetColor();
                                    break;
                                case '2':
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("■");
                                    Console.ResetColor();
                                    break;
                                case '0':
                                    Console.Write(" ");
                                    break;
                                default:
                                    Console.Write("what");
                                    break;        
                            }
                            champs = line.Split(';');
                            width = champs[0].Length;

                            


                          

                    }
                    Console.WriteLine();
                    length++;
                    
                    


                }

            }

            catch (Exception e)
            {
                Console.WriteLine("exception : " + e.Message);
            }

            finally
            {
                if (input != null)
                {
                    input.Close();
                }
            }

        }
        
        
        
        
    }
}
