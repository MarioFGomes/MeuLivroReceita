using FluentMigrator.Runner;
using MeuLivroDeReceitas.Domain.Extension;
using MeuLivroDeReceitas.Domain.Repositorios;
using MeuLivroDeReceitas.Infrastructure.AcessoRepositorio;
using MeuLivroDeReceitas.Infrastructure.AcessoRepositorio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeuLivroDeReceitas.Infrastructure;

public static class Bootstrapper
{
    public static void AddRespositorio(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddFluentMigrator(services, configurationManager);
        AddContexto(services, configurationManager);
        AddRepositorios(services);
        AddUnidadeDeTrabalho(services);
        
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
    {
        bool.TryParse(configurationManager.GetSection("Configuracoes:BancodeDadosInMemory").Value, out bool bancodeDadosInMemory);

        if (!bancodeDadosInMemory) { 
            var ConectionString=
          services.AddFluentMigratorCore().ConfigureRunner(c =>
             c.AddSqlServer()
             .WithGlobalConnectionString(configurationManager.GetConexaoCompleta()).ScanIn(Assembly.Load("MeuLivroDeReceitas.Infrastructure")).For.All());
        }
    }

    public static string GetConexaoCompleta(this IConfiguration configurationManager)
    {
        var nomeDatabase= configurationManager.GetNomeDatabase();
        var conexao = configurationManager.GetConexa();

        return $"{conexao}Database={nomeDatabase}";
    }

    private static void AddRepositorios(IServiceCollection services)
    {
        services.AddScoped<IUsuarioReadOnlyRepositorio, UsuarioRepositorio>()
                .AddScoped<IUsuarioWriteOnlyRepositorio, UsuarioRepositorio>();
        
    }

    private static void AddUnidadeDeTrabalho(IServiceCollection services)
    {
        services.AddScoped<IUnidadeDeTrabalho, UnidateDeTrabalho>();
                
    }

    private static void AddContexto(IServiceCollection services, IConfiguration configurationManager)
    {
        bool.TryParse( configurationManager.GetSection("Configuracoes:BancodeDadosInMemory").Value,out bool bancodeDadosInMemory);

        if (!bancodeDadosInMemory)
        {
            var conectionString = configurationManager.GetConexaoCompleta();

            services.AddDbContext<MeuLivroReceitaContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(conectionString);

            });
        }
        

    }
}
