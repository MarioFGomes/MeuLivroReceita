using FluentAssertions;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using UtilitarioParaOsTestes.Criptografia;
using UtilitarioParaOsTestes.Mapper;
using UtilitarioParaOsTestes.Repositorios;
using UtilitarioParaOsTestes.Requisicoes;
using UtilitarioParaOsTestes.Token;
using Xunit;

namespace UseCases.Teste.Usuario.Registrar;

public class RegistrarUsuarioUsaseCaseTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();
        var usecase = CriarUseCase();
        var resposta = await usecase.Executar(requisicao);
        resposta.Should().NotBeNull();
        resposta.Token.Should().NotBeNullOrWhiteSpace();
    }

    #region  Email Duplicado

    [Fact]
    public async Task Validar_Eamil_Existemte()
    {
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();
        var usecase = CriarUseCase(requisicao.Email);

        Func<Task> acao = async () => { await usecase.Executar(requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            
            .Where(exception => exception.MessagesErros.Count == 1 && exception.MessagesErros.Contains(ResourceMensagensdeErro.Email_Já_Registrado));
    }

    #endregion

    #region Email Vazio


    [Fact]
    public async Task Validar_Eamil_Vazio()
    {
        var requisicao = RequisicaoRegistrarUsuarioBuilder.Contruir();
        var usecase = CriarUseCase(requisicao.Email);

        requisicao.Email = string.Empty;

        Func<Task> acao = async () => { await usecase.Executar(requisicao); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()

        .Where(exception => exception.MessagesErros.Count == 1 && exception.MessagesErros.Contains(ResourceMensagensdeErro.Email_Usuario_Embranco));
    }

    #endregion

    private RegistrarUsuarioUseCase CriarUseCase(string email="")
    {
        var UsuarioWriteOnly = UsuarioWriteOnlyRepositorioBuilder.Instancia().Construir();
        var Mapper = MapperBuilder.Instancia();
        var UnidadeDeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();
        var EncriptadorSenha = EncriptadorDeSenhaBuilder.Instancia();
        var Token = TokenBuilder.Instancia();
        var UsuarioReadOnly = UsuarioReadOnlyRepositorioBuilder.Instancia().ExisteUsuarioComEmail(email).Construir();

        return new RegistrarUsuarioUseCase(UsuarioWriteOnly, Mapper, UnidadeDeTrabalho, EncriptadorSenha, Token, UsuarioReadOnly);
    }
}
