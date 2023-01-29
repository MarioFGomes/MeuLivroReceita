

using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;

namespace MeuLivroDeReceitas.Aplication.UseCases.Login.FazerLogin;

public interface ILoginUseCase
{
    Task<RespostaLoginJson> Execute(RequisicaoLoginJson requisicao);
}
