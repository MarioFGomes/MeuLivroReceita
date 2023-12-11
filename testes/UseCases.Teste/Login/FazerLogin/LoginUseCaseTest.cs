using FluentAssertions;
using MeuLivroDeReceitas.Aplication.UseCases.Login.FazerLogin;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using UtilitarioParaOsTestes.Criptografia;
using UtilitarioParaOsTestes.Entidades;
using UtilitarioParaOsTestes.Repositorios;
using UtilitarioParaOsTestes.Token;
using Xunit;

namespace UseCases.Teste.Login.FazerLogin;

public class LoginUseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (var user, var senha) = UsuarioBuilder.Contruir();

        var useCase = CriarUseCase(user);

        var resposta = await useCase.Execute(new RequisicaoLoginJson
        {
            Email = user.Email,
            Senha = senha
        });

        resposta.Should().NotBeNull();
        resposta.Nome.Should().Be(user.Nome);
        resposta.Token.Should().NotBeNullOrWhiteSpace();
    }
    [Fact]

    public async Task Validar_Erro_Senha_Invalidade()
    {
        (var user, var senha) = UsuarioBuilder.Contruir();

        var useCase = CriarUseCase(user);

        Func<Task> acao = async () =>
        {
            await useCase.Execute(new RequisicaoLoginJson
            {
                Email = user.Email,
                Senha = "senha Invalida"
            });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>()
            .Where(exception => exception.Message.Equals(ResourceMensagensdeErro.LOGIN_INVALIDO));
    }

    [Fact]

    public async Task Validar_Erro_Email_Invalidade()
    {
        (var user, var senha) = UsuarioBuilder.Contruir();

        var useCase = CriarUseCase(user);

        Func<Task> acao = async () =>
        {
            await useCase.Execute(new RequisicaoLoginJson
            {
                Email = "Email@Invalido.com",
                Senha = senha
            });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>()
            .Where(exception => exception.Message.Equals(ResourceMensagensdeErro.LOGIN_INVALIDO));
    }

    [Fact]

    public async Task Validar_Erro_Email_Senha_Invalidade()
    {
        (var user, var senha) = UsuarioBuilder.Contruir();

        var useCase = CriarUseCase(user);

        Func<Task> acao = async () =>
        {
            await useCase.Execute(new RequisicaoLoginJson
            {
                Email = "Email@Invalido.com",
                Senha = "senha Invalida"
            });
        };

        await acao.Should().ThrowAsync<LoginInvalidoException>()
            .Where(exception => exception.Message.Equals(ResourceMensagensdeErro.LOGIN_INVALIDO));
    }

    private static LoginUseCase CriarUseCase(MeuLivroDeReceitas.Domain.Entidade.Usuario usuario)
    {
        var EncriptadorSenha = EncriptadorDeSenhaBuilder.Instancia();
        var Token = TokenBuilder.Instancia();
        var UsuarioReadOnly = UsuarioReadOnlyRepositorioBuilder.Instancia().RecuperarPorEmailSenha(usuario).Construir();

        return new LoginUseCase(UsuarioReadOnly, EncriptadorSenha, Token);
    }
}
