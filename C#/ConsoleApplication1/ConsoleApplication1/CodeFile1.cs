using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    partial class Director : Manager
    {
        private string _name;

        public Director()
            :base(1,20000, "Joe", 3, 10000)
        {
            this._name = "No Name";
        }
    }
}
