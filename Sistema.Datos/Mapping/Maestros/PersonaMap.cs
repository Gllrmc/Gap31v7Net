using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Usuarios;

namespace Sistema.Datos.Mapping.Maestros
{
    public class PersonaMap : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("personas")
                .HasKey(u => u.idpersona);
            builder.HasOne(a => a.usuario)
                .WithOne(d => d.persona)
                .HasForeignKey<Usuario>(a => a.idpersona);

        }
    }
}

