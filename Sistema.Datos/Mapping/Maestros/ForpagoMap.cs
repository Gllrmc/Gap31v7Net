using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;

namespace Sistema.Datos.Mapping.Maestros
{
    public class ForpagoMap : IEntityTypeConfiguration<Forpago>
    {
        public void Configure(EntityTypeBuilder<Forpago> builder)
        {
            builder.ToTable("forpagos")
            .HasKey(u => u.idforpago);
            builder.Property(u => u.forpago)
            .HasMaxLength(50);
        }
    }
}
