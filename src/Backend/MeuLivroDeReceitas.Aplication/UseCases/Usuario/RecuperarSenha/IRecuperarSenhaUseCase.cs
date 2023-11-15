using MeuLivroDeReceitas.Comunicacao.Requisicoes;


namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha;

public interface IRecuperarSenhaUseCase
{
    Task<string> Executar(string email);
}
