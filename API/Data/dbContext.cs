using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteca_De_Clases;

    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<Biblioteca_De_Clases.planeta> planeta { get; set; } = default!;

        public DbSet<Biblioteca_De_Clases.luna>? luna { get; set; }

        public DbSet<Biblioteca_De_Clases.galaxia>? galaxia { get; set; }
    }
