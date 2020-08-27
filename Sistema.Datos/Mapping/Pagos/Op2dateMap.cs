using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Pagos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Pagos
{
    public class Op2dateMap : IEntityTypeConfiguration<Op2date>
    {
        public void Configure(EntityTypeBuilder<Op2date> builder)
        {
            builder.ToTable("vOrdpago")
                .HasKey(a => a.id);
        }
    }
}
