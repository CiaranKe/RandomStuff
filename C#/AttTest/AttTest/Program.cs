using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttTest
{
    [Obsolete, Serializable, TestAttribute("hello world", Window=true)]
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Program);
            Object[] oa = Attribute.GetCustomAttributes(t);
            foreach (Object o in oa)
            {
                Console.WriteLine(o);
            }
        }
    }
}
