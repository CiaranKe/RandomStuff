using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateEvents
{
    class Thermometer
    {
        private int temperature;

        public event DelegateEvents.Program.TemperatureEventHandler Change;
        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (temperature != value)
                {
                    if (Change != null)
                    {
                        TemperatureEventArgs args = new TemperatureEventArgs(value);
                        Change(this, args);
                    }
                    temperature = value;
                }
            }
        }
    }
}
