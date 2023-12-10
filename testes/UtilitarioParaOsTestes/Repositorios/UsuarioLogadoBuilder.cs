using MeuLivroDeReceitas.Aplication.Servicos.UserLogado;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitarioParaOsTestes.Repositorios;

public class UsuarioLogadoBuilder
{
    private static UsuarioLogadoBuilder _instancia;
    private readonly Mock<IUsuarioLogado> _repositorio;

    private UsuarioLogadoBuilder()
    {
        if (_repositorio == null)
        {
            _repositorio = new Mock<IUsuarioLogado>();
        }
    }
    public static UsuarioLogadoBuilder Instancia()
    {
        _instancia = new UsuarioLogadoBuilder();

        return _instancia;
    }

    public UsuarioLogadoBuilder RecuperarUsuario(MeuLivroDeReceitas.Domain.Entidade.Usuario usuario)
    {
        _repositorio.Setup(c => c.RecuperarUsuario()).ReturnsAsync(usuario);
        return this;
    }

    public IUsuarioLogado Construir()
    {
        return _repositorio.Object;
    }
}

