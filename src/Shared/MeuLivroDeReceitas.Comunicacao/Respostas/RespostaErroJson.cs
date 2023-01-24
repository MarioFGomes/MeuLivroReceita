using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Comunicacao.Respostas;

public class RespostaErroJson
{
    public List<string> Mensagem { get; set; }
    public RespostaErroJson(string messagem)
    {
        Mensagem = new List<string>
        {
            messagem
        };
    }

    public RespostaErroJson(List<string> messagem)
    {
        Mensagem = messagem;
    }
}
