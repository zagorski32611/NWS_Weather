using NWS_Weather.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWS_Weather.Services
{
    public class ForecastService : IForecastService
    {
        public void WeatherForecast(string location)
        {
            Console.WriteLine("Weather");
        }
    }
}
