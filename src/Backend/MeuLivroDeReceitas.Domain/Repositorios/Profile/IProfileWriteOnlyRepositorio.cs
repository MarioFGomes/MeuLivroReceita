using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Repositorios.Profile;
public interface IProfileWriteOnlyRepositorio
{
    Task Adicionar(MeuLivroDeReceitas.Domain.Entidade.UserProfile profile);
    void Update(MeuLivroDeReceitas.Domain.Entidade.UserProfile profile);
}
