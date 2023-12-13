using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class Followers: EntidadeBase 
{
    public Guid usuarioId { get; set; }
    public Guid seguidorId { get; set; }
    public Usuario usuario { get; set; }
    public Usuario seguidor { get; set; }
}
