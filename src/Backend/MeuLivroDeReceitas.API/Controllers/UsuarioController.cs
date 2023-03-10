using MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using Microsoft.AspNetCore.Mvc;

namespace MeuLivroDeReceitas.API.Controllers
{

    public class UsuarioController : MeuLivroDeReceitaController
    {

        [HttpPost]
        [ProducesResponseType(typeof(RespostaUsuarioRegistradoJson),StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarUsuario([FromServices] IRegistrarUsuarioUseCase useCase, [FromBody] RequisicoesRegistarUsuarioJson request)
        {
            var resultado = await useCase.Executar(request);

            return Created(string.Empty, resultado);
        }

       
    }
}