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
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Nombre)
                .IsRequired();
            builder.Property(g => g.Imagen)
                .IsRequired();
            builder.HasData(
                new Genero {Id=1, Imagen="una imagen",Nombre="Drama"},
                new Genero { Id = 2, Imagen = "una imagen", Nombre = "Acción" },
                new Genero { Id = 3, Imagen = "una imagen", Nombre = "Comedia" }
                );
        }
    }
}
