using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace puissance4
{
    class outils
    {
        public void rempliGrille(out string[,] grille)//remplire la grille
        {
            grille = new string[6, 7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)

                    grille[i, j] = "0";

            }
        }
        public void affichgrille(string[,] grille) //afficher la grille
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grille[i, j] == "0")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        Console.Write(grille[i, j]);
                        Console.Write("|");
                    }
                    else if (grille[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(grille[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(grille[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }
                }
                Console.WriteLine("");
            }

        }
        public void choiPiRedOrYell(int n, bool player, string[,] grille, out string[,] grille2,bool plusdeplace) //definir la couleur du pion jouer 
        {

            if (player == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string pionJoueur = "O";
                string piontAdverse = "o";
                posiPion(n, pionJoueur, piontAdverse, grille, out grille2, plusdeplace);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string pionJoueur = "o";
                string piontAdverse = "O";
                posiPion(n, pionJoueur, piontAdverse, grille, out grille2, plusdeplace);
            }


        }
        public void posiPion(int n, string pionjoueur, string piontAdverse, string[,] grille, out string[,] grille2, bool plusdeplace)//placer le point a partir du numero de colone
        {
            plusdeplace = false;
            int x = 5;
            bool verif = false;
            do
            {
                if (grille[x, n - 1] == "0")
                {
                    grille[x, n - 1] = pionjoueur;
                    verif = true;
                    //affichgrille(grille);
                }
                else if (x == 0 && (grille[x, n - 1] == "o" || grille[x, n - 1] == "O"))
                {
                    Console.WriteLine("vous ne pouvez pas mettre de pion dans cette colone");
                    verif = true;
                    plusdeplace= true;

                }
                else
                {
                    x = x - 1;
                }
            } while (verif == false);
            grille2 = grille;
        }
        public void verifLigne(string[,] grille, out bool verifi) //verifier si il y a 4 pion a la suite horizontalement 
        {
            bool verif = false;
            int i;
            int x = 0;
            do
            {
                i = 0;
                do
                {

                    if (grille[x, i] != "0" && ((grille[x, i] == grille[x, i + 1]) && (grille[x, i + 1] == grille[x, i + 2]) && (grille[x, i + 2] == grille[x, i + 3])))
                    {
                        verif = true;
                        //Console.WriteLine("noooooo");
                    }
                    else
                    {
                        i = i + 1;
                        //Console.WriteLine("no");
                    }
                } while (verif == false && i < 3);
                x = x + 1;
            } while (verif == false && x < 6);


            verifi = verif;
        }
        public void veriColone(string[,] grille, out bool verifi)//verifier si il y a 4 pion a la suite verticalement
        {
            bool verif = false;
            int i = 0;
            int x;
            do
            {
                x = 0;
                do
                {

                    if (grille[x, i] != "0" && ((grille[x, i] == grille[x + 1, i]) && (grille[x + 1, i] == grille[x + 2, i]) && (grille[x + 2, i] == grille[x + 3, i])))
                    {
                        verif = true;
                        //Console.WriteLine("noooooo");
                    }
                    else
                    {
                        x = x + 1;
                        //Console.WriteLine("no");
                    }
                } while (verif == false && x < 3);
                i = i + 1;
            } while (verif == false && i < 5);


            verifi = verif;
        }
        public void verifDiago(string[,] grille, out bool verifi)//verifier si il y a 4 pion a la suite en diagonale 
        {
            bool verif = false;
            int i = 0;
            int x;
            do
            {
                x = 0;
                do
                {

                    if (grille[x, i] != "0" && ((grille[x, i] == grille[x + 1, i+1]) && (grille[x + 1, i+1] == grille[x + 2, i+2]) && (grille[x + 2, i+2] == grille[x + 3, i+3])))
                    {
                        verif = true;
                        //Console.WriteLine("noooooo");
                    }
                    else
                    {
                        x = x + 1;
                        //Console.WriteLine("no");
                    }
                } while (verif == false && x < 3);
                i = i + 1;
            } while (verif == false && i < 5);


            verifi = verif;
        }
        public void tryparse(out int n)
        {
            bool trypasse;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("dans quel colone voulez vous mettre votre pion?");
            do
            {

                trypasse = false;

                if (int.TryParse(Console.ReadLine(), out n))
                {
                    if (n < 0 || n > 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("    __________  ____  ____  ____ ");
                        Console.WriteLine("   / ____/ __ \\/ __ \\/ __ \\/ __ \\");
                        Console.WriteLine("  / __/ / /_/ / /_/ / / / / /_/ /");
                        Console.WriteLine(" / /___/ _, _/ _, _/ /_/ / _, _/ ");
                        Console.WriteLine("/_____/_/ |_/_/ |_|\\____/_/ |_|  ");
                        Console.WriteLine("ENTREE INCORRECT veuillez entrez une numero de colone  correct");
                    }
                    else
                    {
                        trypasse = true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    __________  ____  ____  ____ ");
                    Console.WriteLine("   / ____/ __ \\/ __ \\/ __ \\/ __ \\");
                    Console.WriteLine("  / __/ / /_/ / /_/ / / / / /_/ /");
                    Console.WriteLine(" / /___/ _, _/ _, _/ /_/ / _, _/ ");
                    Console.WriteLine("/_____/_/ |_/_/ |_|\\____/_/ |_|  ");
                    Console.WriteLine("ENTREE INCORRECT veuillez entrez une valeur correct");
                }
            } while (trypasse == false);

        }
    }
}
