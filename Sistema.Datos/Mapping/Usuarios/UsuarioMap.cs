using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario")
               .HasKey(u => u.idusuario);
            builder.HasOne(a => a.rol)
               .WithMany(d => d.usuarios)
               .HasForeignKey(a => a.idrol);
            builder.HasOne(a => a.persona)
                .WithOne(d => d.usuario)
                .HasForeignKey<Persona>(a => a.idpersona);
        }
    }
}
