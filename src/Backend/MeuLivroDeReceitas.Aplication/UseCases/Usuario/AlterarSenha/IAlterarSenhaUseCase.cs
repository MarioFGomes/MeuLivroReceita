using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;

public interface IAlterarSenhaUseCase
{
    Task Executar(RequisicaoAlterarSenha requisicao);
}
