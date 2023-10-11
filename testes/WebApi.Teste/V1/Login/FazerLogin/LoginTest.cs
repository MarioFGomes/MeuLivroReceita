

using FluentAssertions;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;
using System.Net;
using System.Text.Json;
using UtilitarioParaOsTestes.Requisicoes;
using Xunit;

namespace WebApi.Teste.V1.Login.FazerLogin;

public class LoginTest: ControllerBase
{
    private const string _Metodo = "api/login";
    private MeuLivroDeReceitas.Domain.Entidade.Usuario _usuario;
    private string _senha;
    public LoginTest(MeuLivroReceitasWebApplicationFactory<Program> factory) : base(factory)
    {
        _usuario= factory.RecuperarUsuario();
        _senha= factory.RecuperarSenha();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {

        var requisicao = new RequisicaoLoginJson
        {
            Email = _usuario.Email,
            Senha = _senha
        };

        var resposta = await PostRequest(_Metodo, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var responseBody = await resposta.Content.ReadAsStreamAsync();

        var responsetaData = await JsonDocument.ParseAsync(responseBody);
        //responsetaData.RootElement.GetProperty("Nome").GetString().Should().NotBeNullOrWhiteSpace().And.Be(_usuario.Nome);
        responsetaData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Email_Invalidade()
    {
        var requisicao = new RequisicaoLoginJson
        {
            Email = "Email@Invalido.com",
            Senha = _senha
        };

        var resposta = await PostRequest(_Metodo, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var responseBody = await resposta.Content.ReadAsStreamAsync();

        var responsetaData = await JsonDocument.ParseAsync(responseBody);

        var erros = responsetaData.RootElement.GetProperty("mensagem").Deserialize<List<string>>();
        erros.Should().ContainSingle().And.Contain(ResourceMensagensdeErro.LOGIN_INVALIDO);
    }

    [Fact]
    public async Task Validar_Erro_Senha_Invalidade()
    {
        var requisicao = new RequisicaoLoginJson
        {
            Email = _usuario.Email,
            Senha = "senha Invalida"
        };

        var resposta = await PostRequest(_Metodo, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var responseBody = await resposta.Content.ReadAsStreamAsync();

        var responsetaData = await JsonDocument.ParseAsync(responseBody);

        var erros = responsetaData.RootElement.GetProperty("mensagem").Deserialize<List<string>>();
        erros.Should().ContainSingle().And.Contain(ResourceMensagensdeErro.LOGIN_INVALIDO);
    }

    [Fact]
    public async Task Validar_Erro_Senha_Email_Invalidade()
    {
        var requisicao = new RequisicaoLoginJson
        {
            Email = "Email@Invalido.com",
            Senha = "senha Invalida"
        };

        var resposta = await PostRequest(_Metodo, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        await using var responseBody = await resposta.Content.ReadAsStreamAsync();

        var responsetaData = await JsonDocument.ParseAsync(responseBody);

        var erros = responsetaData.RootElement.GetProperty("mensagem").Deserialize<List<string>>();
        erros.Should().ContainSingle().And.Contain(ResourceMensagensdeErro.LOGIN_INVALIDO);
    }
}
