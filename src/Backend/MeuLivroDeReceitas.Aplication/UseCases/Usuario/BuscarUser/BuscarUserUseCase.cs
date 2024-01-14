using AutoMapper;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.BuscarUser;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.BuscarUser;
public class BuscarUserUseCase : IBuscarUserUseCase 
{
    public readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
    private readonly IMapper _mapper;
    public BuscarUserUseCase(IMapper mapper, IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio)
    {
        _mapper = mapper;
        _usuarioReadOnlyRepositorio=usuarioReadOnlyRepositorio;
    }

    public async Task<List<RespostaUser>> Execute(string username) {
       var Listauser= await _usuarioReadOnlyRepositorio.RecuperarUser(username);
       var user=_mapper.Map<List<RespostaUser>>(Listauser);

        return user;
    }
}
