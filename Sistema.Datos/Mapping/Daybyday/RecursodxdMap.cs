using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Daybyday;

namespace Sistema.Datos.Mapping.Daybyday
{
    public class RecursodxdMap : IEntityTypeConfiguration<Recursodxd>
    {
        public void Configure(EntityTypeBuilder<Recursodxd> builder)
        {
            builder.ToTable("recursosdxds")
                .HasKey(a => a.idrecursodxd);
            builder.HasOne(a => a.crew)
                .WithMany(d => d.recursodxds)
                .HasForeignKey(a => a.idcrew);
            builder.HasOne(a => a.proyecto)
                .WithMany(d => d.recursodxds)
                .HasForeignKey(a => a.idproyecto);
            builder.HasOne(a => a.item)
                .WithMany(d => d.recursodxds)
                .HasForeignKey(a => a.iditem);
            builder.HasOne(a => a.subitem)
                .WithMany(d => d.recursodxds)
                .HasForeignKey(a => a.idsubitem);
        }
    }
}
