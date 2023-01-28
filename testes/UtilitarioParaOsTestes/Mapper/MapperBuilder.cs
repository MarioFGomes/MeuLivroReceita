

using AutoMapper;
using MeuLivroDeReceitas.Aplication.Servicos.Automapper;

namespace UtilitarioParaOsTestes.Mapper;

public class MapperBuilder
{
    public static IMapper Instancia()
    {
        var configuracao = new MapperConfiguration(config =>
        {
            config.AddProfile<AutoMapperConfiguration>();
        });
        return configuracao.CreateMapper();
    }
}
