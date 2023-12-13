

namespace MeuLivroDeReceitas.Domain.Entidade;

public class Usuario: EntidadeBase
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public string Avatar_url { get; set; }
    public string About { get; set; }
    public string Location { get; set; }
    public string Bio { get; set; }
    public bool Perfilpublico { get; set; }

    public List<UsuarioImagem> Imagens { get; set; } = new();

    public List<Followers> Seguidores { get; set; } = new();

    public List<Following> Seguindo { get; set; } = new();
}
