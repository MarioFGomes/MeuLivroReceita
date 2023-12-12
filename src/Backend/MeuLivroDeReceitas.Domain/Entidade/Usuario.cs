

namespace MeuLivroDeReceitas.Domain.Entidade;

public class Usuario: EntidadeBase
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public string Avatar_url { get; set; }
    public string about { get; set; }
    public string location { get; set; }
    public string bio { get; set; }
    public int seguidores { get; set; }
    public int seguindo { get; set; }
    public bool perfilpublico { get; set; }
    public List<UsuarioFotos> Fotos=new();
    public List<Followers> Seguidores = new();
    public List<Following> Seguindo = new();
}
