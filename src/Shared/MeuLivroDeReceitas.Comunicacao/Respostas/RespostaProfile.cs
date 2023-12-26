using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Comunicacao.Respostas;
public class RespostaProfile
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string FotoPerfil { get; set; }
    public string About { get; set; }
    public string Location { get; set; }
    public string Bio { get; set; }
    public Guid usuarioId { get; set; }
    public int Type { get; set; }
    public int NumeroSeguidores { get; set; }
    public int NumeroSeguindo { get; set; }
    public int NumeroPosts {get; set;}
    public DateTime DataRegisto { get; set; }
    public int Status { get; set; }
    public DateTime LastUpdate { get; set; }
}
