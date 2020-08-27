using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Post;

namespace Sistema.Datos.Mapping.Post
{
    public class Post2dateMap : IEntityTypeConfiguration<Post2date>
    {
        public void Configure(EntityTypeBuilder<Post2date> builder)
        {
            builder.ToTable("vPost")
                .HasKey(a => a.id);
        }
    }
}
