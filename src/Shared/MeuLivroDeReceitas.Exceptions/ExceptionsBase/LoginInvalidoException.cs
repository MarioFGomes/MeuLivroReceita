

namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase;

public class LoginInvalidoException: MeuLivroDeReceitasException
{
    public LoginInvalidoException() : base(ResourceMensagensdeErro.LOGIN_INVALIDO)
    {

    }
}
