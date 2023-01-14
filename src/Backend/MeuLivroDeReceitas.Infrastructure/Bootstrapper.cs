﻿

using FluentMigrator.Runner;
using MeuLivroDeReceitas.Domain.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeuLivroDeReceitas.Infrastructure;

public static class Bootstrapper
{
    public static void AddRespositorio(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddFluentMigrator(services, configurationManager);
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
    {
        var ConectionString=
        services.AddFluentMigratorCore().ConfigureRunner(c =>
             c.AddMySql5()
             .WithGlobalConnectionString(configurationManager.GetConexaoCompleta()).ScanIn(Assembly.Load("MeuLivroDeReceitas.Infrastructure")).For.All());
    }

    public static string GetConexaoCompleta(this IConfiguration configurationManager)
    {
        var nomeDatabase= configurationManager.GetNomeDatabase();
        var conexao = configurationManager.GetConexa();

        return $"{conexao}Database={nomeDatabase}";
    }
}
