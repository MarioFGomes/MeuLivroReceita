using MeuLivroDeReceitas.Domain.Entidade;
using MeuLivroDeReceitas.Infrastructure.AcessoRepositorio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Teste;

public class MeuLivroReceitasWebApplicationFactory<TStartUp> : WebApplicationFactory<TStartUp> where TStartUp:class 
{
    private Usuario usuario;
    private string senha;
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
       

        builder.UseEnvironment("Test").ConfigureServices(services =>
        {
            var descritor = services.SingleOrDefault(d => d.ServiceType == typeof(MeuLivroReceitaContext));

            if (descritor != null) services.Remove(descritor);

            var provider=services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            services.AddDbContext<MeuLivroReceitaContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
                options.UseInternalServiceProvider(provider);
            });

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var scopeService = scope.ServiceProvider;

            var database = scopeService.GetRequiredService<MeuLivroReceitaContext>();

            database.Database.EnsureDeleted();

            (usuario, senha) =ContextSeedInMemory.Seed(database);
        });
    }

    public Usuario RecuperarUsuario()
    {
        return usuario;
    }

    public string RecuperarSenha()
    {
        return senha;
    }
}
