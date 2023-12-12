using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class Followers: EntidadeBase 
{
    public Guid UserID { get; set; }
    public Guid seguidorID { get; set; }
}
