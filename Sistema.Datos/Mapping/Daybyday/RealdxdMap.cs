using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Daybyday;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Daybyday
{
    public class RealdxdMap : IEntityTypeConfiguration<Realdxd>
    {
        public void Configure(EntityTypeBuilder<Realdxd> builder)
        {
            builder.ToTable("realdxds")
                .HasKey(a => a.idrealdxd);
            builder.HasOne(a => a.recursodxd)
                .WithMany(d => d.realdxd)
                .HasForeignKey(a => a.idrecursodxd);
        }
    }
}
