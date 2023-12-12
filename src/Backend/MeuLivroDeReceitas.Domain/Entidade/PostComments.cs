using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class PostComments 
{
    public Guid ID {  get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string Comentario { get; set; }
    public DateTime CreatedDate { get; set;}
    public DateTime UpdatedDate { get; set;}
}
