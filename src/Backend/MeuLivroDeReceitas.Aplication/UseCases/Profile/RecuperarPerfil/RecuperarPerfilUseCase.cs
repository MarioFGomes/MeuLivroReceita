using AutoMapper;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Profile.RecuperarPerfil;
public class RecuperarPerfilUseCase : IRecuperarPerfilUseCase 
{
    private readonly IProfileReadOnlyRepositorio _profileReadOnly;
    private readonly IMapper _mapper;
    public RecuperarPerfilUseCase(IProfileReadOnlyRepositorio profileReadOnly, IMapper mapper)
    {
        _profileReadOnly = profileReadOnly;
        _mapper = mapper;
    }
    public async Task<RespostaProfile> Executar(Guid Id) {
        var profile = await _profileReadOnly.RecuperarPorId(Id);
        var ResponseProfile=_mapper.Map<RespostaProfile>(profile);
        return ResponseProfile;
    }
}
