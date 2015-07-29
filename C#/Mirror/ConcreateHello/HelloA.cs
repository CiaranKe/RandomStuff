using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractHello;

namespace ConcreateHello
{
    public class HelloA: Hello
    {
        public override void PrintMessage()
        {
            Console.WriteLine("Print from HelloA");
        }
    }
}
