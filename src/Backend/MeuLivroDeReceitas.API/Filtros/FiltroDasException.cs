using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MeuLivroDeReceitas.API.Filtros;

public class FiltroDasException : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is MeuLivroDeReceitasException)
        {
            TratarMeuLivroDeReceitaException(context);

        }
        else
        {
            LancarErroDesconhecido(context);
        }
    }

    private void TratarMeuLivroDeReceitaException(ExceptionContext context)
    {
        if(context.Exception is ErrosDeValidacaoException)
        {
            TratarErrosDeValidacaoException(context);
        }
        else if (context.Exception is LoginInvalidoException)
        {
            TratarLoginException(context);
        }

    }

    private static void TratarErrosDeValidacaoException(ExceptionContext context)
    {
        var erroDeValidacao=context.Exception as ErrosDeValidacaoException;

        context.HttpContext.Response.StatusCode=(int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new RespostaErroJson(erroDeValidacao.MessagesErros));
    }

    private static void LancarErroDesconhecido(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new RespostaErroJson(ResourceMensagensdeErro.Erro_Desconhecido));
    }

    private static void TratarLoginException(ExceptionContext context)
    {
        var erroLogin = context.Exception as LoginInvalidoException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        context.Result = new ObjectResult(new RespostaErroJson(erroLogin.Message));
    }
}
