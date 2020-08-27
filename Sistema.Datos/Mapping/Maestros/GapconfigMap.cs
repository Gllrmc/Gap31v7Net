using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    public class GapconfigMap : IEntityTypeConfiguration<Gapconfig>
    {
        public void Configure(EntityTypeBuilder<Gapconfig> builder)
        {
            builder.ToTable("gapconfig")
            .HasKey(u => u.id);
        }
    }
}
