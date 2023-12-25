using MeuLivroDeReceitas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade;
public class UserProfile:EntidadeBase
{
    public string Description { get; set; }
    public string Avatar_url { get; set; }
    public string About { get; set; }
    public string Location { get; set; }
    public string Bio { get; set; }
    public Usuario usuario { get; set; }
    public Guid usuarioId { get; set; }
    public ProfileStatus Type { get; set; } = ProfileStatus.publico;
    public int NumeroSeguidores 
    { 
        get
        {
            return usuario.Seguidores.Count;
    }   }

    public int NumeroSeguindo
    {
        get
        {
            return usuario.Seguindo.Count;
        }
    }

    public int NumeroPosts
    {
        get
        {
            return usuario.Posts.Count;
        }
    }
}
