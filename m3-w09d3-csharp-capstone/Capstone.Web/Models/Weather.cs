using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public int FiveDayForecastValue { get; set; }
        public int TemperatureLow { get; set; }
        public int TemperatureHigh { get; set; }
        public string Forecast { get; set; }
    }
}