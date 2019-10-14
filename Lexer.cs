using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordProg
{
    class Lexer
    {
        private string currStatus;
        private int runNumber = 0;
        string numbers = "0123456789";
        private string[] states = { "q0", "q1", "number", "variable", "error" };

        private Dictionary<string, string> dict = new Dictionary<string, string>();
        public Dictionary<string, string> Dict
        {
            get { return dict; }
            set { dict = value; }
        }

        public Lexer(string source)
        {
            this.currStatus = "q0";
            Dict.Add("q0ezittegyoperator", "q1"); //+ v - al kezdődik akkor q1 kell mert utána számnak kell állnia
            Dict.Add("q0ezittegynumber", "number");   //számmal kezdődik akkor mehet numberbe egyből
            Dict.Add("q1ezittegynumber", "number");   //számot szám követ
            Dict.Add("numberezittegynumber", "number");   //számot szám követ

            Dict.Add("q0ezittegyvariable", "variable");
            Dict.Add("variableezittegyvariable", "variable");
        }


        public string scan(string s) //ezt kell meghívni mert ez hívja a többi metódust azok ezen metódus segítői azért is privátak
        {
            int i = 0;
            while (i < s.Length && currStatus != "error")
            {
                currStatus = delta(currStatus, s[i]);
                i++;
                if (currStatus == "error")
                    break;
            }
            /*
            if (currStatus == "q0") //
                return false;
            else if (currStatus == "q1") //
                return false;
            else if (currStatus == "q2") //
                return true;
            else if (currStatus == "error") //hiba
                return false;
            else return false;*/
            return currStatus;
        }

        private string delta(string status, char s)
        {
            string x = status + sub3(s);
            if (Dict.ContainsKey(x))
                return Dict[x];
            else return "error";
        }
        
        private string sub3(char y)
        {
            if (runNumber == 0)
            {
                if (char.IsDigit(y) || y == '+' || y == '-') //ez kezeli le, hogy számmal vagy operátorral kezdődik-e
                {
                    runNumber = 1;
                    return sub(y);
                }
                else if (char.IsLetter(y))
                {
                    runNumber = 2;
                    return sub2(y);
                }
                else return "error";
            }
            else if (runNumber == 1) //ha operátorra kezdődött a runNumb átáll 1-re és a számvizsgálatot folytatjuk
                return sub(y);
            else if (runNumber == 2)
                return sub2(y);
            else return "error";
        }

        private string sub2(char y)
        {
            if (runNumber == 0)
            {
                return "ezittegyvariable";
            }
            else if ((runNumber == 2 && char.IsLetter(y)) || (runNumber == 2 && numbers.Contains(y)))
                return "ezittegyvariable";
            else return "error";
        }

        private string sub(char y) //az az eset ha + - vagy számmal kezdődik a szám --> ekkor ugye számként kezeljük
        {
            
            if (numbers.Contains(y))
                return "ezittegynumber";
            else if (y == '+' || y == '-')
                return "ezittegyoperator"; 
            else
                return y.ToString();
        }
    }
}
