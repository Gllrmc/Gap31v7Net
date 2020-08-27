using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Garantias;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Garantias
{
    class Garantia2dateMap : IEntityTypeConfiguration<Garantia2date>
    {
        public void Configure(EntityTypeBuilder<Garantia2date> builder)
        {
            builder.ToTable("vGarantia")
                .HasKey(a => a.id);
        }
    }
}
