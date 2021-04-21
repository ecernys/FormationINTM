using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    public class Morse
    {
        private const string Taah = "===";
        private const string Ti = "=";
        private const string Space = ".";
        private const string SpaceLetter = "...";
        private const string SpaceWord = ".......";

        private readonly Dictionary<string, char> _alphabet;

        public Morse()
        {
            _alphabet = new Dictionary<string, char>()
            {
                {$"{Ti}.{Taah}", 'A'},
                {$"{Taah}.{Ti}.{Ti}.{Ti}", 'B'},
                {$"{Taah}.{Ti}.{Taah}.{Ti}", 'C'},
                {$"{Taah}.{Ti}.{Ti}", 'D'},
                {$"{Ti}", 'E'},
                {$"{Ti}.{Ti}.{Taah}.{Ti}", 'F'},
                {$"{Taah}.{Taah}.{Ti}", 'G'},
                {$"{Ti}.{Ti}.{Ti}.{Ti}", 'H'},
                {$"{Ti}.{Ti}", 'I'},
                {$"{Ti}.{Taah}.{Taah}.{Taah}", 'J'},
                {$"{Taah}.{Ti}.{Taah}", 'K'},
                {$"{Ti}.{Taah}.{Ti}.{Ti}", 'L'},
                {$"{Taah}.{Taah}", 'M'},
                {$"{Taah}.{Ti}", 'N'},
                {$"{Taah}.{Taah}.{Taah}", 'O'},
                {$"{Ti}.{Taah}.{Taah}.{Ti}", 'P'},
                {$"{Taah}.{Taah}.{Ti}.{Taah}", 'Q'},
                {$"{Ti}.{Taah}.{Ti}", 'R'},
                {$"{Ti}.{Ti}.{Ti}", 'S'},
                {$"{Taah}", 'T'},
                {$"{Ti}.{Ti}.{Taah}", 'U'},
                {$"{Ti}.{Ti}.{Ti}.{Taah}", 'V'},
                {$"{Ti}.{Taah}.{Taah}", 'W'},
                {$"{Taah}.{Ti}.{Ti}.{Taah}", 'X'},
                {$"{Taah}.{Ti}.{Taah}.{Taah}", 'Y'},
                {$"{Taah}.{Taah}.{Ti}.{Ti}", 'Z'},
            };
        }

        public int LettersCount(string code)
        {
            return code.Split(new string[] { SpaceLetter }, StringSplitOptions.None).Length;
        }

        public int WordsCount(string code)
        {
            return code.Split(new string[] { SpaceWord }, StringSplitOptions.None).Length;
        }

        public string MorseTranslation(string code)
        {
            IsValidMorseCode(code);
            code = trimDots(code);
            string response = "";
            string[] words = code.Split(new string[] { SpaceWord }, StringSplitOptions.None);
            foreach (var word in words)
            {
                string wordT = trimDots(word);
                string[] letters = wordT.Split(new string[] { SpaceLetter }, StringSplitOptions.None);
                foreach (var letter in letters)
                {
                    string letterT = trimDots(letter);
                    if (!String.IsNullOrEmpty(letter))
                    {
                        char lettreTrad = ' ';
                        if (_alphabet.TryGetValue(letter, out lettreTrad))
                        {
                            response += lettreTrad;
                        }
                        else
                        {
                            response += '+';
                        }
                    }
                }
                response += " ";
            }
            return response;
        }

        public string EfficientMorseTranslation(string code)
        {
            IsValidMorseCode(code);
            int points = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == '.')
                {
                    points++;
                }
                else
                {
                    if (points == 2 || points == 4)
                        code.Remove(i, 1);
                    if (points > 5)
                        code.Remove(i, points - 5);
                    points = 0;
                }
            }
            return MorseTranslation(code);
        }

        public string MorseEncryption(string sentence)
        {
            return string.Empty;
        }


        private void IsValidMorseCode(string code)
        {
            if (code.Any(s => s != '=' && s != '.'))
            {
                throw new ArgumentException("Le code morse contient les valeurs invalides");
            }
        }

        private string trimDots(string code)
        {
            code.TrimStart('.');
            code.TrimEnd('.');
            return code;
        }

    }
}
