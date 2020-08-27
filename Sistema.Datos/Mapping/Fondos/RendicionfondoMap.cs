using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Fondos;

namespace Sistema.Datos.Mapping.Fondos
{
    public class RendicionfondoMap : IEntityTypeConfiguration<Rendicionfondo>
    {
        public void Configure(EntityTypeBuilder<Rendicionfondo> builder)
        {
            builder.ToTable("rendicionfondos")
                .HasKey(a => a.idrendicionfondo);
            builder.HasOne(a => a.distribucionfondo)
                .WithMany(d => d.rendicionfondos)
                .HasForeignKey(a => a.iddistribucionfondo);
            builder.HasOne(a => a.item)
                .WithMany(d => d.rendicionfondos)
                .HasForeignKey(a => a.iditem);
            builder.HasOne(a => a.subitem)
                .WithMany(d => d.rendicionfondos)
                .HasForeignKey(a => a.idsubitem);
            builder.HasOne(a => a.proveedor)
                .WithMany(d => d.rendicionfondos)
                .HasForeignKey(a => a.idproveedor);
        }
    }
}
