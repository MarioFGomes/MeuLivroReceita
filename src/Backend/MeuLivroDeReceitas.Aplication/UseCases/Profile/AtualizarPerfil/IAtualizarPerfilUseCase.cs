using MeuLivroDeReceitas.Comunicacao.Respostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Profile.AtualizarPerfil; 
public interface IAtualizarPerfilUseCase 
{
    Task Executar(Guid Id);
}
