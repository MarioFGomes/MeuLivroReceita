using MeuLivroDeReceitas.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Infrastructure.Configurations;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasMany(u => u.comments)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.reactions)
               .WithOne()
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.files)
              .WithOne()
             .OnDelete(DeleteBehavior.NoAction);

    }
}
