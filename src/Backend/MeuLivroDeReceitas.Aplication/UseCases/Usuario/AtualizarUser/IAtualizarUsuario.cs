using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.AtualizarUser; 
public interface IAtualizarUsuario {

    Task Executar(RequisicaoAtualizarUsuario requisicao, Guid Id);
}
