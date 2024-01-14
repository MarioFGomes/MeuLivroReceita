using FluentValidation;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha
{
    public class RecuperarSenhaValidator: AbstractValidator<RequisicaoRecuperarSenha>
    {
        public RecuperarSenhaValidator()
        {
            RuleFor(c => c.chanel).NotEmpty().WithMessage(ResourceMensagensdeErro.Email_Usuario_Embranco);
            RuleFor(c => c.Data).NotEmpty().WithMessage(ResourceMensagensdeErro.Email_Usuario_Embranco);
        }
    }
}
