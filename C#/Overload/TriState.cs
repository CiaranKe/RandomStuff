using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overload
{
    class TriState
    {
        public int value;

        public TriState(int v)
        {
            this.value = v;
        }

        public static bool operator true(TriState t)
        {
            return t.value == 1;
        }

        public static bool operator false(TriState t)
        {
            return t.value == 1;
        }

        public static TriState operator !(TriState t)
        {
            return new TriState(-t.value);
        }

        public bool IsNull
        {
            get
            {
                return value == 0;
            }
        }
    }
}
