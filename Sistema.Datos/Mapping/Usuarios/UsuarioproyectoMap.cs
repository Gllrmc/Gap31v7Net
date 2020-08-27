using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Usuarios
{
    public class UsuarioproyectoMap : IEntityTypeConfiguration<Usuarioproyecto>
    {
        public void Configure(EntityTypeBuilder<Usuarioproyecto> builder)
        {
            builder.ToTable("usuarioproyectos")
               .HasKey(u => new { u.idusuarioproyecto } );
            builder.HasIndex(a => new { a.idusuario, a.idproyecto })
                .IsUnique(true);
            builder.HasOne(a => a.proyecto)
                .WithMany(d => d.usuarioproyectos)
                .HasForeignKey(a => a.idproyecto);
            builder.HasOne(a => a.usuario)
                .WithMany(d => d.usuarioproyectos)
                .HasForeignKey(a => a.idusuario);
        }
    }
}
