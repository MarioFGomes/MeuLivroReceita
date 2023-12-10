using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using Moq;

namespace UtilitarioParaOsTestes.Repositorios;

public class UsuarioWriteOnlyRepositorioBuilder
{
    private static UsuarioWriteOnlyRepositorioBuilder _instancia;
    private readonly Mock<IUsuarioWriteOnlyRepositorio> _repositorio;
    private readonly Mock<IUsuarioReadOnlyRepositorio> _repositorioread=new Mock<IUsuarioReadOnlyRepositorio>();

    private UsuarioWriteOnlyRepositorioBuilder()
    {
        if (_repositorio == null)
        {
            _repositorio = new Mock<IUsuarioWriteOnlyRepositorio>();
        }
    }
    public static UsuarioWriteOnlyRepositorioBuilder Instancia()
    {
        _instancia = new UsuarioWriteOnlyRepositorioBuilder();

        return _instancia;
    }

    public UsuarioWriteOnlyRepositorioBuilder RecuperarPorId(MeuLivroDeReceitas.Domain.Entidade.Usuario usuario)
    {
        _repositorioread.Setup(c => c.RecuperarPorId(usuario.Id)).ReturnsAsync(usuario);
        return this;
    }

    public IUsuarioWriteOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}
