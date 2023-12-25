using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Comunicacao.Requisicoes;
public class RequisicaoRegistrarProfile
{
    public string Description { get; set; }
    public string FotoPerfil { get; set; }
    public string About { get; set; }
    public string Location { get; set; }
    public string Bio { get; set; }
    public Guid usuarioId { get; set; }
}
