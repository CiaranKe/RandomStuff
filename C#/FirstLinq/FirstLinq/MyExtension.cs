using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstLinq
{
    public static class  MyExtension
    {
        public static string TextIt(this ProductClass p)
        {
            return p.Name
                + " Which comes in quantities of " 
                + p.Quantity 
                + " has a unit price of " 
                + p.UnitPrice;
        }
    }
}
