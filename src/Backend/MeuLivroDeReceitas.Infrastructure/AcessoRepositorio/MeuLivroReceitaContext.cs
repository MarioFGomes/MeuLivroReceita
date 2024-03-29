﻿using MeuLivroDeReceitas.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Infrastructure.AcessoRepositorio;

public class MeuLivroReceitaContext : DbContext
{

    public MeuLivroReceitaContext(DbContextOptions<MeuLivroReceitaContext> options) : base(options) { }

    public DbSet<Usuario> usuarios { get; set; }

    public DbSet<UserProfile> Profiles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuLivroReceitaContext).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
