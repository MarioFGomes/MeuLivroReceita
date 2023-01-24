using AutoMapper;
using MeuLivroDeReceitas.Aplication.Servicos.Criptografia;
using MeuLivroDeReceitas.Aplication.Servicos.Token;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;

public class RegistrarUsuarioUseCase: IRegistrarUsuarioUseCase
{
    private readonly IUsuarioWriteOnlyRepositorio _repositorio;
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _UnidadeDeTrabalho;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly TokenController _tokenController;
    private readonly IUsuarioReadOnlyRepositorio _UsuarioReadOnlyRepositorio;

    public RegistrarUsuarioUseCase(IUsuarioWriteOnlyRepositorio repositorio, IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController, IUsuarioReadOnlyRepositorio IUsuarioReadOnlyRepositorio)
    {
        _repositorio = repositorio;
        _mapper = mapper;
        _UnidadeDeTrabalho = unidadeDeTrabalho;
        _encriptadorDeSenha= encriptadorDeSenha;
        _tokenController = tokenController;
        _UsuarioReadOnlyRepositorio = IUsuarioReadOnlyRepositorio;
    }

    public async Task<RespostaUsuarioRegistradoJson> Executar(RequisicoesRegistarUsuarioJson requisicao)
    {
        await Validar(requisicao);

        var entidade = _mapper.Map<MeuLivroDeReceitas.Domain.Entidade.Usuario>(requisicao);

        entidade.Senha = _encriptadorDeSenha.Criptografar(requisicao.Senha);

        await _repositorio.Adicionar(entidade);

       await _UnidadeDeTrabalho.Commit();

        var token = _tokenController.GerarToken(entidade.Email);

        return new RespostaUsuarioRegistradoJson
        {
            Token = token
        };
    }

    private async Task Validar(RequisicoesRegistarUsuarioJson Userjson)
    {
        var validar = new RegistrarUsuarioValidator();
        var result=validar.Validate(Userjson);

        var existeUsuarioComEmail = await _UsuarioReadOnlyRepositorio.ExistUsuarioEmail(Userjson.Email);
        if (existeUsuarioComEmail)
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
