using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Gastos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Gastos
{
    class GastoMap : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Gasto> builder)
        {
            builder.ToTable("gastos")
            .HasKey(u => u.idgasto);
            builder.HasOne(a => a.concepto)
                .WithMany(d => d.gastos)
                .HasForeignKey(a => a.idconcepto);
        }
    }
}
