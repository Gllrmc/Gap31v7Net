using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Daybyday;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Daybyday
{
    public class Shoot2dateMap : IEntityTypeConfiguration<Shoot2date>
    {
        public void Configure(EntityTypeBuilder<Shoot2date> builder)
        {
            builder.ToTable("vShooting")
                .HasKey(a => a.id);
        }
    }
}
