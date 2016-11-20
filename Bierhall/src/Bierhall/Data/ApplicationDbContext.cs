using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;

namespace Bierhall.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brewer> Brewers { get; set; }

        public DbSet<Location> Locations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
