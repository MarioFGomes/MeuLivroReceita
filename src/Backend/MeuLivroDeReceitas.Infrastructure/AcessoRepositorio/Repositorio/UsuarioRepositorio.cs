using MeuLivroDeReceitas.Domain.Entidade;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
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
            .SingleOrDefaultAsync(c => c.Email.Equals(email) && c.Senha.Equals(senha));
    }

    public async Task<Usuario> RecuperarPorEmail(string email)
    {
        return await _contexto.usuarios
            .SingleOrDefaultAsync(c => c.Email.Equals(email));
    }

    public async Task<Usuario> RecuperarPorId(Guid Id)
    {
        return await _contexto.usuarios.Include(e => e.Imagens).Include(e => e.Seguidores).Include(e => e.Seguindo)
            .SingleOrDefaultAsync(c => c.Id.Equals(Id));
    }

    public async Task<Usuario> RecuperarPorUserName(string username)
    {
        return await _contexto.usuarios
            .SingleOrDefaultAsync(c => c.Nome.Equals(username));
    }

    public void Update(Usuario usuario)
    {
        _contexto.usuarios.Update(usuario);
    }
}
