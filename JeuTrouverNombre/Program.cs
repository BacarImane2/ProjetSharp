using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Definissez les bornes de l'intervalle.");
        int min = DemanderEntier("Entrez la borne minimale : ");
        int max = DemanderEntier("Entrez la borne maximale : ");
        if (min >= max)
        {
            Console.WriteLine("La borne minimale doit être inferieure à la borne maximale.");
            return;
        }

        Random random = new Random();
        int nombreATrouver = random.Next(min, max + 1);

        List<int> choixJoueurs = new List<int>();
        int tentatives = 0;

        while (true)
        {
            try
            {
                int choix = DemanderEntier($"Choisissez un nombre entre {min} et {max} (-1 pour quitter) : ");
                if (choix == -1)
                {
                    Console.WriteLine("Merci d'avoir joue ");
                    break;
                }

                if (choix < min || choix > max)
                {
                    throw new ArgumentOutOfRangeException($"Saisissez un nombre compris entre {min} et {max} ");
                }

                tentatives++;
                choixJoueurs.Add(choix);

                if (choix == nombreATrouver)
                {
                    Console.WriteLine("Vous avez gagne");
                    break;
                }
                else
                {
                    Console.WriteLine("Essayez encore ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }

        double note = (double)(max - min + 1) / tentatives;
        Console.WriteLine($"\nJeu termine. Vous avez fait {tentatives} tentatives.");

        if(tentatives!=0){
        Console.WriteLine($"Vos choix : {string.Join(", ", choixJoueurs)}");
        Console.WriteLine($"Votre note : {note:F2}");
        }
    }

    static int DemanderEntier(string message)
    {
        while (true)
        {
            Console.Write(message);
            string saisie = Console.ReadLine();

            if (int.TryParse(saisie, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Veuillez entrer un nombre entier valide.");
            }
        }
    }
}
