using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Motion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Motion
{
    public class ProveedormotionMap : IEntityTypeConfiguration<Proveedormotion>
    {
        public void Configure(EntityTypeBuilder<Proveedormotion> builder)
        {
            builder.ToTable("proveedormotions")
                .HasKey(a => a.idproveedormotion);
            builder.HasOne(a => a.proveedor)
                .WithMany(d => d.proveedormotions)
                .HasForeignKey(a => a.idproveedor);
            builder.HasOne(a => a.proyecto)
                .WithMany(d => d.proveedormotions)
                .HasForeignKey(a => a.idproyecto);
            builder.HasOne(a => a.item)
                .WithMany(d => d.proveedormotions)
                .HasForeignKey(a => a.iditem);
            builder.HasOne(a => a.subitem)
                .WithMany(d => d.proveedormotions)
                .HasForeignKey(a => a.idsubitem);
        }
    }
}
