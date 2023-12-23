using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Repositorios.Profile;
public interface IProfileReadOnlyRepositorio
{
    Task<MeuLivroDeReceitas.Domain.Entidade.UserProfile> RecuperarPorId(Guid Id);
}
