using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szinkron_Api.Models;

namespace Szinkron_Api.Data
{
    public class Szinkron_ApiContext : DbContext
    {
        public Szinkron_ApiContext (DbContextOptions<Szinkron_ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Szinkron_Api.Models.Film> Film { get; set; } = default!;
        public DbSet<Szinkron_Api.Models.Szinkron> Szinkron { get; set; } = default!;
    }
}
