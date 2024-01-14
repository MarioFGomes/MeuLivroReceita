using AutoMapper;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios;
using MeuLivroDeReceitas.Domain.Repositorios.Profile;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Profile.Registrar;
public class RegistrarProfileUseCase : IRegistrarProfileUseCase
{
    private readonly IUnidadeDeTrabalho _UnidadeDeTrabalho;
    private readonly IProfileWriteOnlyRepositorio _profileWriteOnly;
    private readonly IMapper _mapper;
    public RegistrarProfileUseCase(IUnidadeDeTrabalho UnidadeDeTrabalho, IProfileWriteOnlyRepositorio profileWriteOnly, IMapper mapper)
    {
        _UnidadeDeTrabalho= UnidadeDeTrabalho;
        _profileWriteOnly= profileWriteOnly;
        _mapper = mapper;
    }
    public async Task<RespostaProfileRegistrado> Executar(RequisicaoRegistrarProfile requisicao)
    {
        await Validar(requisicao);
        var entidade = _mapper.Map<MeuLivroDeReceitas.Domain.Entidade.UserProfile>(requisicao);
        await _profileWriteOnly.Adicionar(entidade);
        await _UnidadeDeTrabalho.Commit();

        return new RespostaProfileRegistrado
        {
            Id = entidade.Id
        };
    }

    private  async Task Validar(RequisicaoRegistrarProfile profile)
    {
        var validar = new RegistrarProfileValidator();

        var result = validar.Validate(profile);

        if (!result.IsValid)
        {

            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrosDeValidacaoException(messageError);
        }
     
    }
}
