using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UtilitarioParaOsTestes.Requisicoes;
using FluentAssertions;
using WebApi.Teste;
using Xunit;
using UtilitarioParaOsTestes.Token;

namespace WebApi.Teste.V1.Usuario.AlterarSenha;

public class AlterarSenhaTokenInvalido : ControllerBase

{
    private const string _Metodo = "api/Usuario/alterar-senha";
    private MeuLivroDeReceitas.Domain.Entidade.Usuario _usuario;
    private readonly string _senha;
    public AlterarSenhaTokenInvalido(MeuLivroReceitasWebApplicationFactory<Program> factory) : base(factory)
    {
        _usuario = factory.RecuperarUsuario();
        _senha = factory.RecuperarSenha();
    }

    [Fact]
    public async Task Validar_ErroTokenVazio()
    {
        var token = string.Empty;

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        requisicao.SenhaAntiga = _senha;

        var resposta = await PutRequest(_Metodo, requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

    }

    [Fact]
    public async Task Validar_ErroTokenUsuarioFake()
    {
        var token = TokenBuilder.Instancia().GerarToken("usuariofake@gmail.com");

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        requisicao.SenhaAntiga = _senha;

        var resposta = await PutRequest(_Metodo, requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

    }

    [Fact]
    public async Task Validar_ErroTokenExpirado()
    {
        var token = TokenBuilder.TokenExpirado().GerarToken(_usuario.Email);

        Thread.Sleep(1000);

        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        requisicao.SenhaAntiga = _senha;

        var resposta = await PutRequest(_Metodo, requisicao, token);

        resposta.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

    }

}
