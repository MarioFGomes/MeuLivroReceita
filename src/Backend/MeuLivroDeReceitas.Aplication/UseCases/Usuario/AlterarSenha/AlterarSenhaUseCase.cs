using MeuLivroDeReceitas.Aplication.Servicos.Criptografia;
using MeuLivroDeReceitas.Aplication.Servicos.UserLogado;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Domain.Repositorios;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;


namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;

public class AlterarSenhaUseCase : IAlterarSenhaUseCase
{
    private readonly IUsuarioWriteOnlyRepositorio _repositorio;
    private readonly IUsuarioLogado _usuarioLogado;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly IUnidadeDeTrabalho _UnidadeDeTrabalho;
    public AlterarSenhaUseCase(IUsuarioWriteOnlyRepositorio repositorio, IUsuarioLogado usuarioLogado, EncriptadorDeSenha encriptador, IUnidadeDeTrabalho UnidadeDeTrabalho)
    {
        _repositorio = repositorio;
        _usuarioLogado = usuarioLogado;
        _encriptadorDeSenha = encriptador;
        _UnidadeDeTrabalho = UnidadeDeTrabalho;
    }
    public async Task Executar(RequisicaoAlterarSenha requisicao)
    {
        var usuario = await _usuarioLogado.RecuperarUsuario();
        Validar(requisicao, usuario);
        usuario.Senha = _encriptadorDeSenha.Criptografar(requisicao.NovaSenha);
        _repositorio.Update(usuario);
        await _UnidadeDeTrabalho.Commit();
    }

    public void Validar(RequisicaoAlterarSenha requisicao, MeuLivroDeReceitas.Domain.Entidade.Usuario usuario)
    {
        var validator = new AlterarSenhaValidator();
        var resultado = validator.Validate(requisicao);

        var SenhaAntigaCriptografada = _encriptadorDeSenha.Criptografar(requisicao.SenhaAntiga);
        if (!usuario.Senha.Equals(SenhaAntigaCriptografada))
        {
            resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("SenhaAntiga",ResourceMensagensdeErro.SenhaAtual_Invalida));
        }

        if (!resultado.IsValid)
        {
            var messageError = resultado.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrosDeValidacaoException(messageError);
        }
    }
}
