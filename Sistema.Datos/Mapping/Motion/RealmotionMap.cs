using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Motion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos.Mapping.Motion
{
    public class RealmotionMap : IEntityTypeConfiguration<Realmotion>
    {
        public void Configure(EntityTypeBuilder<Realmotion> builder)
        {
            builder.ToTable("realmotions")
                .HasKey(a => a.idrealmotion);
            builder.HasOne(a => a.proveedormotion)
                .WithMany(d => d.realmotions)
                .HasForeignKey(a => a.idproveedormotion);
        }
    }
}
