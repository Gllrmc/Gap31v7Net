using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Garantias;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Garantias
{
    class GarantiaMap : IEntityTypeConfiguration<Garantia>
    {
        public void Configure(EntityTypeBuilder<Garantia> builder)
        {
            builder.ToTable("garantias")
            .HasKey(u => u.idgarantia);
            builder.HasIndex(p => new { p.idproyecto, p.numorden })
                .IsUnique(true);
            builder.HasOne(a => a.proyecto)
                .WithMany(d => d.garantias)
                .HasForeignKey(a => a.idproyecto);
            builder.HasOne(a => a.banco)
                .WithMany(d => d.garantias)
                .HasForeignKey(a => a.idbanco);
            builder.HasOne(a => a.rubro)
                .WithMany(d => d.garantias)
                .HasForeignKey(a => a.idrubro);
            builder.HasOne(a => a.proveedor)
                .WithMany(d => d.garantias)
                .HasForeignKey(a => a.idproveedor);
        }
    }
}
