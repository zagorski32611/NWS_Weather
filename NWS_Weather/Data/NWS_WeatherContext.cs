using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NWS_Weather.Models;

namespace NWS_Weather.Data
{
    public class NWS_WeatherContext : DbContext
    {
        public NWS_WeatherContext(DbContextOptions<NWS_WeatherContext> options) : base(options)
        {
        }

        public DbSet<Root> roots { get; set; }
        public DbSet<Geometry> geometries { get; set; }
        public DbSet<Properties> dbProperties { get; set; }
        public DbSet<Elevation> elevations { get; set; }
        public DbSet<Period> periods { get; set; }

    }
}
