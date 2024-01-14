using FluentValidation;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.AtualizarUser; 
public class AtualizarUsuarioValidator: AbstractValidator<RequisicaoAtualizarUsuario> 
{

    public AtualizarUsuarioValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage(ResourceMensagensdeErro.NOME_Usuario_Embranco);
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMensagensdeErro.Email_Usuario_Embranco);
        RuleFor(c => c.Telefone).NotEmpty().WithMessage(ResourceMensagensdeErro.TELEFONE_EMBRANCO);

        When(c => !string.IsNullOrEmpty(c.Email), () => {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensdeErro.Email_INVALIDO);
        });

        When(c => !string.IsNullOrEmpty(c.Telefone), () => {
            RuleFor(c => c.Telefone).Custom((telefone, contexto) => {
                var padraoTelefone = "[0-9]{3} [0-9]{3}-[0-9]{3}-[0-9]{3}";
                var isMatch = Regex.IsMatch(telefone, padraoTelefone);
                if (!isMatch) {
                    contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), ResourceMensagensdeErro.TELEFONE_INVALIDO));
                }
            });
        });
    }
}
