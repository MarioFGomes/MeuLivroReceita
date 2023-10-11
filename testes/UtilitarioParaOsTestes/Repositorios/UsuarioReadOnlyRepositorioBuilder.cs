using MeuLivroDeReceitas.Domain.Entidade;
using MeuLivroDeReceitas.Domain.Repositorios;
using Moq;

namespace UtilitarioParaOsTestes.Repositorios;

public class UsuarioReadOnlyRepositorioBuilder
{
    private static UsuarioReadOnlyRepositorioBuilder _instancia;
    private readonly Mock<IUsuarioReadOnlyRepositorio> _repositorio;


    private UsuarioReadOnlyRepositorioBuilder()
    {
        if (_repositorio == null)
        {
            _repositorio = new Mock<IUsuarioReadOnlyRepositorio>();
        }
    }
    public static UsuarioReadOnlyRepositorioBuilder Instancia()
    {
        _instancia = new UsuarioReadOnlyRepositorioBuilder();

        return _instancia;
    }


    public UsuarioReadOnlyRepositorioBuilder ExisteUsuarioComEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            _repositorio.Setup(i => i.ExistUsuarioEmail(email)).ReturnsAsync(true);
        }
        
        return this;
    }

    public UsuarioReadOnlyRepositorioBuilder RecuperarPorEmailSenha(Usuario user)
    {
        _repositorio.Setup(i => i.Login(user.Email, user.Senha)).ReturnsAsync(user);

        return this;
    }
    public IUsuarioReadOnlyRepositorio Construir()
    {
        return _repositorio.Object;
    }
}
