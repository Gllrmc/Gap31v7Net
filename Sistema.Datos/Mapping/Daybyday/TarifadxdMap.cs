using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Daybyday;

namespace Sistema.Datos.Mapping.Daybyday
{
    public class TarifadxdMap : IEntityTypeConfiguration<Tarifadxd>
    {
        public void Configure(EntityTypeBuilder<Tarifadxd> builder)
        {
            builder.ToTable("tarifadxds")
                    .HasKey(a => a.idtarifadxd);
            builder.HasOne(a => a.sica)
                .WithMany(d => d.tarifadxds);
        }
    }
}
