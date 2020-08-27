using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Post
{
    public class RealpostMap : IEntityTypeConfiguration<Realpost>
    {
        public void Configure(EntityTypeBuilder<Realpost> builder)
        {
            builder.ToTable("realposts")
                .HasKey(a => a.idrealpost);
            builder.HasOne(a => a.proveedorpost)
                .WithMany(d => d.realposts)
                .HasForeignKey(a => a.idproveedorpost);
        }
    }
}
