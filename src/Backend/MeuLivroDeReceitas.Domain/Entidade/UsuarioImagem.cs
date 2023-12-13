using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class UsuarioImagem: EntidadeBase 
{
    public Guid usuarioId { get; set; }
    public string Originalname { get; set; }
    public string Filename { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public Usuario usuario { get; set; }
}
