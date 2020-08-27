using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    public class OrigenMap : IEntityTypeConfiguration<Origen>
    {
        public void Configure(EntityTypeBuilder<Origen> builder)
        {
            builder.ToTable("origenes")
            .HasKey(u => u.idorigen);
            builder.HasOne(a => a.territorio)
                .WithMany(d => d.origenes)
                .HasForeignKey(a => a.idterritorio);
            builder.Property(u => u.origen)
            .HasMaxLength(50);
        }
    }
}
