using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Date d1 = new Date(12, 12, 1990);
            Date d2 = new Date(12, 12, 1990);

            d1.Print();
            d2.Print();

            if (d1 == d2)
            {
                Console.WriteLine("Dates are equal");
            }
            else
            {
                Console.WriteLine("Dates are not equal");
            }
        }
    }
}
