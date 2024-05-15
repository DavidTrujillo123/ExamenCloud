using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppAnimales;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<AppAnimales.Animal> Animales { get; set; } = default!;

        public DbSet<AppAnimales.Grupo> Grupos { get; set; } = default!;

        
    }
