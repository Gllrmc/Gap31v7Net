using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;

namespace Sistema.Datos.Mapping.Maestros
{
    class ConceptoMap : IEntityTypeConfiguration<Concepto>
    {
        public void Configure(EntityTypeBuilder<Concepto> builder)
        {
            builder.ToTable("conceptos")
                .HasKey(a => a.idconcepto);
        }
    }
}
