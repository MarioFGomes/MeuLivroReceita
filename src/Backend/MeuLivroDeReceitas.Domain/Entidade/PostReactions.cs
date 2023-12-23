using MeuLivroDeReceitas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class PostReactions: EntidadeBase
{
    public Guid PostID { get; set; }
    public Guid UserID { get; set; }
    public ReactionsTypes Types { get; set; }
}
