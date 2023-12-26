using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Profile.RecuperarPerfil; 
public interface IRecuperarPerfilUseCase {

    Task<RespostaProfile> Executar(Guid Id);
}
