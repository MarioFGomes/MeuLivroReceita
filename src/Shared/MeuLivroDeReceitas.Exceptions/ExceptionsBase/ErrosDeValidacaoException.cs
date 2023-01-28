using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase;

public class ErrosDeValidacaoException: MeuLivroDeReceitasException
{
    public List<string> MessaErros { get; set; }

    public ErrosDeValidacaoException(List<string> Erros):base(string.Empty)
    {
        MessaErros=Erros;
    }

}
