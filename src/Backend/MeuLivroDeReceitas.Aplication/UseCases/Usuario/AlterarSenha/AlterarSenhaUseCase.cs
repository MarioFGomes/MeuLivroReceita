using MeuLivroDeReceitas.Aplication.Servicos.UserLogado;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;

public class AlterarSenhaUseCase : IAlterarSenhaUseCase
{
    private readonly IUsuarioWriteOnlyRepositorio _repositorio;
    private readonly IUsuarioLogado _usuarioLogado;
    public AlterarSenhaUseCase(IUsuarioWriteOnlyRepositorio repositorio, IUsuarioLogado usuarioLogado)
    {
        _repositorio = repositorio;
        _usuarioLogado = usuarioLogado;
    }
    public async Task Executar(RequisicaoAlterarSenha requisicao)
    {
        var usuario = await _usuarioLogado.RecuperarUsuario();
        _repositorio.Update(usuario);
    }
}
