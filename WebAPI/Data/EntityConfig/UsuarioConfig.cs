
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
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasAlternateKey(u => u.NombreUsuario);
            //builder.HasAlternateKey(u => u.Email);
            builder.Property(u => u.NombreCompleto)
                .IsRequired();
            builder.Property(u => u.NombreUsuario)
                .IsRequired();
            builder.Property(u => u.Email)
                .IsRequired();
            builder.HasData(
                new Usuario { Id=1,NombreCompleto= "Juan Perez", NombreUsuario="jperez",Email= "baldassini@gmail.com", Contrasena="JPerez123" }
                );
                
        }
    }
}
