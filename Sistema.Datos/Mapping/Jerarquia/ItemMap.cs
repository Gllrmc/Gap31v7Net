using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Jerarquia;

namespace Sistema.Datos.Mapping.Jerarquia
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("items")
                .HasKey(a => a.iditem);
            builder.HasIndex(a => new { a.idsubrubro, a.orden })
                .IsUnique(true);
            builder.HasOne(a => a.subrubros)
                .WithMany(d => d.items)
                .HasForeignKey(a => a.idsubrubro);
        }
    }
}
