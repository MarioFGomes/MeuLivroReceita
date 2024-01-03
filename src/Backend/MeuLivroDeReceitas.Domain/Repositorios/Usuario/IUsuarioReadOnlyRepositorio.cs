using MeuLivroDeReceitas.Domain.Entidade;

namespace MeuLivroDeReceitas.Domain.Repositorios.Usuario;

public interface IUsuarioReadOnlyRepositorio
{
    Task<bool> ExistUsuarioEmail(string email);
    Task<MeuLivroDeReceitas.Domain.Entidade.Usuario> RecuperarPorEmail(string email);
    Task<MeuLivroDeReceitas.Domain.Entidade.Usuario> RecuperarPorId(Guid Id);
    List<MeuLivroDeReceitas.Domain.Entidade.Usuario> RecuperarPorUserName(string username);
    Task<MeuLivroDeReceitas.Domain.Entidade.Usuario> Login(string email, string senha);
}
