using Bogus;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;


namespace UtilitarioParaOsTestes.Requisicoes;

public class RequisicaoAlterarSenhaUsuarioBuilder
{
    public static RequisicaoAlterarSenha Construir(int tamanhosenha=10)
    {

        return new Faker<RequisicaoAlterarSenha>()
            .RuleFor(c => c.SenhaAntiga, f => f.Internet.Password(10))
            .RuleFor(c => c.NovaSenha, f => f.Internet.Password(tamanhosenha));
    }
}
