using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Pagos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Pagos
{
    class SqlordenpagoMap : IEntityTypeConfiguration<Sqlordenpago>
    {
        public void Configure(EntityTypeBuilder<Sqlordenpago> builder)
        {
            builder.ToTable("sqlordenpagos")
                .HasKey(a => a.idordenpago);
        }
    }
}
