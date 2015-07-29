using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Expressions
{
    //Section 13.5 has examples for IP addys and removing leading path for a filename.

    class Program
    {
        static void Main(string[] args)
        {
            //Example1();
            procedural();
            Expression();
        }

        public static void procedural()
        {
            string text = "once upon a time a log long time ago in a far distant land there lived a ...";
            Console.WriteLine(text);
            string result = "";
            string pattern = @"\w+|\W+";

            foreach (Match m in Regex.Matches(text, pattern))
            {
                string s = m.ToString();
                if (char.IsLower(s[0]))
                {
                    s = char.ToUpper(s[0]) + s.Substring(1, s.Length - 1);
                }
                result += s;
            }
            Console.WriteLine(result);
        }

        public static string Matchfound(Match m)
        {
            string s = m.ToString();
            if (char.IsLower(s[0]))
            {
                s = char.ToUpper(s[0]) + s.Substring(1, s.Length - 1);
            }
            return s;
        }

        public static void Expression()
        {
            string text = "once upon a time a log long time ago in a far distant land there lived a ...";
            Console.WriteLine(text);
            string pattern = @"\w+";
            MatchEvaluator me = new MatchEvaluator(Matchfound);
            string result = Regex.Replace(text, pattern, me);
            Console.WriteLine(result);
        }


        private static void Example1()
        {
            String data = "1 - Using the regex class. 2 - Match and MatchCollection classes. 3 - Creating regular expressions for matching text";
            Match m = Regex.Match(data, "r.?x");
            if (m.Success)
            {
                Console.WriteLine("Match found");
                Console.WriteLine("{0} found at position {1}", m.ToString(), m.Index);

            }
            else
            {
                Console.WriteLine("No match");
            }

            string s = Regex.Replace(data, "R(.*?)ex", "$1");
            Console.WriteLine(data);
            Console.WriteLine(s);
        }
    }
}
