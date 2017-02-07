using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWebAPI.Models
{
    public class WeatherSample
    {
        public enum TemperatureScales
        {
            Celsius = 1,
            Fahrenheit = 2
        }

        public double Temperature { get; internal set;}
        public double Humidity {get; internal set;}
        public double WindSpeed {get; internal set;}
        public DateTime Time {get; internal set;}
        public TemperatureScales TemperatureScale {get; internal set;}
    }
}