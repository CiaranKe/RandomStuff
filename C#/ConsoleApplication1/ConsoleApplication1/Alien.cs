using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    [Obsolete("Aliens don't exist use the Dolphin class", false)] //true == error.
    class Alien : BuildingOccupant, IPrintData
    {
        void IPrintData.print()
        {
            Console.WriteLine("Alien Print");
        }

        public override void logEntry()
        {
            //teleport in
        }

        public override void logExit()
        {
            //teleport out
        }
    }
}
