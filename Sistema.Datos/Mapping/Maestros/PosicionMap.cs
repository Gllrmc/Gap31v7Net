using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Maestros
{
    class PosicionMap : IEntityTypeConfiguration<Posicion>
    {
        public void Configure(EntityTypeBuilder<Posicion> builder)
        {
            builder.ToTable("posiciones")
            .HasKey(u => u.idposicion);
        }
    }
}
