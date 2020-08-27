using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Proyectos
{
    class ProyectodateMap : IEntityTypeConfiguration<Proyectodate>
    {
        public void Configure(EntityTypeBuilder<Proyectodate> builder)
        {
            builder.ToTable("vPresRealComp")
                .HasKey(a => a.id);
        }
    }
}
