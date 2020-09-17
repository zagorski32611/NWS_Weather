using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWS_Weather.Interfaces
{
    public interface IForecastService
    {
        public void WeatherForecast(string location);
    }
}
