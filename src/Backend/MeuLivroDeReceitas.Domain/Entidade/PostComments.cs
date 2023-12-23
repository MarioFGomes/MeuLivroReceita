using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class PostComments:EntidadeBase
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string Comentario { get; set; }

}
