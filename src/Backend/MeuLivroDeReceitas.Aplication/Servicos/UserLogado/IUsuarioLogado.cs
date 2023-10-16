using MeuLivroDeReceitas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.Servicos.UserLogado;

public interface IUsuarioLogado
{
    Task<Usuario> RecuperarUsuario();
}
