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
    public Guid UserID { get; set; }
    public DateTime CreatedDate { get; set;}
    public DateTime UpdatedDate { get; set; }
    public List<PostComments> comments { get; set; }=new();
    public List<PostLikes> Likes { get; set; }=new();
}
