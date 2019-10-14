using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace FordProg
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string source = "3";
            Lexer lex = new Lexer(source);
            Console.WriteLine(lex.scan(source));*/

            List<string> testlista = new List<string>();
            testlista.Add("0");
            testlista.Add("55");
            testlista.Add("-558");
            testlista.Add("+936416513");
            testlista.Add("kaki");
            testlista.Add("H");
            testlista.Add("kaki216");
            testlista.Add("fsdaa33afsad");
            

            foreach (var item in testlista)
            {
                Lexer lex2 = new Lexer(item);
                Console.WriteLine(item + ":  " + lex2.scan(item));
            }


            Console.ReadLine();

               //RegeX-re ez működik most!
               /*
           try
           {                

               RegexSH rsh = new RegexSH("source.txt","dest.txt");
               Console.WriteLine("Reading success: {0}", rsh.ReadFromFile());
               Console.WriteLine("Replacing success: {0}", rsh.Replace());
               Console.WriteLine("Writing success: {0}", rsh.WriteToFile());

           }
           catch (ArgumentNullException e)
           {
               Console.WriteLine("No {0} data!", e.ParamName);
           }
           catch (FileNotFoundException e)
           {
               Console.WriteLine("No file named {0}", e.FileName);
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
           }

           Console.ReadKey();
           */
        }
    }
}
