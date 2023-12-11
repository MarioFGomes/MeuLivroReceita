using FluentAssertions;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Domain.Entidade;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitarioParaOsTestes.Criptografia;
using UtilitarioParaOsTestes.Entidades;
using UtilitarioParaOsTestes.Repositorios;
using UtilitarioParaOsTestes.Requisicoes;
using Xunit;

namespace UseCases.Teste.Usuario.AlterarSenha;

public class AlterarSenhaUseCaseTest
{
    [Fact]
    public async void ValidarSucessoAlterarSenha()
    {
        (var usuario,var senha)=UsuarioBuilder.Contruir();
        var UseCase = CriarUseCase(usuario);
        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir();
        requisicao.SenhaAntiga = senha;
        Func<Task> acao = async () =>
        {
            await UseCase.Executar(requisicao);
        };
        await acao.Should().NotThrowAsync();
    }

    [Fact]
    public async void ValidarErroSenhaEmBranco()
    {
        (var usuario, var senha) = UsuarioBuilder.Contruir();
        var UseCase = CriarUseCase(usuario);
        Func<Task> acao = async () =>
        {
            await UseCase.Executar(new RequisicaoAlterarSenha
            {
                SenhaAntiga = senha,
                NovaSenha = ""
            });
        };
        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(ex => ex.MessagesErros.Count == 1 && ex.MessagesErros.Contains(ResourceMensagensdeErro.SENHA_EMBRANCO));
    }

 
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async void ValidarErroSenhaAtualMinimoCaracter(int tamanhoSenha)
    {
        (var usuario, var senha) = UsuarioBuilder.Contruir();
        var UseCase = CriarUseCase(usuario);
        var requisicao = RequisicaoAlterarSenhaUsuarioBuilder.Construir(tamanhoSenha);
         requisicao.SenhaAntiga = senha;
        Func<Task> acao = async () =>
        {
            await UseCase.Executar(requisicao);
        };
        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
        .Where(ex => ex.MessagesErros.Count == 1 && ex.MessagesErros.Contains(ResourceMensagensdeErro.SENHA_INVALIDA));
    }

    private static AlterarSenhaUseCase CriarUseCase(MeuLivroDeReceitas.Domain.Entidade.Usuario usuario)
    {
        var repositorio = UsuarioWriteOnlyRepositorioBuilder.Instancia().RecuperarPorId(usuario).Construir();
        var EncripitadorSenha = EncriptadorDeSenhaBuilder.Instancia();
        var UnidadeTrabalho = UnidadeDeTrabalhoBuilder.Instancia().Construir();
        var usuarioLogado=UsuarioLogadoBuilder.Instancia().RecuperarUsuario(usuario).Construir();

        return new AlterarSenhaUseCase(repositorio, usuarioLogado,EncripitadorSenha, UnidadeTrabalho);
    }
}
