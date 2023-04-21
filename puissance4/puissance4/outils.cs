using System;
using System.Collections.Generic;
using System.Text;

namespace puissance4
{
    class outils
    {
        public void rempliGrille(out string[,] grille)
        {
            grille = new string[6,7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)

                    grille[i,j] = "0";

            }
        }
        public void affichgrille(string[,] grille)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grille[i,j]=="0")
                    {
                        Console.Write(grille[i, j]);
                    }
                    else if (grille[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(grille[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(grille[i, j]);
                    }
                }
                Console.WriteLine("");
            }

        }
    }
}
