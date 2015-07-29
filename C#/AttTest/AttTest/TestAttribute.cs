using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttTest
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    class TestAttribute : Attribute
    {
        private String message;
        private bool window;

        public TestAttribute(String message)
        {
            this.message = message;
        }

        public bool Window
        {
            set
            {
                this.window = value;
            }
            get
            {
                return this.window;
            }
        }

    }
}
