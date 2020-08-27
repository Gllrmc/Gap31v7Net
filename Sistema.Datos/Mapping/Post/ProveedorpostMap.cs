using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Post
{
    public class ProveedorpostMap : IEntityTypeConfiguration<Proveedorpost>
    {
        public void Configure(EntityTypeBuilder<Proveedorpost> builder)
        {
            builder.ToTable("proveedorposts")
                .HasKey(a => a.idproveedorpost);
            builder.HasOne(a => a.proveedor)
                .WithMany(d => d.proveedorposts)
                .HasForeignKey(a => a.idproveedor);
            builder.HasOne(a => a.proyecto)
                .WithMany(d => d.proveedorposts)
                .HasForeignKey(a => a.idproyecto);
            builder.HasOne(a => a.item)
                .WithMany(d => d.proveedorposts)
                .HasForeignKey(a => a.iditem);
            builder.HasOne(a => a.subitem)
                .WithMany(d => d.proveedorposts)
                .HasForeignKey(a => a.idsubitem);
        }
    }
}

