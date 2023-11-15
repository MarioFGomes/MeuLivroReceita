using FluentValidation;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha
{
    public class RecuperarSenhaValidator: AbstractValidator<RequesicaoRecuperarSenha>
    {
        public RecuperarSenhaValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMensagensdeErro.Email_Usuario_Embranco);
            When(c => !string.IsNullOrEmpty(c.Email), () => {
                RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensdeErro.Email_INVALIDO);
            });
        }
    }
}
