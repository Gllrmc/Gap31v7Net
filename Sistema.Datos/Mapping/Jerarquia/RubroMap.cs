using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Jerarquia;


namespace Sistema.Datos.Mapping.Jerarquia
{
    public class RubroMap : IEntityTypeConfiguration<Rubro>
    {
        public void Configure(EntityTypeBuilder<Rubro> builder)
        {
            builder.ToTable("rubros")
                .HasKey(r => r.idrubro);
            builder.HasIndex(a => a.orden)
                .IsUnique(true);
            builder.Property(r => r.rubroes)
                .HasMaxLength(50);
            builder.Property(r => r.rubroen)
                .HasMaxLength(50);
            builder.Property(r => r.orden)
                .HasMaxLength(5);
        }
    }
}
