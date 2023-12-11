using MeuLivroDeReceitas.Aplication.Servicos.Token;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace MeuLivroDeReceitas.API.Filtros;

public class AuthenticatedUser : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    private readonly TokenController _tokenController;
    private readonly IUsuarioReadOnlyRepositorio _readOnlyRepositorio;
    public AuthenticatedUser(TokenController tokenController, IUsuarioReadOnlyRepositorio readOnlyRepositorio)
    {
        _tokenController = tokenController;
        _readOnlyRepositorio= readOnlyRepositorio;
    }
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = RequestToken(context);

            var UserEmail = _tokenController.RecuperarEmail(token);

            var User = _readOnlyRepositorio.RecuperarPorEmail(UserEmail) ?? throw new MeuLivroDeReceitasException(string.Empty);
        }
        catch (SecurityTokenExpiredException)
        {
            TokenExpirado(context);
        }
        catch
        {
            UsuarioUnauthorized(context);
        }
    }

    private static string RequestToken(AuthorizationFilterContext context)
    {
        var authorization = context.HttpContext.Request.Headers["Authorization"].ToString();
        if (string.IsNullOrWhiteSpace(authorization)) throw new MeuLivroDeReceitasException(string.Empty);

          return  authorization["Bearer".Length..].Trim();
        
    }

    private static void TokenExpirado(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedObjectResult(new RespostaErroJson(ResourceMensagensdeErro.TokenExpirado));
    }

    private static void UsuarioUnauthorized(AuthorizationFilterContext context)
    {
        context.Result = new UnauthorizedObjectResult(new RespostaErroJson(ResourceMensagensdeErro.Usuario_Sem_Permissao));
    }
}
