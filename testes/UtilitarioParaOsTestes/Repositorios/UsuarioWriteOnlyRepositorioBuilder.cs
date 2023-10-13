using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using Moq;

namespace UtilitarioParaOsTestes.Repositorios;

public class UsuarioWriteOnlyRepositorioBuilder
{
    private static UsuarioWriteOnlyRepositorioBuilder _instancia;
    private readonly Mock<IUsuarioWriteOnlyRepositorio> _repositorio;


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

    public IUsuarioWriteOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}
