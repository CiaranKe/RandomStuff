using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Collect
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList x = new ArrayList();
            x.Add("George");
            x.Add("Adam");
            x.Add("Helen");
            x.Add("Peter");
            foreach (String s in x)
            {
                Console.WriteLine(s);
            }
        }
    }
}
