using FluentValidation;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;

public class AlterarSenhaValidator: AbstractValidator<RequisicaoAlterarSenha>
{
    public AlterarSenhaValidator()
    {
        RuleFor(c => c.NovaSenha).NotEmpty().WithMessage(ResourceMensagensdeErro.SENHA_EMBRANCO);

        When(c => !string.IsNullOrEmpty(c.NovaSenha), () =>
        {
            RuleFor(c => c.NovaSenha).MinimumLength(6).WithMessage(ResourceMensagensdeErro.SENHA_INVALIDA);
        });
    }
}
