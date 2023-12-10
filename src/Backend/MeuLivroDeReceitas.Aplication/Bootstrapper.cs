using MeuLivroDeReceitas.Aplication.Servicos.Criptografia;
using MeuLivroDeReceitas.Aplication.Servicos.Token;
using MeuLivroDeReceitas.Aplication.Servicos.UserLogado;
using MeuLivroDeReceitas.Aplication.UseCases.Login.FazerLogin;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha;
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
        AdicionarChaveAdicionalSenha(services, configurationManager);
        AdicionarTokenJwt(services, configurationManager);
        RegistrarUsuario(services);


    }

    private static void AdicionarChaveAdicionalSenha(this IServiceCollection services, IConfiguration configurationManager)
    {
        var setion = configurationManager.GetSection("Configuracoes:Senha:chaveDeEncriptacao");

        services.AddScoped(options => new EncriptadorDeSenha(setion.Value));
    }

    private static void AdicionarTokenJwt(this IServiceCollection services, IConfiguration configurationManager)
    {
        var setionTime = configurationManager.GetSection("Configuracoes:Jwt:TempoDeVidaTokenMinutos");
        var setionChave = configurationManager.GetSection("Configuracoes:Jwt:ChaveDeToken");

        services.AddScoped(options => new TokenController(Convert.ToDouble(setionTime.Value), setionChave.Value));
    } 

    private static void RegistrarUsuario(IServiceCollection service)
    {
        service.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>()
               .AddScoped<ILoginUseCase, LoginUseCase>()
               .AddScoped<IAlterarSenhaUseCase, AlterarSenhaUseCase>()
               .AddScoped<IUsuarioLogado, UsuarioLogado>()
               .AddScoped<IRecuperarSenhaUseCase, RecuperarSenhaUseCase>();
    }
}
