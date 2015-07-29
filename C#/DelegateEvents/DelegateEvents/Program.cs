using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateEvents
{
    class Program
    {
        //declare the delegate
        public delegate void TemperatureEventHandler(Object source, TemperatureEventArgs e);

        static void Main(string[] args)
        {
            //create therm
            Thermometer waterThermomiter = new Thermometer();
            //add method to delegate
            waterThermomiter.Change += new TemperatureEventHandler(Temperature_change);
            waterThermomiter.Temperature = 50;
            waterThermomiter.Temperature = 80;
            waterThermomiter.Temperature = 110;
        }

        //method to be added to delegate
        static void Temperature_change(Object source, TemperatureEventArgs e)
        {
            if (e.temperature < 100)
            {
                Console.WriteLine("Temperature is: {0} ", e.temperature);
            }
            else
            {
                Console.WriteLine("Temperature is out of range");
            }
        }
    }
}
