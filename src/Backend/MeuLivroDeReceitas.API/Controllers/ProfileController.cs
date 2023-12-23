using MeuLivroDeReceitas.Aplication.UseCases.Profile.Registrar;
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarProfile(Guid Id)
    {
        //var resultado = await useCase.Executar(request);

        return Ok();
    }
}
