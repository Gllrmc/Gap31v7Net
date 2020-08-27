using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Proyectos
{
    public class PresupuestoMap : IEntityTypeConfiguration<Presupuesto>
    {
        public void Configure(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.ToTable("presupuestos")
                .HasKey(a => a.idpresupuesto);
            builder.HasIndex(p => new { p.idproyecto, p.iditem, p.idsubitem })
                .IsUnique(true);
            builder.HasOne(a => a.proyecto)
                .WithMany(d => d.presupuestos)
                .HasForeignKey(a => a.idproyecto);
            builder.HasOne(a => a.items)
                .WithMany(p => p.presupuestos)
                .HasForeignKey(a => a.iditem);
            builder.HasOne(a => a.subitems)
                .WithMany(p => p.presupuestos)
                .HasForeignKey(a => a.idsubitem);
        }
    }
}
