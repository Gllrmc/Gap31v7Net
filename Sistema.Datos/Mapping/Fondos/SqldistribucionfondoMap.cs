using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Fondos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Fondos
{
    class SqldistribucionfondoMap : IEntityTypeConfiguration<Sqldistribucionfondo>
    {
        public void Configure(EntityTypeBuilder<Sqldistribucionfondo> builder)
        {
            builder.ToTable("sqldistribucionfondo")
                .HasKey(a => a.iddistribucionfondo);
        }
    }
}
