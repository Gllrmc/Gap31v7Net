using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Maestros;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estados")
            .HasKey(u => u.idestado);
            builder.Property(u => u.estado)
            .HasMaxLength(50);
        }
    }
}
