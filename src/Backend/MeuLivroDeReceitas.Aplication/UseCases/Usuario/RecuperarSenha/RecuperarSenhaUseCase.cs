using MeuLivroDeReceitas.Aplication.Servicos.utilities;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using MeuLivroDeReceitas.Domain.Repositorios.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha;

public class RecuperarSenhaUseCase : IRecuperarSenhaUseCase
{
    private readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
    public RecuperarSenhaUseCase(IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio)
    {
        _usuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
    }
    public async Task<RespostaVarificationCode> Executar(string email)
    {
        var result=await _usuarioReadOnlyRepositorio.RecuperarPorEmail(email);
        if (result is null) throw new Exception("usuario não existe");

        return new RespostaVarificationCode
        {

            Codigo = VerificationCodeGenerete.Generate()

        };
               
 
    }
}
