using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Fondos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Fondos
{
    class SqlpedidofondoMap : IEntityTypeConfiguration<Sqlpedidosfondo>
    {
        public void Configure(EntityTypeBuilder<Sqlpedidosfondo> builder)
        {
            builder.ToTable("sqlpedidosfondo")
                .HasKey(a => a.idpedidofondo);
        }
    }
}
