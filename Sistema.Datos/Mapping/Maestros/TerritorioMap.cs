using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Maestros;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema.Datos.Mapping.Maestros
{
    public class TerritorioMap : IEntityTypeConfiguration<Territorio>
    {
        public void Configure(EntityTypeBuilder<Territorio> builder)
        {
            builder.ToTable("territorios")
            .HasKey(u => u.idterritorio);
            builder.Property(u => u.territorio)
                .HasMaxLength(50);
        }
    }
}
