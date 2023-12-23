using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class Post:EntidadeBase
{
    public string Conteudo { get; set; }
    public string Legenda { get; set; }
    public Guid UsuarioId { get; set; }
    public virtual List<PostComments> comments { get; set; }=new();
    public virtual List<PostReactions> reactions { get; set; }=new();
    public virtual List<PostFile> files { get; set; } = new();
    public int NumeroComentarios 
    { 
        get
        {
          return comments.Count;
    }   }

    public int Numeroreactions
    {
        get
        {
           return reactions.Count;
        }
    }
}
