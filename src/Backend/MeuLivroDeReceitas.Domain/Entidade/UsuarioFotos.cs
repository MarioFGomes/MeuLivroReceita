using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class UsuarioFotos: EntidadeBase 
{
    public Guid UserID { get; set; }
    public string Originalname { get; set; }
    public string filename { get; set; }
    public string description { get; set; }
    public string url { get; set; } 
}
