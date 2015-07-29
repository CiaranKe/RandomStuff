using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    abstract class BuildingOccupant
    {
        public String Name { get; set; }
        public abstract void logEntry();
        public abstract void logExit();
    }
}
