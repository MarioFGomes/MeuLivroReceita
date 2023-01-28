

using Bogus;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;

namespace UtilitarioParaOsTestes.Requisicoes;

public class RequisicaoRegistrarUsuarioBuilder
{
    public static RequisicoesRegistarUsuarioJson Contruir(int tamnhosenha=10)
    {
        // usando a biblioteca Bogus para gerar um objeto dinamico para a requisicao nos testes
        return new Faker<RequisicoesRegistarUsuarioJson>()
            .RuleFor(c => c.Nome, f => f.Person.FirstName)
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Senha, f => f.Internet.Password(tamnhosenha))
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("+### ###-###-###"));

    }
}
