using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase;

[Serializable]
public class MeuLivroDeReceitasException:SystemException
{
    public MeuLivroDeReceitasException(string mensagem):base(mensagem)
    {

    }
    protected MeuLivroDeReceitasException(SerializationInfo info, StreamingContext context) : base(info, context) { }

}
