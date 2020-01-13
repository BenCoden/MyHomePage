using Microsoft.EntityFrameworkCore;
using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomePage.EntityFrameworkCoreSQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<dboLinks> Links { get; set; }
        public DbSet<dboSearchProviders> SearchProviders { get; set; }
    }
}