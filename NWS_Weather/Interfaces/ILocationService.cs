using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWS_Weather.Interfaces
{
    public interface ILocationService
    {
        public void GetLocation(string arg);
    }
}
