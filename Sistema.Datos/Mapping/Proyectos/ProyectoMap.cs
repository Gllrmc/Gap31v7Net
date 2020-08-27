using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Proyectos;
using System;


namespace Sistema.Datos.Mapping.Proyectos
{
    class ProyectoMap : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.ToTable("proyectos")
                .HasKey(a => a.idproyecto);
            builder.HasIndex(a => new { a.orden })
                .IsUnique(true);
            builder.HasOne(a => a.productoras)
                .WithMany(d => d.proyectos)
                .HasForeignKey(a => a.idproductora);
            builder.HasOne(a => a.agencias)
                .WithMany(d => d.proyectos)
                .HasForeignKey(a => a.idagencia);
            builder.HasOne(a => a.origenes)
                .WithMany(d => d.proyectos)
                .HasForeignKey(a => a.idorigen);
            builder.HasOne(a => a.empresas)
                .WithMany(d => d.proyectos)
                .HasForeignKey(a => a.idempresa);
            builder.HasOne(a => a.cliente)
                .WithMany(d => d.proyectos)
                .HasForeignKey(a => a.idcliente);
            builder.HasOne(a => a.director)
                .WithMany(d => d.directorproyectos)
                .HasForeignKey(a => a.iddirector);
            builder.HasOne(a => a.codirector)
                .WithMany(d => d.codirectorproyectos)
                .HasForeignKey(a => a.idcodirector);
            builder.HasOne(a => a.ep)
                .WithMany(d => d.epproyectos)
                .HasForeignKey(a => a.idep);
            builder.HasOne(a => a.lp)
                .WithMany(d => d.lpproyectos)
                .HasForeignKey(a => a.idlp);
            builder.HasOne(a => a.cp)
                .WithMany(d => d.cpproyectos)
                .HasForeignKey(a => a.idcp);
        }
    }
}
