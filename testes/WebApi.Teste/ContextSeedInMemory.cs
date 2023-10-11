using MeuLivroDeReceitas.Infrastructure.AcessoRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitarioParaOsTestes.Entidades;

namespace WebApi.Teste;

public class ContextSeedInMemory
{
    public static (MeuLivroDeReceitas.Domain.Entidade.Usuario usuario, string senha) Seed(MeuLivroReceitaContext context)
    {
        (var usuario, var senha) = UsuarioBuilder.Contruir();
        context.usuarios.Add(usuario);
        context.SaveChanges();
        return (usuario, senha);
    }
}
