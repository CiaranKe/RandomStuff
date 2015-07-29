using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSPointers
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            Program inst = new Program();
            AClass x = new AClass();
            x.a = 5;
            x.b = 3.2F;
            Console.WriteLine(x.a);
            Console.WriteLine(x.b);
            fixed (int* p = &x.a)
            {
                inst.Square(p);
            }
            Console.WriteLine(x.a);
            Console.WriteLine(x.b);
            

        }

        unsafe private static void PointersAreBad()
        {
            int val = 5;
            Program inst = new Program();
            Console.WriteLine(val);
            inst.Square(&val);
            Console.WriteLine(val);
        }

        unsafe public void Square(int* pI)
        {
            *pI = *pI * *pI;
        }
    }
}
