using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Limbos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Limbos
{
    class FactuMap : IEntityTypeConfiguration<Factu>
    {
        public void Configure(EntityTypeBuilder<Factu> builder)
        {
            builder.ToTable("factus")
                .HasKey(a => a.idfactu);
            builder.HasIndex(p => new { p.idlimbo, p.numfactu })
                .IsUnique(true); builder.HasOne(a => a.limbo)
                .WithMany(d => d.factus)
                .HasForeignKey(a => a.idlimbo);
        }
    }
}
