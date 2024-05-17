using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GesParck.Models;

namespace GesParck.Data
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

        public DbSet<GesParck.Models.Users> Users { get; set; } = default!;
        public DbSet<GesParck.Models.Mapping> Mappings { get; set; } = default!;
        public DbSet<GesParck.Models.Network> Network { get; set; } = default!;
        public DbSet<GesParck.Models.Rooms> Rooms { get; set; } = default!;
        public DbSet<GesParck.Models.Rules> Rules { get; set; } = default!;
        public DbSet<GesParck.Models.Parks> Parks { get; set; } = default!;
        public DbSet<GesParck.Models.Computers> Computers { get; set; } = default!;
    }
}
