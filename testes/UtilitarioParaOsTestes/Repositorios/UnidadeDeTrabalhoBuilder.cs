
using MeuLivroDeReceitas.Domain.Repositorios;
using Moq;

namespace UtilitarioParaOsTestes.Repositorios;

public class UnidadeDeTrabalhoBuilder
{
    private static UnidadeDeTrabalhoBuilder _instancia;
    private readonly Mock<IUnidadeDeTrabalho> _repositorio;


    public UnidadeDeTrabalhoBuilder()
    {
        if (_repositorio == null)
        {
            _repositorio = new Mock<IUnidadeDeTrabalho>();
        }
    }
    public static UnidadeDeTrabalhoBuilder Instancia()
    {
        _instancia = new UnidadeDeTrabalhoBuilder();

        return _instancia;
    }

    public IUnidadeDeTrabalho Construir()
    {
        return _repositorio.Object;
    }
}
