using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Maestros;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    public class TipoprodMap : IEntityTypeConfiguration<Tipoprod>
    {
        public void Configure(EntityTypeBuilder<Tipoprod> builder)
        {
            builder.ToTable("tipoprods")
            .HasKey(u => u.idtipoprod);
            builder.Property(u => u.tipoprod)
            .HasMaxLength(50);
        }
    }
}
