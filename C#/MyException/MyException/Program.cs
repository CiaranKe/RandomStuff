using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number: ");
            long nToCompute = Convert.ToInt64(Console.ReadLine());
            Factorial f = new Factorial();
            long nFactorial;
            try
            {
                nFactorial = f.ComputeFactorial(nToCompute);
                Console.WriteLine("Factorial of {0} = {1}", nToCompute, nFactorial);
            }
            catch (FactorialException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("");
                Console.WriteLine(fe.InnerException.Message);
            }
            
        }
    }
}
