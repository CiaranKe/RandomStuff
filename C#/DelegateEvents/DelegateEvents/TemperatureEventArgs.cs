using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateEvents
{
    class TemperatureEventArgs : EventArgs
    {
        public int temperature;

        public TemperatureEventArgs(int temperature)
        {
            this.temperature = temperature;
        }
    }
}
