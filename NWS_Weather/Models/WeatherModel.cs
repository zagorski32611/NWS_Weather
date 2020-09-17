using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using Newtonsoft.Json.Schema;


namespace NWS_Weather.Models
{
    public class Root
    {
        [Key]
        public int rootId { get; set; }

        // I intentionally did not map the version information
        //public Context context { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        [Key]
        public int geometryId { get; set; }
        public string type { get; set; }
    }



    public class Properties
    {
        [Key]
        public int propertiesId { get; set; }
        public DateTime updated { get; set; }
        public string units { get; set; }
        public string forecastGenerator { get; set; }
        public DateTime generatedAt { get; set; }
        public DateTime updateTime { get; set; }
        public DateTime validTimes { get; set; }
        public Elevation elevation { get; set; }
        public List<Period> periods { get; set; }
    }
    public class Elevation
    {
        [Key]
        public int elevationId { get; set; }
        public double value { get; set; }
        public string unitCode { get; set; }
    }

    public class Period
    {
        [Key]
        public int periodId {get; set;}
        public int number { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isDaytime { get; set; }
        public int temperature { get; set; }
        public string temperatureUnit { get; set; }
        public string temperatureTrend { get; set; }
        public string windSpeed { get; set; }
        public string windDirection { get; set; }
        public string icon { get; set; }
        public string shortForecast { get; set; }
        public string detailedForecast { get; set; }
    }
}

