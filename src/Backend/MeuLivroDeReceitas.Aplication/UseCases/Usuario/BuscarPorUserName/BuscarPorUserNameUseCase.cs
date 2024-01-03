using AutoMapper;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.BuscarPorUserName;
public class BuscarPorUserNameUseCase : IBuscarPorUserNameUseCase 
{
    public readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
    private readonly IMapper _mapper;
    public BuscarPorUserNameUseCase(IMapper mapper, IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio)
    {
        _mapper = mapper;
        _usuarioReadOnlyRepositorio=usuarioReadOnlyRepositorio;
    }

    public List<RespostaUser> Execute(string username) {
       var Listauser= _usuarioReadOnlyRepositorio.RecuperarPorUserName(username);
       var user=_mapper.Map<List<RespostaUser>>(Listauser);

        return user;
    }
}
