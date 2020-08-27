using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Maestros;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    public class ResultadoMap : IEntityTypeConfiguration<Resultado>
    {
        public void Configure(EntityTypeBuilder<Resultado> builder)
        {
            builder.ToTable("resultados")
            .HasKey(u => u.idresultado);
            builder.Property(u => u.resultado)
            .HasMaxLength(50);
        }
    }
}
