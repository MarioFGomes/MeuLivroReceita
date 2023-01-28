using FluentValidation;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;
using System.Text.RegularExpressions;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;

public class RegistrarUsuarioValidator:AbstractValidator<RequisicoesRegistarUsuarioJson>
{
    public RegistrarUsuarioValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage(ResourceMensagensdeErro.NOME_Usuario_Embranco);
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMensagensdeErro.Email_Usuario_Embranco);
        RuleFor(c => c.Telefone).NotEmpty().WithMessage(ResourceMensagensdeErro.TELEFONE_EMBRANCO);
        RuleFor(c => c.Senha).NotEmpty().WithMessage(ResourceMensagensdeErro.SENHA_EMBRANCO);
       

        When(c => !string.IsNullOrEmpty(c.Email), () => {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensdeErro.Email_INVALIDO);
        });

        When(c => !string.IsNullOrEmpty(c.Senha), () =>
        {
            RuleFor(c => c.Senha).MinimumLength(6).WithMessage(ResourceMensagensdeErro.SENHA_INVALIDA);
        });

        When(c => !string.IsNullOrEmpty(c.Telefone), () => {
            RuleFor(c => c.Telefone).Custom((telefone, contexto) =>
            {
                var padraoTelefone = "[0-9]{3} [0-9]{3}-[0-9]{3}-[0-9]{3}";
                var isMatch = Regex.IsMatch(telefone, padraoTelefone);
                if (!isMatch)
                {
                    contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), ResourceMensagensdeErro.TELEFONE_INVALIDO));
                }
            });
        });

    }
}
