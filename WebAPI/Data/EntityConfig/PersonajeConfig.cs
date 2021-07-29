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
    class PersonajeConfig : IEntityTypeConfiguration<Personaje>
    {
        public void Configure(EntityTypeBuilder<Personaje> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nombre)
                .IsRequired();
            builder.Property(p => p.Edad)
                .IsRequired();
            builder.Property(p => p.Peso)
                .IsRequired();
            builder.Property(p => p.Historia)
                .IsRequired();
            builder.Property(p => p.Imagen)
                .IsRequired();
            builder.HasData(
                new Personaje {Id=1, Nombre="Simba",Edad=5,Historia="Su historia",Imagen="una imagen", Peso=110 },
                new Personaje { Id = 2, Nombre = "Iron Man", Edad = 34, Historia = "Su historia", Imagen = "una imagen", Peso = 75 },
                new Personaje { Id = 3, Nombre = "Sheriff Woody", Edad = 25, Historia = "Su historia", Imagen = "una imagen", Peso = 79 }

                );

        }
    }
}
