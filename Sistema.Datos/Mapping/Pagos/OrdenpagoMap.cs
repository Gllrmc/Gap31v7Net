using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Pagos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Pagos
{
    public class OrdenpagoMap : IEntityTypeConfiguration<Ordenpago>
    {
        public void Configure(EntityTypeBuilder<Ordenpago> builder)
        {
            builder.ToTable("ordenpagos")
                .HasKey(a => a.idordenpago);
            builder.HasIndex(a => new { a.idproveedor, a.tipocomprobante, a.numcomprobante })
                .IsUnique(true);
            builder.HasOne(a => a.item)
                .WithMany(d => d.ordenpagos)
                .HasForeignKey(a => a.iditem);
            builder.HasOne(a => a.subitem)
                .WithMany(d => d.ordenpagos)
                .HasForeignKey(a => a.idsubitem);
            builder.HasOne(a => a.proveedor)
                .WithMany(d => d.ordenpagos)
                .HasForeignKey(a => a.idproveedor);
            builder.HasOne(a => a.alternativapago)
                .WithMany(d => d.ordenpagos)
                .HasForeignKey(a => a.idalternativapago);
        }
    }
}