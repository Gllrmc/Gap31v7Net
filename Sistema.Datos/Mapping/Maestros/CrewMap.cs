using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Maestros;

namespace Sistema.Datos.Mapping.Maestros
{
    class CrewMap : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("crews")
                .HasKey(c => c.idcrew);

        }
    }
}
