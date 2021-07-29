using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BLL.Entidades;
using WebAPI.Data.EntityConfig;

namespace WebAPI.Data
{
    public class AppContexto : DbContext
    {
        public AppContexto (DbContextOptions<AppContexto> options)
            : base(options)
        {
        }

        public DbSet<BLL.Entidades.Genero> Generos { get; set; }

        public DbSet<BLL.Entidades.Personaje> Personajes { get; set; }

        public DbSet<BLL.Entidades.Usuario> Usuarios { get; set; }

        public DbSet<BLL.Entidades.PeliculaSerie> PeliculaSerie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GeneroConfig());
            modelBuilder.ApplyConfiguration(new PersonajeConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new PeliculaSeriaConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
