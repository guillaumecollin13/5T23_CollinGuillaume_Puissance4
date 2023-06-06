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
            bool plusdeplace = false;
            string ni = "y";
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" _______          _________ _______  _______  _______  _        _______  _______       ___");
                Console.WriteLine("(  ____ )|\\     /|\\__   __/(  ____ \\(  ____ \\(  ___  )( (    /|(  ____ \\(  ____ \\     /   )");
                Console.WriteLine("| (    )|| )   ( |   ) (   | (    \\/| (    \\/| (   ) ||  \\  ( || (    \\/| (    \\/    / /) |");
                Console.WriteLine("| (____)|| |   | |   | |   | (_____ | (_____ | (___) ||   \\ | || |      | (__       / (_) (_ ");
                Console.WriteLine("|  _____)| |   | |   | |   (_____  )(_____  )|  ___  || (\\ \\) || |      |  __)     (____   _)");
                Console.WriteLine("| (      | |   | |   | |         ) |      ) || (   ) || | \\   || |      | (             ) (   ");
                Console.WriteLine("| )      | (___) |___) (___/\\____) |/\\____) || )   ( || )  \\  || (____/\\| (____/\\       | |  ");
                Console.WriteLine("|/       (_______)\\_______/\\_______)\\_______)|/     \\||/    )_)(_______/(_______/       (_)  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("voulez vous lire les regle?si oui tapez y, sinon tapez n");
                ni=Console.ReadLine();
                if (ni=="y")
                {
                    Console.WriteLine("Le but du jeu est d'aligner une suite de 4 pions de même couleur sur une grille comptant 6 ");
                    Console.WriteLine("rangées et 7 colonnes. Chaque joueur dispose de 21 pions d'une couleur (par convention, en ");
                    Console.WriteLine("général jaune ou rouge). Tour à tour, les deux joueurs placent un pion dans la colonne de ");
                    Console.WriteLine("leur choix, le pion coulisse alors jusqu'à la position la plus basse possible dans ladite");
                    Console.WriteLine("colonne à la suite de quoi c'est à l'adversaire de jouer. Le vainqueur est le joueur qui ");
                    Console.WriteLine("réalise le premier un alignement (horizontal, vertical ou diagonal) consécutif d'au moins ");
                    Console.WriteLine("quatre pions de sa couleur. Si, alors que toutes les cases de la grille de jeu sont remplies,");
                    Console.WriteLine(" aucun des deux joueurs n'a réalisé un tel alignement, la partie est déclarée nulle.");
                }
                
                
                
                
                
                
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

                    do
                    {
                        outils.tryparse(out n);
                        outils.choiPiRedOrYell(n, player, grille, out grille, plusdeplace);
                    } while (plusdeplace);
                    outils.verifLigne(grille, out verif);
                    if (verif == false)
                    {
                        outils.veriColone(grille, out verif);
                        if (verif == false)
                        {
                            outils.verifDiago(grille, out verif);
                        }
                    }
                    if (verif)
                    {
                        outils.affichgrille(grille);
                    }
                    compt = compt + 1;
                    player = !player;
                } while (compt < 43 && verif == false);
                Console.WriteLine("voulezvous recomencez?");
                Console.WriteLine("oui(y) non(n)");
                replay = Console.ReadLine();
                Console.Clear();
            } while (replay == "y");
        }
    }
}
