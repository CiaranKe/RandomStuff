using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

///<summary>
///     Summary description for DebugTes
/// </summary>
/// <remarks>
///     Desc of class 
///</remarks     
namespace ConfigDep
{
    class DebugTest
    {
        /// <summary>
        ///     Desc of method
        /// </summary>
        /// <param name="debugMessage">Desc  of paramiter</param>
        /// <seealso cref="DebugTest"/>
        [System.Diagnostics.Conditional(("TEST"))]
        public static void DisplayData(String debugMessage)
        {
            Console.WriteLine("The current message is: " + debugMessage);
        }
    }
}
