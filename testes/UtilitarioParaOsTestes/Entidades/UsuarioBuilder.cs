using Bogus;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitarioParaOsTestes.Criptografia;

namespace UtilitarioParaOsTestes.Entidades;

public class UsuarioBuilder
{
    public static (Usuario usuario, string senha) Contruir()
    {
        string senha =string.Empty;
        // usando a biblioteca Bogus para gerar um objeto dinamico para a requisicao nos testes
        var UsuarioGerado= new Faker<Usuario>()
            .RuleFor(c => c.Id, f => f.Random.Guid())
            .RuleFor(c => c.Nome, f => f.Person.FirstName)
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Senha, f =>
            {
                senha = f.Internet.Password();

                return EncriptadorDeSenhaBuilder.Instancia().Criptografar(senha);
            })
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("+### ###-###-###"));

        return (UsuarioGerado, senha);
    }
}
