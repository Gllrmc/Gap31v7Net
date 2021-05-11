using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Limbos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Limbos
{
    class RegpitchMap : IEntityTypeConfiguration<Regpitch>
    {
        public void Configure(EntityTypeBuilder<Regpitch> builder)
        {
            builder.ToTable("regpitchs")
                .HasKey(a => a.idregpitch);
            builder.HasIndex(p => new { p.idlimbo, p.numregpitch })
                .IsUnique(true);
            builder.HasOne(a => a.limbo)
                .WithMany(d => d.regpitchs)
                .HasForeignKey(a => a.idlimbo);
        }
    }
}
