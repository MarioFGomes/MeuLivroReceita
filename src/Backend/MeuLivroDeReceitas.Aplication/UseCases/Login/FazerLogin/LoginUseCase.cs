

using MeuLivroDeReceitas.Aplication.Servicos.Criptografia;
using MeuLivroDeReceitas.Aplication.Servicos.Token;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;

namespace MeuLivroDeReceitas.Aplication.UseCases.Login.FazerLogin;

public class LoginUseCase : ILoginUseCase
{
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly TokenController _tokenController;
    private readonly IUsuarioReadOnlyRepositorio _UsuarioReadOnlyRepositorio;

    public LoginUseCase(IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController)
    {
        _UsuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }
    public async Task<RespostaLoginJson> Execute(RequisicaoLoginJson requisicao)
    {
        var senhaCriptografada = _encriptadorDeSenha.Criptografar(requisicao.Senha);
        var usuario = await _UsuarioReadOnlyRepositorio.Login(requisicao.Email, senhaCriptografada);

        if (usuario == null)
        {
            throw new LoginInvalidoException();
        }
        return new RespostaLoginJson
        {
            Nome = usuario.Nome,
            Token = _tokenController.GerarToken(usuario.Email)
        };
    }
}
