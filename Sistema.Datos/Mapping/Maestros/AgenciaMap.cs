using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Maestros;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema.Datos.Mapping.Maestros
{
    public class AgenciaMap : IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
            builder.ToTable("agencias")
            .HasKey(u => u.idagencia);
            builder.Property(u => u.agencia)
            .HasMaxLength(50);
        }
    }
}
