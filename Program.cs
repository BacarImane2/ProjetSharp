using System;
using System.Collections.Generic;

class Programme
{
    static void Main()
    {
        // Liste pour stocker les conversions
        List<string> listeConversions = new List<string>();

        Console.WriteLine("Entrez les entiers à convertir en hexadecimal (entrez -1 pour terminer) :");

        while (true)
        {
            int entier = -1;
            Console.Write("Entier : ");
            while (true)
            {
                try
                {
                    entier = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nVeuillez saisir un entier valide.\n");
                }
            }

            if (entier == -1) break; 

            // Convertir l'entier en hexadecimal
            string valeurHexadecimale = ConvertirEnHexadecimal(entier);
            listeConversions.Add($"{entier} -> 0x{valeurHexadecimale}");
            Console.WriteLine($"Hexadécimal : 0x{valeurHexadecimale}");
        }

        // Afficher la liste des conversions
        Console.WriteLine("\nListe des conversions :");
        foreach (var conversion in listeConversions)
        {
            Console.WriteLine(conversion);
        }
    }
    
    static string ConvertirEnHexadecimal(int entier)
    {
        if (entier == 0 || entier < -2) return "0";

        string chiffresHexadecimaux = "0123456789ABCDEF";
        string valeurHexadecimale = "";

        while (entier > 0)
        {
            int reste = entier % 16;
            valeurHexadecimale = chiffresHexadecimaux[reste] + valeurHexadecimale; 
            entier /= 16;
        }

        return valeurHexadecimale;
    }
}
