using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    class AlternativapagoMap : IEntityTypeConfiguration<Alternativapago>
    {
        public void Configure(EntityTypeBuilder<Alternativapago> builder)
        {
            builder.ToTable("alternativapagos")
                .HasKey(a => a.idalternativapago);
            builder.HasIndex(a => new { a.idproveedor, a.orden })
                .IsUnique(true);
            builder.HasOne(a => a.proveedor)
                .WithMany(d => d.alternativapagos)
                .HasForeignKey(a => a.idproveedor);
        }
    }
}
