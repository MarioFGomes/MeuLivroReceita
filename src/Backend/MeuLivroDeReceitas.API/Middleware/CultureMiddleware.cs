﻿using System.Globalization;

namespace MeuLivroDeReceitas.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    private IList<string> _idiomasSuportados=new List<string>
    {
        "pt",
        "en"
    };
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var cultura = new CultureInfo("pt");

        if (context.Request.Headers.ContainsKey("Accept-Language"))
        {
            var linguagem = context.Request.Headers["Accept-Language"].ToString();

            if (_idiomasSuportados.Any(l => l.Equals(linguagem)))
            {
                cultura = new CultureInfo(linguagem);
            }
            
            
        }
        CultureInfo.CurrentCulture = cultura;
        CultureInfo.CurrentUICulture = cultura;

        await _next(context);
    }
}
