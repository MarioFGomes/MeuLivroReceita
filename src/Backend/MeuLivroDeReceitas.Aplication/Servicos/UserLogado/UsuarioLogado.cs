using MeuLivroDeReceitas.Aplication.Servicos.Token;
using MeuLivroDeReceitas.Domain.Entidade;
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
    public UsuarioLogado(IHttpContextAccessor httpContextAccesor, TokenController tokenController)
    {
        _httpContextAccessor= httpContextAccesor;
        _tokenController= tokenController;
    }
    public async Task<Usuario> RecuperarUsuario()
    {
        var authorization=_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

        throw new NotImplementedException();
    }
}
