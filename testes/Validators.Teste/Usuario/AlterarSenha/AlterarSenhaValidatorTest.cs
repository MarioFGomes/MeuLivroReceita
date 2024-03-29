﻿

using FluentAssertions;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;
using MeuLivroDeReceitas.Exceptions;
using UtilitarioParaOsTestes.Requisicoes;
using Xunit;

namespace Validators.Teste.Usuario.AlterarSenha;

public class AlterarSenhaValidatorTest
{
    [Fact]
    public void Validar_Sucesso()
    {
        var validator = new AlterarSenhaValidator();
        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeTrue();

    }


    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Validar_Erro_Senha_Invalida(int tamanhosenha)
    {
        var validator = new AlterarSenhaValidator();
        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir(tamanhosenha);

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.SENHA_INVALIDA));
    }

    [Fact]
    public void Validar_Erro_Nome_Vazio()
    {
        var validator = new AlterarSenhaValidator();
        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();

        requisicao.NovaSenha = string.Empty;

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.SENHA_EMBRANCO));
    }
}
