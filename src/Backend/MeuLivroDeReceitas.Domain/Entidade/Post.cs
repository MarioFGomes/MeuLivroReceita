using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class Post 
{
    public Guid Id { get; set; }
    public string Tipo { get; set; }
    public string Conteudo { get; set; }
    public string Legenda { get; set; }
    public Guid authorId { get; set; }
    public Usuario author { get; set; }
    public DateTime CreatedDate { get; set;}
    public DateTime UpdatedDate { get; set; }
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
