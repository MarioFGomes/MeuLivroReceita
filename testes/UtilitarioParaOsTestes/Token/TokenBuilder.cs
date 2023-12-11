

using MeuLivroDeReceitas.Aplication.Servicos.Token;

namespace UtilitarioParaOsTestes.Token;

public class TokenBuilder
{

    private static TokenController _Instancia;

    public static TokenController Instancia()
    {
        _Instancia = new TokenController(1000, "cUNGSE9aRTIqNHc1WThYZm55aTUjJDZtQ0ByMU5xRjJUMjEhSjEqVW41aGlnVg==");
        return _Instancia;
    }

    public static TokenController TokenExpirado()
    {
        _Instancia = new TokenController(0.0166667, "cUNGSE9aRTIqNHc1WThYZm55aTUjJDZtQ0ByMU5xRjJUMjEhSjEqVW41aGlnVg==");
        return _Instancia;
    }
}
