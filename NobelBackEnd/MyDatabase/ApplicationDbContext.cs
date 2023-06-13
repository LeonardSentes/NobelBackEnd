using NobelBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NobelBackEnd.MyDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :base("NobelBackEndConnection")
        {

        }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<Laureate> Laureates { get; set; }
    }
}