using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Maestros;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    public class PitchMap : IEntityTypeConfiguration<Pitch>
    {
        public void Configure(EntityTypeBuilder<Pitch> builder)
        {
            builder.ToTable("pitch")
            .HasKey(u => u.idpitch);
            builder.Property(u => u.pitch)
            .HasMaxLength(50);
        }
    }
}
