

using MeuLivroDeReceitas.Aplication.Servicos.Token;

namespace UtilitarioParaOsTestes.Token;

public class TokenBuilder
{

    private static TokenController _Instancia;

    public static TokenController Instancia()
    {
        _Instancia = new TokenController(1000, "Kno3WTcxdDJXeXBUdk5CcUk3IVFwRXhyTlE1WEVp");
        return _Instancia;
    }
}
