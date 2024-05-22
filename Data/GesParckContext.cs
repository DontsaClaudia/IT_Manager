using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GesPark.Models;

namespace GesPark.Data
{
    public class GesParckContext : DbContext
    {
        public GesParckContext()
        {
        }

        public GesParckContext (DbContextOptions<GesParckContext> options)
            : base(options)
        {
        }

        public DbSet<GesPark.Models.Users> Users { get; set; } = default!;
        public DbSet<GesPark.Models.Mapping> Mappings { get; set; } = default!;
        public DbSet<GesPark.Models.Network> Network { get; set; } = default!;
        public DbSet<GesPark.Models.Rooms> Rooms { get; set; } = default!;
        public DbSet<GesPark.Models.Rules> Rules { get; set; } = default!;
        public DbSet<GesPark.Models.Parks> Parks { get; set; } = default!;
        public DbSet<GesPark.Models.Computers> Computers { get; set; } = default!;
    }
}
