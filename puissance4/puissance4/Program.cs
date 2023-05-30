using System;

namespace puissance4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] grille = new string[6, 7];//grille de jeux
            int n;// numero de la colone dans laquelle le joueur veut rentrez son pion 
            string replay;//pour rejouer
            string n1 = "lol";
            string n2 = "LOL";
            if (n1==n2)
            {
                Console.WriteLine("noooooo");
            }
            else
            {
                Console.WriteLine("yesssss");
            }
            do
            {
                bool player = true;//bool qui montre quelle joueur joue
                bool verif = false;//bool qui montre que l'un des joueur a gagne
                int compt = 1;//compteur de coup 
                outils outils = new outils();
                outils.rempliGrille(out grille);
                do
                {
                    if (player == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("joueur 1");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("joueur 2");
                    }
                    outils.affichgrille(grille);
                    outils.tryparse(out n);

                    outils.choiPiRedOrYell(n, player, grille, out grille);
                    outils.verifLigne(grille, out verif);
                    if (verif==false)
                    {
                       outils.veriColone(grille, out verif);
                    }
                    compt = compt + 1;
                    player = !player;
                } while (compt < 43 && verif == false);
                Console.WriteLine("voulezvous recomencez?");
                Console.WriteLine("oui(y) non(n)");
                replay = Console.ReadLine();
            } while (replay == "y");
        }
    }
}
