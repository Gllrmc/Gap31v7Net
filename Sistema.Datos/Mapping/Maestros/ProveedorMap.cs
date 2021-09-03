using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Maestros;


namespace Sistema.Datos.Mapping.Maestros
{
    public class ProveedorMap : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores")
                .HasKey(c => c.idproveedor);
            builder.HasOne(a => a.persona)
                .WithMany(d => d.proveedor)
                .HasForeignKey(a => a.idpersona);
        }
    }
}

