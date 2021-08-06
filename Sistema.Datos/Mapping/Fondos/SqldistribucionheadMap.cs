using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Fondos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Fondos
{
    class SqldistribucionheadMap : IEntityTypeConfiguration<Sqldistribucionhead>
    {
        public void Configure(EntityTypeBuilder<Sqldistribucionhead> builder)
        {
            builder.ToTable("sqldistribucionhead")
                .HasKey(a => a.idproyecto);
        }
    }
}
