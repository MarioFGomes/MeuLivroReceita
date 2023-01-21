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
        await _contexto.Usuarios.AddAsync(usuario);
    }

    public async Task<bool> ExistUsuarioEmail(string email)
    {
       return await _contexto.Usuarios.AnyAsync(e=>e.Email==email);
    }
}
