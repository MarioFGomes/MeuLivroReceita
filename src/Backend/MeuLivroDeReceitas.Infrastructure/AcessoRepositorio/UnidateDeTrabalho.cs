using MeuLivroDeReceitas.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Infrastructure.AcessoRepositorio;

public sealed class UnidateDeTrabalho:IDisposable,IUnidadeDeTrabalho
{
    private readonly MeuLivroReceitaContext _contexto;
    private bool _disposed;

    public UnidateDeTrabalho(MeuLivroReceitaContext context)
    {
        _contexto=context; 
    }

    public async Task Commit()
    {
        await _contexto.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public void Dispose(bool dispose)
    {
        if (!_disposed && dispose)
        {
            _contexto.Dispose();
        }

        _disposed = true;
    }
}
