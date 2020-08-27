using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    class TipoproyMap : IEntityTypeConfiguration<Tipoproy>
    {
        public void Configure(EntityTypeBuilder<Tipoproy> builder)
        {
            builder.ToTable("tipoproys")
                .HasKey(a => a.idtipoproy);
        }
    }
}
