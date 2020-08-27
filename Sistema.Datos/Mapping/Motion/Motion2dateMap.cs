using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Motion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Motion
{
    public class Motion2dateMap : IEntityTypeConfiguration<Motion2date>
    {
        public void Configure(EntityTypeBuilder<Motion2date> builder)
        {
            builder.ToTable("vMotion")
                .HasKey(a => a.id);
        }
    }
}
