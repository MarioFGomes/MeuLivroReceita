using AutoMapper;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.Servicos.Automapper
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<RequisicoesRegistarUsuarioJson, Usuario>()
            .ForMember(destino=>destino.Senha,config=>config.Ignore());
        }
    }
}
