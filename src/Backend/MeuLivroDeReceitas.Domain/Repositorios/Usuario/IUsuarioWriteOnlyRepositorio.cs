using MeuLivroDeReceitas.Domain.Entidade;

namespace MeuLivroDeReceitas.Domain.Repositorios.Usuario;

public interface IUsuarioWriteOnlyRepositorio
{
    Task Adicionar(MeuLivroDeReceitas.Domain.Entidade.Usuario usuario);
    void Update(MeuLivroDeReceitas.Domain.Entidade.Usuario usuario);
}
