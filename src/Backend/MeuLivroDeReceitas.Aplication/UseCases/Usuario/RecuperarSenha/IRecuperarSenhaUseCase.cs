using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha;

public interface IRecuperarSenhaUseCase
{
    Task<RespostaVarificationCode> Executar(RequisicaoRecuperarSenha requisicao);
}
