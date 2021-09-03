using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Limbos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Limbos
{
    class LimboMap : IEntityTypeConfiguration<Limbo>
    {
        public void Configure(EntityTypeBuilder<Limbo> builder)
        {
            builder.ToTable("limbos")
                .HasKey(a => a.idlimbo);
            builder.HasIndex(a => new { a.orden })
                .IsUnique(true);
            builder.HasOne(a => a.lep)
                .WithMany(d => d.eplimbos)
                .HasForeignKey(a => a.idep);
            builder.HasOne(a => a.ldirector)
                .WithMany(d => d.directorlimbos)
                .HasForeignKey(a => a.iddirector);
            builder.HasOne(a => a.lcodirector)
                .WithMany(d => d.codirectorlimbos)
                .HasForeignKey(a => a.idcodirector);
            builder.HasOne(a => a.origenes)
                .WithMany(d => d.limbos)
                .HasForeignKey(a => a.idorigen);
            builder.HasOne(a => a.pitchs)
                .WithMany(d => d.limbos)
                .HasForeignKey(a => a.idpitch);
            builder.HasOne(a => a.tipoprods)
                .WithMany(d => d.limbos)
                .HasForeignKey(a => a.idtipoprod);
            builder.HasOne(a => a.tipoproys)
                .WithMany(d => d.limbos)
                .HasForeignKey(a => a.idtipoproy);
            builder.HasOne(a => a.estados)
                .WithMany(d => d.limbos)
                .HasForeignKey(a => a.idestado);
            builder.HasOne(a => a.resultados)
                .WithMany(d => d.limbos)
                .HasForeignKey(a => a.idresultado);
        }
    }
}
