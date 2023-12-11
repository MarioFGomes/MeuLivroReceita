using FluentAssertions;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UtilitarioParaOsTestes.Requisicoes;
using Xunit;

namespace WebApi.Teste.V1.Usuario.AlterarSenha;

public class AlterarSenhaTeste: ControllerBase

{
    private const string _Metodo = "api/Usuario/alterar-senha";
    private readonly MeuLivroDeReceitas.Domain.Entidade.Usuario _usuario;
    private readonly string _senha;
    public AlterarSenhaTeste(MeuLivroReceitasWebApplicationFactory<Program> factory) : base(factory)
    {
        _usuario = factory.RecuperarUsuario();
        _senha = factory.RecuperarSenha();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        var token=await Login(_usuario.Email, _senha);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        requisicao.SenhaAntiga = _senha;

        var resposta = await PutRequest(_Metodo, requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);

    }

    public async Task Validar_Erro_SenhaEmBranco()
    {
        var token = await Login(_usuario.Email, _senha);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        requisicao.SenhaAntiga = _senha;
        requisicao.NovaSenha = string.Empty;

        var resposta = await PutRequest(_Metodo, requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var responseBody = await resposta.Content.ReadAsStreamAsync();

        var responsetaData = await JsonDocument.ParseAsync(responseBody);

        var erros = responsetaData.RootElement.GetProperty("MessagesErros").EnumerateArray();

        erros.Should().ContainSingle().And.Contain(x => x.GetString().Equals(ResourceMensagensdeErro.SENHA_EMBRANCO));
    }
}
