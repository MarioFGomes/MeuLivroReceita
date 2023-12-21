using MeuLivroDeReceitas.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Infrastructure.Configurations;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasMany(u => u.Seguidores)
              .WithOne()
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Seguindo)
               .WithOne()
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Imagens)
              .WithOne()
             .OnDelete(DeleteBehavior.NoAction);
    }
}
