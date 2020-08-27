using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Daybyday;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Daybyday
{
    class SicaMap : IEntityTypeConfiguration<Sica>
    {
        public void Configure(EntityTypeBuilder<Sica> builder)
        {
            builder.ToTable("sica")
                .HasKey(a => a.idsica);
        }
    }
}
