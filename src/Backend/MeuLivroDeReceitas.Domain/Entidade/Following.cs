using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class Following: EntidadeBase 
{
    public Guid UserID { get; set; }
    public Guid seguidoID { get; set; }
}
