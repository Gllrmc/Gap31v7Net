using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Limbos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Limbos
{
    class DirfeeMap : IEntityTypeConfiguration<Dirfee>
    {
        public void Configure(EntityTypeBuilder<Dirfee> builder)
        {
            builder.ToTable("dirfees")
                .HasKey(a => a.iddirfee);
            builder.HasIndex(p => new { p.idlimbo, p.numdirfee })
                .IsUnique(true);
            builder.HasOne(a => a.limbo)
                .WithMany(d => d.dirfees)
                .HasForeignKey(a => a.idlimbo);
        }
    }
}
