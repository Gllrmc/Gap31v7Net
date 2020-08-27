using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Fondos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Fondos
{
    public class Rendicion2dateMap : IEntityTypeConfiguration<Rendicion2date>
    {
        public void Configure(EntityTypeBuilder<Rendicion2date> builder)
        {
            builder.ToTable("vPedidoRendicionFondos")
                .HasKey(a => a.id);
        }
    }
}
