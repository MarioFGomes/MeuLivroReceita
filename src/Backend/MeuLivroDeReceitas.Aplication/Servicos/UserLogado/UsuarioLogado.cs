using MeuLivroDeReceitas.Aplication.Servicos.Token;
using MeuLivroDeReceitas.Domain.Entidade;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.Servicos.UserLogado;

internal class UsuarioLogado : IUsuarioLogado
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TokenController _tokenController;
    private readonly IUsuarioReadOnlyRepositorio _readOnlyRepositorio;
    public UsuarioLogado(IHttpContextAccessor httpContextAccesor, TokenController tokenController, IUsuarioReadOnlyRepositorio usuarioReadOnly)
    {
        _httpContextAccessor= httpContextAccesor;
        _tokenController= tokenController;
        _readOnlyRepositorio= usuarioReadOnly;
    }
    public async Task<Usuario> RecuperarUsuario()
    {
        var authorization=_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
        var token = authorization["Bearer".Length..].Trim();
        var EmialUsuario=_tokenController.RecuperarEmail(token);

        var user = await _readOnlyRepositorio.RecuperarPorEmail(EmialUsuario);

        return user;
    }
}
