using MeuLivroDeReceitas.API.Filtros;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

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

        [HttpPost]
        [Route("GetById")]
        [ProducesResponseType(typeof(RespostaUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarPorId([FromServices] IRecuperarSenhaUseCase useCase, [FromBody] RequesicaoRecuperarSenha requisicao) {
            var resultado = await useCase.Executar(requisicao.Email);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("recuperar-senha")]
        [ProducesResponseType(typeof(RespostaVarificationCode), StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarPorUserName([FromServices] IRecuperarSenhaUseCase useCase, [FromBody] RequesicaoRecuperarSenha requisicao) {
            var resultado = await useCase.Executar(requisicao.Email);

            return Ok(resultado);
        }

        [HttpPut]
        [Route("alterar-senha")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ServiceFilter(typeof(AuthenticatedUser))]
        public async Task<IActionResult> AlterarSenha([FromServices] IAlterarSenhaUseCase useCase, [FromBody] RequisicaoAlterarSenha request)
        {
           await useCase.Executar(request);

            return NoContent();
        }

        [HttpPost]
        [Route("recuperar-senha")]
        [ProducesResponseType(typeof(RespostaVarificationCode), StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarSenha([FromServices] IRecuperarSenhaUseCase useCase, [FromBody] RequesicaoRecuperarSenha requisicao) {
            var resultado = await useCase.Executar(requisicao.Email);

            return Ok(resultado);
        }

        

        [HttpPut]
        [Route("atualizar-usuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ServiceFilter(typeof(AuthenticatedUser))]
        public async Task<IActionResult> AtualizarUsuario([FromServices] IAlterarSenhaUseCase useCase, [FromBody] RequisicaoAlterarSenha request) {
            await useCase.Executar(request);

            return NoContent();
        }

        [HttpPut]
        [Route("Deletar-usuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ServiceFilter(typeof(AuthenticatedUser))]
        public async Task<IActionResult> DeletarUsuario([FromServices] IAlterarSenhaUseCase useCase, [FromBody] RequisicaoAlterarSenha request) {
            await useCase.Executar(request);

            return NoContent();
        }

    }
}