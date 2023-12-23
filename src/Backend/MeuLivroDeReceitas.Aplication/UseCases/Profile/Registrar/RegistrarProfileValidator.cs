using FluentValidation;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;


namespace MeuLivroDeReceitas.Aplication.UseCases.Profile.Registrar;
public class RegistrarProfileValidator: AbstractValidator<RequisicaoRegistrarProfile>
{
    public RegistrarProfileValidator()
    {
        
    }
}
