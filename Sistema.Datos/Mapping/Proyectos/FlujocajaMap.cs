using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Proyectos
{
    public class FlujocajaMap : IEntityTypeConfiguration<Flujocaja>
    {
        public void Configure(EntityTypeBuilder<Flujocaja> builder)
        {
            builder.ToTable("flujocajas")
                .HasKey(a => a.idflujocaja);
            builder.HasIndex(p => new { p.idproyecto, p.idrubro, p.yearweek })
                .IsUnique(true);
            builder.HasOne(a => a.proyecto)
                .WithMany(d => d.flujocajas)
                .HasForeignKey(a => a.idproyecto);
            builder.HasOne(a => a.rubro)
                .WithMany(d => d.flujocajas)
                .HasForeignKey(a => a.idrubro);
        }
    }
}
