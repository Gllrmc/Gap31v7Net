using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Jerarquia;

namespace Sistema.Datos.Mapping.Jerarquia
{
    public class SubrubroMap : IEntityTypeConfiguration<Subrubro>
    {
        public void Configure(EntityTypeBuilder<Subrubro> builder)
        {
            builder.ToTable("subrubros")
                .HasKey(a => a.idsubrubro);
            builder.HasIndex(a => new { a.idrubro, a.orden })
                .IsUnique(true);
            builder.HasOne(a => a.rubros)
                .WithMany(d => d.subrubros)
                .HasForeignKey(a => a.idrubro);
        }
    }
}
