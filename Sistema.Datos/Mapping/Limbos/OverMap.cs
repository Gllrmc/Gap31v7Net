using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Limbos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Limbos
{
    class OverMap : IEntityTypeConfiguration<Over>
    {
        public void Configure(EntityTypeBuilder<Over> builder)
        {
            builder.ToTable("overs")
                .HasKey(a => a.idover);
            builder.HasOne(a => a.limbo)
                .WithMany(d => d.overs)
                .HasForeignKey(a => a.idover);
        }
    }
}
