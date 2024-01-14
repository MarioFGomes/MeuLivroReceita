using MeuLivroDeReceitas.Aplication.Servicos.utilities;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;


namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha;

public class RecuperarSenhaUseCase : IRecuperarSenhaUseCase
{
    private readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
    public RecuperarSenhaUseCase(IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio)
    {
        _usuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
    }
    public async Task<RespostaVarificationCode> Executar(RequisicaoRecuperarSenha requesicao)
    {
        Validar(requesicao);

        //var result=await _usuarioReadOnlyRepositorio.RecuperarPorEmail(email);

        //if (result is null) throw new Exception("usuario não existe");

        return new RespostaVarificationCode {

            Codigo = VerificationCodeGenerete.Generate()

        };


    }

    private void Validar(RequisicaoRecuperarSenha requisicao) {

        var validar = new RecuperarSenhaValidator();

        var result = validar.Validate(requisicao);

        if (!result.IsValid) {

            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrosDeValidacaoException(messageError);
        }
    }
}
