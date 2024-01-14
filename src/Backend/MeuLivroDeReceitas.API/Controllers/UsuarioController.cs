using MeuLivroDeReceitas.API.Filtros;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.AtualizarUser;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.BuscarPorId;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.BuscarUser;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.RecuperarSenha;
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

        [HttpPost]
        [Route("recuperar-Id")]
        [ProducesResponseType(typeof(RespostaUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarPorId([FromServices] IBuscarPorIdUseCase useCase, [FromQuery] Guid Id) {
            var resultado = await useCase.Execute(Id);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("recuperar-senha")]
        [ProducesResponseType(typeof(RespostaUser), StatusCodes.Status200OK)]
        public IActionResult RecuperarUser([FromServices] IBuscarUserUseCase useCase, [FromQuery] string query) {
           
            var resultado = useCase.Execute(query);

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

        [HttpPut]
        [Route("atualizar-usuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ServiceFilter(typeof(AuthenticatedUser))]
        public async Task<IActionResult> AtualizarUsuario([FromServices] IAtualizarUsuario useCase, [FromBody] RequisicaoAtualizarUsuario request, [FromQuery] Guid Id) {
           
            await useCase.Executar(request, Id);

            return NoContent();
        }

        [HttpPut]
        [Route("Deletar-usuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ServiceFilter(typeof(AuthenticatedUser))]
        public async Task<IActionResult> DeletarUsuario(Guid Id) 
        {
                

            return NoContent();
        }


        [HttpPost]
        [Route("recuperar-senha")]
        [ProducesResponseType(typeof(RespostaVarificationCode), StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarSenha([FromServices] IRecuperarSenhaUseCase useCase, [FromBody] RequisicaoRecuperarSenha requisicao) {
            
            var resultado = await useCase.Executar(requisicao);

            return Ok(resultado);
        }

    }
}