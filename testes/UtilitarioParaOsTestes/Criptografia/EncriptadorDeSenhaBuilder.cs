
using MeuLivroDeReceitas.Aplication.Servicos.Criptografia;

namespace UtilitarioParaOsTestes.Criptografia;

public class EncriptadorDeSenhaBuilder
{
    private static EncriptadorDeSenha _Instancia;
    
    public static EncriptadorDeSenha Instancia()
    {
        _Instancia = new EncriptadorDeSenha("NovaSenhawww");
        return _Instancia;
    }
}
