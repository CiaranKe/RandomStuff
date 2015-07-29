using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace APITest
{
    class Program
    {
        [DllImport("user32.dll", EntryPoint ="MessageBoxA")]
        public static extern int AnyNameYouLikeReallyItWontMatterMuch(int HWnd, string strMsg, string strCaption, int nType);

        static void Main(string[] args)
        {
            int nMessageBoxResult;

            nMessageBoxResult = AnyNameYouLikeReallyItWontMatterMuch(0, "Message from Application", "Caption", 0);

        }
    }
}
