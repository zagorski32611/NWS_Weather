using NWS_Weather.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWS_Weather.Services
{
    public class LocationService : ILocationService
    {
        public void GetLocation(string arg)
        {
            Console.WriteLine($"You are here: {arg}");
        }
}
}
