

namespace MeuLivroDeReceitas.Domain.Entidade;

public class Usuario: EntidadeBase
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public virtual UserProfile profile { get; set; }
    public virtual List<Followers> Seguidores { get; set; } = new();
    public virtual List<UsuarioImagem> Imagens { get; set; } = new();
    public virtual List<Following> Seguindo { get; set; } = new();
    public virtual List<Post> Posts { get; set; } = new();
}
