using System;

namespace puissance4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] grille = new string[6,7];//grille de jeux
            bool player;//bool qui montre quelle joueur joue
            int n;// numero de la colone dans laquelle le joueur veut rentrez son pion 
            int compt=1;//compteur de coup joue  
            outils outils = new outils();
            outils.rempliGrille(out grille);
            do
            {
                outils.affichgrille(grille);
                Console.WriteLine(compt);
                compt = compt + 1;
            } while (compt<43);
        }
    }
}
