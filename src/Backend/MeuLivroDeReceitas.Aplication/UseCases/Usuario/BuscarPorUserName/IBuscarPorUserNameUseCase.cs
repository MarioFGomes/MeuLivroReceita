using MeuLivroDeReceitas.Comunicacao.Respostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.BuscarPorUserName; 
public interface IBuscarPorUserNameUseCase 
{
    List<RespostaUser> Execute(string  username);
}
