using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo2._4
{
    class Program
    {
        static bool QcmValidity(Qcm qcm)
        {
            if (qcm.Solution < 0 || qcm.Solution > qcm.Answers.Length)
            {
                return false;
            }
            if (qcm.Weight <= 0)
            {
                return false;
            }
            return true;
        }

        static int AskQuestion(Qcm qcm)
        {
            bool isNotAnswered = true;
            int choise = -1;
            if (!QcmValidity(qcm))
            {       
                throw new ArgumentException("La qcm est invlide !");
            }

            Console.WriteLine(qcm.Question);
            for (int i = 0; i < qcm.Answers.Length; i++)
            {
                Console.Write($"{i + 1}. {qcm.Answers[i]}   ");
            }
            Console.WriteLine();

            while (isNotAnswered)
            {
                Console.Write("Réponse : ");

                if (!int.TryParse(Console.ReadLine(), out choise) || choise > qcm.Answers.Length || choise <= 0)
                {
                    Console.WriteLine("Réponse invalide !");
                }
                else
                {
                    isNotAnswered = false;
                }
            }

            if (choise == qcm.Solution)
            {
                return qcm.Weight;
            }
            else
            {
                return 0;
            }
        }
        static void AskQuestions(Qcm[] qcms)
        {
            int resultat = 0;
            int maxValue = 0;
            if (qcms.Length > 0)
            {
                Console.WriteLine("Questionnaire : ");
                for (int i = 0; i < qcms.Length; i++)
                {
                    resultat += AskQuestion(qcms[i]);
                    maxValue += qcms[i].Weight;
                }
            }
            Console.WriteLine($"Résultats du questionnaire : {resultat} / {maxValue}");
        }
        static void Main(string[] args)
        {
            Qcm[] qcms =
            {
                new Qcm
                {
                    Question = "Quelle est l'année du sacre de Charlemagne ?",
                    Answers = new string[]
                    {
                        "476",
                        "800",
                        "1066",
                        "1789"
                    },
                    Solution = 2,
                    Weight = 1
                },
                new Qcm
                {
                    Question = "Salut, ça va ?",
                    Answers = new string[]
                    {
                        "oui",
                        "non"
                    },
                    Solution = 1,
                    Weight = 1
                },
                new Qcm
                {
                    Question = "T'as aimé le qcm ?",
                    Answers = new string[]
                    {
                        "oui",
                        "non"
                    },
                    Solution = 1,
                    Weight = 18
                }
            };

            try
            {
                AskQuestions(qcms);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

    }

}


