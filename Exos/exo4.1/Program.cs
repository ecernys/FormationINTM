using MorseCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo4._1
{

    class Program
    {

        static void Main(string[] args)
        {
            Morse morse = new Morse();
            string code = ".....=.===...=.===.===.=...===.===.===.===";
            try
            {
            Console.WriteLine(morse.EfficientMorseTranslation(code));

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
