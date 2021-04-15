using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo2
{
    class Program
    {
         static string goodDay(int heure)
         {
            string message = $"Il est heure {heure},";
            const string NUIT = "Merveilleuse nuit !";
            const string MATIN = "Bonne matinée !";
            const string MIDI = "Bon appétit !";
            const string APREM = "Protfitez de votre après-midi !";
            const string SOIR = "Passez une bonne soirée !";

            if (heure >= 0 && heure < 6)
            {
                                return $"{message} {NUIT}";
            }
            else if (heure >= 6 && heure < 12)
            {
                return $"{message} {MATIN}";
            }
            else if (heure == 12)
            {
                return $"{message} {MIDI}";
            }
            else if (heure > 12 && heure < 18)
            {
                return $"{message} {APREM}";
            }
            else if (heure >= 18 && heure <= 23)
            {
                return $"{message} {SOIR}";
            }
            else
            {
                return $"L'heure invalide : {heure}";
            }
        } 
        static void Main(string[] args)
        {
            Console.WriteLine(goodDay(0));
            Console.WriteLine(goodDay(1));
            Console.WriteLine(goodDay(6));
            Console.WriteLine(goodDay(7));
            Console.WriteLine(goodDay(12));
            Console.WriteLine(goodDay(13));
            Console.WriteLine(goodDay(14));
            Console.WriteLine(goodDay(18));
            Console.WriteLine(goodDay(19));
            Console.WriteLine(goodDay(23));
            Console.WriteLine(goodDay(24));
            Console.WriteLine(goodDay(DateTime.Now.Hour));
            Console.ReadKey();
        }
    }
}
