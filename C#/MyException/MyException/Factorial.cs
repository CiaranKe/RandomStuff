using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyException
{
    class Factorial
    {

        public long ComputeFactorial(long nToCompute)
        {
            long nFactorial = 1;
            try
            {
                checked
                {
                    for (long n = nToCompute; n > 0; n--)
                    {
                        nFactorial *= n;
                    }
                }
            }
            catch (OverflowException ofe)
            {
                throw new FactorialException("Number too large!", ofe);
                //return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:" + e.Message);
            }
            finally
            {
                Console.WriteLine("Calculated");
            }


            return nFactorial;
        }
    }
}
