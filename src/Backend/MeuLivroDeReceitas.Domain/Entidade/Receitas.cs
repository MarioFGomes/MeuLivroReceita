using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Entidade; 
public class Receitas: EntidadeBase 
{
    public string Titulo { get; set; } 
    public string Descricao { get; set; }
    public List<string> Ingredientes = new();
    public string ModoPreparo { get; set; }
    public Guid UsuerID { get; set; }
    public string Categoria { get; set; }
    public bool Ispublic { get; set; }
    public List<ReceitaImagem> RecitaFotos=new();
}
