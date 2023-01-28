

using MeuLivroDeReceitas.Domain.Entidade;

namespace MeuLivroDeReceitas.Domain.Repositorios;

public interface IUsuarioReadOnlyRepositorio
{
    Task<bool> ExistUsuarioEmail(string email);
    Task<Usuario> Login(string email, string senha);
}
