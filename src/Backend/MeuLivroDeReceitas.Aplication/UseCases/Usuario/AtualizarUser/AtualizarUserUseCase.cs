using AutoMapper;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Domain.Repositorios;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using MeuLivroDeReceitas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Base;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.AtualizarUser;
public class AtualizarUserUseCase : IAtualizarUsuario {
    private readonly IUsuarioWriteOnlyRepositorio _usuarioWriteOnlyRepositorio;
    private readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _UnidadeDeTrabalho;

    public AtualizarUserUseCase(IUsuarioWriteOnlyRepositorio usuarioWriteOnly, IUsuarioReadOnlyRepositorio usuarioReadOnly, IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _usuarioWriteOnlyRepositorio= usuarioWriteOnly;
        _usuarioReadOnlyRepositorio=usuarioReadOnly;
        _mapper=mapper;
        _UnidadeDeTrabalho=unidadeDeTrabalho;
    }
    public async Task Executar(RequisicaoAtualizarUsuario requisicao,Guid Id) 
    {
        await Validar(requisicao,Id);

        var user = await _usuarioReadOnlyRepositorio.RecuperarPorId(Id);

        user=_mapper.Map(requisicao, user);

        _usuarioWriteOnlyRepositorio.Update(user);

       await  _UnidadeDeTrabalho.Commit();
        
    }

    private async Task Validar(RequisicaoAtualizarUsuario Userjson, Guid Id) {

        var validar = new AtualizarUsuarioValidator();

        var result = validar.Validate(Userjson);

        var user = await _usuarioReadOnlyRepositorio.RecuperarPorEmail(Userjson.Email);

        if (user.Id != Id)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceMensagensdeErro.Email_Já_Registrado));
        }

        if (!result.IsValid) 
        {

            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrosDeValidacaoException(messageError);
        }
    }
}
