using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo4._2
{
    class Program
    {
        struct Response
        {
            public string Brackets;
            public string Status;
        }
        static Response BracketsControls(string sentence)
        {
            Stack<char> brackets = new Stack<char>();
            Response response = new Response() {
                Brackets = "",
                Status = ""
            };
            
            foreach (var c in sentence)
            {
                if (c == '(' )
                {
                    brackets.Push(')');
                    response.Brackets += (c);
                }                
                if (c == '{' )
                {
                    brackets.Push('}');
                    response.Brackets += c;

                }
                if (c == '[' )
                {
                    brackets.Push(']');
                    response.Brackets += c;
                }

                if (c == ')' || c == '}' || c == '}')
                {
                    if (brackets.Count == 0 || brackets.Peek() != c)
                    {
                        response.Brackets += c;
                    }
                    else
                    {
                        response.Brackets += c;
                        brackets.Pop();
                    }
                }
            }
            if (brackets.Count > 0)
            {
                response.Status = "KO";
                return response;
            }
            else
            {
                response.Status = "OK";
                return response;
            }
        }
        static void Main(string[] args)
        {
            string phrase = "ssgfdsgdf";
            string phrase1 = "s[sgfdsgdf";
            string phrase2 = "ss(gfdsgdf";
            string phrase3 = "ssg(fds)gdf";
            string phrase4 = "ss(gfdsg}df";
            string phrase5 = "ss({gfd}sg)df";

            Console.WriteLine("Contôle des parenthèses :");
            Console.WriteLine($"{BracketsControls(phrase).Brackets} : {BracketsControls(phrase).Status}");
            Console.WriteLine($"{BracketsControls(phrase1).Brackets} : {BracketsControls(phrase1).Status}");
            Console.WriteLine($"{BracketsControls(phrase2).Brackets} : {BracketsControls(phrase2).Status}");
            Console.WriteLine($"{BracketsControls(phrase3).Brackets} : {BracketsControls(phrase3).Status}");
            Console.WriteLine($"{BracketsControls(phrase4).Brackets} : {BracketsControls(phrase4).Status}");
            Console.WriteLine($"{BracketsControls(phrase5).Brackets} : {BracketsControls(phrase5).Status}");
            

            Console.ReadKey();
        }
    }
}
