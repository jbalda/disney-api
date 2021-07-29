using BLL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Data.EntityConfig
{
    public class PeliculaSeriaConfig : IEntityTypeConfiguration<PeliculaSerie>
    {
        public void Configure(EntityTypeBuilder<PeliculaSerie> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Titulo)
                .IsRequired();
            builder.Property(p => p.Calificacion)
                .IsRequired();
            builder.Property(p => p.FechaCreacion)
                .IsRequired();
            builder.HasData(
               new PeliculaSerie { Id = 1, Titulo = "El rey León 1", Calificacion = 3, FechaCreacion = new DateTime(2021, 07, 01), GeneroId = 1, Imagen = "una imagen"},
                new PeliculaSerie { Id = 2, Titulo = "El Rey León 2", Calificacion = 5, FechaCreacion = new DateTime(2021, 07, 02), GeneroId = 1, Imagen = "una imagen" },
                 new PeliculaSerie { Id = 3, Titulo = "Toy Story", Calificacion = 4, FechaCreacion = new DateTime(2021, 07, 03), GeneroId = 3, Imagen = "una imagen" },
                 new PeliculaSerie { Id = 4, Titulo = "Los vengadores", Calificacion = 4, FechaCreacion = new DateTime(2021, 07, 04), GeneroId = 2, Imagen = "una imagen" }
               );
            builder.HasMany(p => p.Personajes)
                .WithMany(per => per.PeliculasYSeries)
                .UsingEntity<Dictionary<string, object>>(
                    "PeliculaSeriePersonaje",
                    r=> r.HasOne<Personaje>().WithMany().HasForeignKey("PersonajeId"),
                    l=> l.HasOne<PeliculaSerie>().WithMany().HasForeignKey("PeliculaSerieId"),
                    pp =>
                    {
                        pp.HasKey("PeliculaSerieId", "PersonajeId");
                        pp.HasData(
                            new { PeliculaSerieId = 1, PersonajeId = 1 },
                            new { PeliculaSerieId = 2, PersonajeId = 1 },
                            new { PeliculaSerieId = 3, PersonajeId = 3 },
                            new { PeliculaSerieId = 4, PersonajeId = 2 }
                            );
                    }             

                );


           

        }
    }
}
