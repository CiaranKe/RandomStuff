using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyException
{
    class FactorialException : Exception
    {
        public FactorialException()
            : base()
        {
            //does nothing
        }

        public FactorialException(String message)
            :base(message)
        {
            //does nothing
        }

        public FactorialException(String message, Exception inner)
            : base(message, inner)
        {
            //does nothing
        }

    }
}
