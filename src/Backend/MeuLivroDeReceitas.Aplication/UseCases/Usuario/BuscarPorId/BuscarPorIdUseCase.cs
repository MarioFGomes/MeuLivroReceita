using AutoMapper;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.BuscarPorId;
internal class BuscarPorIdUseCase : IBuscarPorIdUseCase {

    private readonly IMapper _mapper;
    private readonly IUsuarioReadOnlyRepositorio _UsuarioReadOnlyRepositorio;
    public BuscarPorIdUseCase(IMapper mapper, IUsuarioReadOnlyRepositorio UsuarioReadOnlyRepositorio)
    {
        _mapper = mapper;
        _UsuarioReadOnlyRepositorio = UsuarioReadOnlyRepositorio;
    }
    public Task<RespostaUser> Execute(Guid Id) 
    {
       var UserFind=_UsuarioReadOnlyRepositorio.RecuperarPorId(Id);

       var user=_mapper.Map<RespostaUser>(UserFind);

        return Task.FromResult(user);

    }

}
