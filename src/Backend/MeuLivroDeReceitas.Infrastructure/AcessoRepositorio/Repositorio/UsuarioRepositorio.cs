using MeuLivroDeReceitas.Domain.Entidade;
using MeuLivroDeReceitas.Domain.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Infrastructure.AcessoRepositorio.Repositorio;

public class UsuarioRepositorio : IUsuarioReadOnlyRepositorio, IUsuarioWriteOnlyRepositorio
{
    private readonly MeuLivroReceitaContext _contexto;

    public UsuarioRepositorio(MeuLivroReceitaContext context)
    {
        _contexto=context;
    }
    public async Task Adicionar(Usuario usuario)
    {
        await _contexto.usuarios.AddAsync(usuario);
    }

    public async Task<bool> ExistUsuarioEmail(string email)
    {
       return await _contexto.usuarios.AnyAsync(e=>e.Email==email);
    }

    public async Task<Usuario> Login(string email, string senha)
    {
        return await _contexto.usuarios.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Senha.Equals(senha));
    }
}
