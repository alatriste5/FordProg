using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FordProg
{
    class RegexSH : SourceHandler
    {
        private List<string> regList;

        public RegexSH() : base()
        {
            regList = new List<string>();
            regList.Add("//(.*?)\r?\n");
            regList.Add(@"/\*(.*?)\*/");
            regList.Add("//(.*?)\r?$");
            regList.Add(@"/\*([^\*/])*\*/");
        }

        public RegexSH(string source, string dest) : this()
        {
            Source = source;
            Dest = dest;
        }

        public override bool Replace()
        {
            try
            {
                foreach (var rule in regList)
                {
                    Content = Regex.Replace(Content, rule, string.Empty);
                }
            }
            catch (Exception)
            {

                throw;
            }



            return true;
        }
    }
}
