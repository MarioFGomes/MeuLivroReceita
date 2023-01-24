using MeuLivroDeReceitas.Aplication.Servicos.Criptografia;
using MeuLivroDeReceitas.Aplication.Servicos.Token;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication;

public static class Bootstrapper
{
    public static void AddAplication(this IServiceCollection services , IConfiguration configurationManager)
    {
        AdcionarChaveAdicionalSenha(services, configurationManager);
        AcionarTokenJwt(services, configurationManager);

        services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
    }

    private static void AdcionarChaveAdicionalSenha(this IServiceCollection services, IConfiguration configurationManager)
    {
        var setion = configurationManager.GetSection("Configuracoes:chaveDeEncriptacao");

        services.AddScoped(options => new EncriptadorDeSenha(setion.Value));
    }

    private static void AcionarTokenJwt(this IServiceCollection services, IConfiguration configurationManager)
    {
        var setionTime = configurationManager.GetSection("Configuracoes:TempoDeVidaToken");
        var setionChave = configurationManager.GetSection("Configuracoes:ChaveDeToken");

        services.AddScoped(options => new TokenController(Convert.ToDouble(setionTime.Value), setionChave.Value));
    } 
}
