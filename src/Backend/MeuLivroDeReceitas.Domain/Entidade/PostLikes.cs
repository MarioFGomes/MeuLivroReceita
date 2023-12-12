using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class PostLikes 
{
    public Guid Id {  get; set; }
    public Guid PostID { get; set; }
    public Guid UserID { get; set; }
    public DateTime DataRegistro { get; set; }
}
