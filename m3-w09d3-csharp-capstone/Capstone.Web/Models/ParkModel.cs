using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkModel
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }

        public int ElevationInFeet { get; set; }
        public decimal MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }

        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }

        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }

        public List<Weather> WeatherList { get; set; }

        public int TempValueProperty { get; set; }



        //public static double TempConversionToCelsius(double currentTemp)
        //{
        //    double c = 5.0 / 9.0 * (currentTemp - 32.0);

        //    return c;

        //}
    }
}
