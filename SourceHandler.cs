using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FordProg
{
    class SourceHandler
    {
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string source;
        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        private string dest;
        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }
        private string dictFile;
        public string DictFile
        {
            get { return dictFile; }
            set { dictFile = value; }
        }

        private Dictionary<string, string> dict = new Dictionary<string,string>();
        public Dictionary<string, string> Dict
        {
            get { return dict; }
            set { dict = value; }
        }


        public SourceHandler()
        {
            Content = null;
            Source = null;
            Dest = null;
            DictFile = null;
        }
        public SourceHandler(string source, string dest, string dictFile)
        {
            Content = null;
            Source = source;
            Dest = dest;
            DictFile = dictFile;
        }

        public bool ReadFromFile()
        {
            try
            {
                if (Source == null)
                {
                    throw new ArgumentNullException("source");
                }

                StreamReader sr = new StreamReader(File.OpenRead(Source));
                Content = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool WriteToFile()
        {
            try
            {
                if (Content == null)
                {
                    throw new ArgumentNullException("content");
                }

                StreamWriter sw = new StreamWriter(File.Open(Dest, FileMode.Create));
                sw.Write(Content);
                sw.Close();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public virtual bool Replace()
        {
            try
            {
                if (DictFile == null)
                    throw new ArgumentNullException("dictionary");

                StreamReader sr = new StreamReader(DictFile);

                Dict.Add("\r\n", " ");

                while (!sr.EndOfStream)
                {
                    string replace = sr.ReadLine();
                    string[] d = replace.Split('@');
                    Dict.Add(d[0], d[1]);
                }

                foreach (var item in Dict)
                {
                    while (Content.IndexOf(item.Key) > -1)
                        Content = Content.Replace(item.Key, item.Value);
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
