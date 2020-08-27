using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Fondos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Fondos
{
    public class PedidofondoMap : IEntityTypeConfiguration<Pedidofondo>
    {
        public void Configure(EntityTypeBuilder<Pedidofondo> builder)
        {
            builder.ToTable("pedidosfondo")
                .HasKey(a => a.idpedidofondo);
            builder.HasIndex(p => new { p.idproyecto, p.numpedido })
                .IsUnique(true);
            builder.HasOne(a => a.proyecto)
                .WithMany(d => d.pedidofondos)
                .HasForeignKey(a => a.idproyecto);
            builder.HasOne(a => a.responsable)
                .WithMany(d => d.responsablefondos)
                .HasForeignKey(a => a.idresponsable);
            builder.HasOne(a => a.subrubro)
                .WithMany(d => d.pedidofondos)
                .HasForeignKey(a => a.idsubrubro);
        }
    }
}
