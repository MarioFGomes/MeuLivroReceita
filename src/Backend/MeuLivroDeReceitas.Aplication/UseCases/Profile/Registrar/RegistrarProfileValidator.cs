using FluentValidation;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;

namespace MeuLivroDeReceitas.Aplication.UseCases.Profile.Registrar;
public class RegistrarProfileValidator: AbstractValidator<RequisicaoRegistrarProfile>
{
    public RegistrarProfileValidator()
    {
        RuleFor(c => c.usuarioId).NotEmpty().WithMessage(ResourceMensagensdeErro.Usuario_Não_Defenido);
    }
}
