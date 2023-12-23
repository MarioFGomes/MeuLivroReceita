using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class ReceitaFile: EntidadeBase 
{
    public Guid ReceitaID { get; set; }
    public string Originalname { get; set; }
    public string filename { get; set; }
    public string description { get; set; }
    public string url { get; set; }
}
