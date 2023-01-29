using MeuLivroDeReceitas.Aplication.UseCases.Login.FazerLogin;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using Microsoft.AspNetCore.Mvc;

namespace MeuLivroDeReceitas.API.Controllers
{
    public class LoginController : MeuLivroDeReceitaController
    {
        [HttpPost]
        [ProducesResponseType(typeof(RespostaLoginJson),StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromServices] ILoginUseCase usecase, [FromBody] RequisicaoLoginJson requisicao)
        {
            var resposta = await usecase.Execute(requisicao);
            return Ok(resposta);
        }
    }
}
