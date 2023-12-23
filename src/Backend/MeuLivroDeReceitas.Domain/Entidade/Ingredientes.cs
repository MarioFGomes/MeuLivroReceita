using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade;
public class Ingredientes:EntidadeBase
{
    public string Nome { get; set; }
    public decimal Quantidade { get; set; }
    public string description { get; set; }
    public string pesograma { get; set; }
}
