
using MeuLivroDeReceitas.Aplication.Servicos.Criptografia;

namespace UtilitarioParaOsTestes.Criptografia;

public class EncriptadorDeSenhaBuilder
{
    private static EncriptadorDeSenha _Instancia;
    
    public static EncriptadorDeSenha Instancia()
    {
        _Instancia = new EncriptadorDeSenha("4$!zIsSxp13EUS25");
        return _Instancia;
    }
}
