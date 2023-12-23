using MeuLivroDeReceitas.Domain.Entidade;
using MeuLivroDeReceitas.Domain.Repositorios.Profile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Infrastructure.AcessoRepositorio.Repositorio;
public class ProfileRepositorio : IProfileReadOnlyRepositorio, IProfileWriteOnlyRepositorio
{
    private readonly MeuLivroReceitaContext _contexto;

    public ProfileRepositorio(MeuLivroReceitaContext context)
    {
        _contexto = context;
    }
    public async Task Adicionar(UserProfile profile)
    {
        await _contexto.Profiles.AddAsync(profile);
    }

    public async Task<UserProfile> RecuperarPorId(Guid Id)
    {
       return await _contexto.Profiles.Include(p =>p.usuario).SingleOrDefaultAsync(p => p.Id == Id);
    }

    public void Update(UserProfile profile)
    {
       _contexto.Update(profile);
    }
}
