using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Fondos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Fondos
{
    public class DistribucionfondoMap : IEntityTypeConfiguration<Distribucionfondo>
    {
        public void Configure(EntityTypeBuilder<Distribucionfondo> builder)
        {
            builder.ToTable("distribucionfondos")
                .HasKey(a => a.iddistribucionfondo);
            builder.HasOne(a => a.pedidofondo)
                .WithMany(d => d.distribucionfondos)
                .HasForeignKey(a => a.idpedidofondo);
            builder.HasOne(a => a.usuario)
                .WithMany(d => d.distribucionfondos)
                .HasForeignKey(a => a.idusuario);
        }
    }
}
