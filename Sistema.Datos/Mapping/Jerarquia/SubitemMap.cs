using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Jerarquia;

namespace Sistema.Datos.Mapping.Jerarquia
{
    public class SubitemMap : IEntityTypeConfiguration<Subitem>
    {
        public void Configure(EntityTypeBuilder<Subitem> builder)
        {
            builder.ToTable("subitems")
                .HasKey(a => a.idsubitem);
            builder.HasIndex(a => new { a.iditem, a.idsubitem })
                .IsUnique(true);
            builder.HasOne(a => a.item)
                .WithMany(d => d.subitems)
                .HasForeignKey(a => a.iditem);

        }
    }
}
