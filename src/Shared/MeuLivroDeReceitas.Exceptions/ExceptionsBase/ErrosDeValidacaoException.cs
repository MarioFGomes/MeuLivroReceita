using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase;

[Serializable]
public class ErrosDeValidacaoException: MeuLivroDeReceitasException
{
    public List<string> MessagesErros { get; set; }

    public ErrosDeValidacaoException(List<string> Erros):base(string.Empty)
    {
        MessagesErros = Erros;
    }
    protected ErrosDeValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context) { }

}
