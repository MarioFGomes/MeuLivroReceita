using FluentAssertions;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitarioParaOsTestes.Requisicoes;
using Xunit;

namespace Validators.Teste.Usuario.Registrar;

public class RegistrarUsuarioValidatorTest
{

    #region Sucesso

    [Fact]
    public void Validar_Sucesso()
    {
        var validator = new RegistrarUsuarioValidator();
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeTrue();

    }

    #endregion

    #region Nome

    [Fact]
    public void Validar_Erro_Nome_Vazio()
    {
        var validator = new RegistrarUsuarioValidator();
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();

        requisicao.Nome = string.Empty;

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.NOME_Usuario_Embranco));
    }




    #endregion

    #region Email 

    [Fact]
    public void Validar_Erro_Email_Vazio()
    {
        var validator = new RegistrarUsuarioValidator();
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();

        requisicao.Email = string.Empty;

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.Email_Usuario_Embranco));
    }

    [Fact]
    public void Validar_Erro_Email_Invalid()
    {
        var validator = new RegistrarUsuarioValidator();
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();

        requisicao.Email = "mariogomes";

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.Email_INVALIDO));
    }

    #endregion

    #region Telefone

    [Fact]
    public void Validar_Erro_Telefone_Vazio()
    {
        var validator = new RegistrarUsuarioValidator();
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();

        requisicao.Telefone = string.Empty;

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.TELEFONE_EMBRANCO));
    }


    [Fact]
    public void Validar_Erro_Telefone_Invalid()
    {
        var validator = new RegistrarUsuarioValidator();
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();

        requisicao.Telefone ="932041319";

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.TELEFONE_INVALIDO));
    }


    #endregion

    #region Senha

    [Fact]
    public void Validar_Erro_Senha_Vazia()
    {
        var validator = new RegistrarUsuarioValidator();
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();

        requisicao.Senha = string.Empty;

        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.SENHA_EMBRANCO));
    }


    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Validar_Erro_Senha_Invalida(int tamanhosenha)
    {
        var validator = new RegistrarUsuarioValidator();
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir(tamanhosenha);
       
        var result = validator.Validate(requisicao);

        // usando o pacote FluentAssertions para validação dos testes

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensdeErro.SENHA_INVALIDA));
    }



    #endregion





}
