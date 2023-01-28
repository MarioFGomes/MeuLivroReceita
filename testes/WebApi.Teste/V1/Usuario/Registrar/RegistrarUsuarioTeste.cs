using FluentAssertions;
using MeuLivroDeReceitas.Exceptions;
using System.Net;
using System.Text.Json;
using UtilitarioParaOsTestes.Requisicoes;
using Xunit;

namespace WebApi.Teste.V1.Usuario.Registrar;

public class RegistrarUsuarioTeste: ControllerBase
{
    private const string _Metodo = "api/usuario";
    public RegistrarUsuarioTeste(MeuLivroReceitasWebApplicationFactory<Program> factory):base(factory)
    {

    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();
        var resposta = await PostRequest(_Metodo,requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.Created);

        await using var responseBody = await resposta.Content.ReadAsStreamAsync();

        var responsetaData = await JsonDocument.ParseAsync(responseBody);

        responsetaData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Validar_Erro_Nome_Vazio()
    {
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();
        requisicao.Nome = "";
        var resposta = await PostRequest(_Metodo, requisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var responseBody = await resposta.Content.ReadAsStreamAsync();

        var responsetaData = await JsonDocument.ParseAsync(responseBody);

        var erros = responsetaData.RootElement.GetProperty("mensagem").EnumerateArray();
        erros.Should().ContainSingle().And.Contain(e => e.GetString().Equals(ResourceMensagensdeErro.NOME_Usuario_Embranco));
    }
}
