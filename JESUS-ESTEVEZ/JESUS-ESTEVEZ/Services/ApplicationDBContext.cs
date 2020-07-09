using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JESUS_ESTEVEZ.Models;
using Microsoft.EntityFrameworkCore;

namespace JESUS_ESTEVEZ.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            new Usuario.UsuarioMapper(modelBuilder.Entity<Usuario>());
            new Departamento.DepartamentoMapper(modelBuilder.Entity<Departamento>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
