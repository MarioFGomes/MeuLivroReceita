using MeuLivroDeReceitas.API.Filtros;
using MeuLivroDeReceitas.Aplication.UseCases.Profile.AtualizarPerfil;
using MeuLivroDeReceitas.Aplication.UseCases.Profile.RecuperarPerfil;
using MeuLivroDeReceitas.Aplication.UseCases.Profile.Registrar;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.Registrar;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Comunicacao.Respostas;
using Microsoft.AspNetCore.Mvc;

namespace MeuLivroDeReceitas.API.Controllers;

public class ProfileController: MeuLivroDeReceitaController
{
    [HttpPost]
    [ProducesResponseType(typeof(RespostaProfileRegistrado), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarProfile([FromServices] IRegistrarProfileUseCase useCase, [FromBody] RequisicaoRegistrarProfile request)
    {
        var resultado = await useCase.Executar(request);

        return CreatedAtAction(nameof(RecuperarProfile), new { Id=resultado.Id });
    }

    [HttpGet]
    [Route("GetById")]
    [ProducesResponseType(typeof(RespostaProfile),StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarProfile([FromServices] IRecuperarPerfilUseCase usecase,[FromQuery] Guid Id)
    {
        var resultado = await usecase.Executar(Id);

        return Ok(resultado);
    }

    [HttpPut]
    [Route("atualizar-profile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AtualizarProfile([FromServices] IAtualizarPerfilUseCase usecase ,Guid Id) {

        //var resultado = await useCase.Executar(request);

        return Ok();
    }

    [HttpPut]
    [Route("alterar-foto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AdicionarFotoProfile(Guid Id)
    {
        //var resultado = await useCase.Executar(request);

        return Ok();
    }


    [HttpPut]
    [Route("deletar-profile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletarProfile(Guid Id) {
        //var resultado = await useCase.Executar(request);

        return Ok();
    }
}
