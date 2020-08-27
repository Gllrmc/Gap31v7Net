using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    public class ProductoraMap : IEntityTypeConfiguration<Productora>
    {
        public void Configure(EntityTypeBuilder<Productora> builder)
        {
            builder.ToTable("productoras")
            .HasKey(u => u.idproductora);
            builder.Property(u => u.productora)
            .HasMaxLength(50);
        }
    }
}
