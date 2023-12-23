using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;

namespace MeuLivroDeReceitas.Aplication.UseCases.Profile.Registrar;
public interface IRegistrarProfileUseCase
{
    Task<RespostaProfileRegistrado> Executar(RequisicaoRegistrarProfile requisicao);
}
