using MeuLivroDeReceitas.API.Filtros;
using MeuLivroDeReceitas.Aplication.UseCases.Usuario.AlterarSenha;
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
        [Route("[action]")]
        public IActionResult SendEmail([FromBody] string[] to, string subject, string sms)
        {
            //email qualquer
            String userName = "";

            //passwword do email
            String password = "";

            MailMessage msg = new MailMessage();

            //dentro de aspas, o email novamente
            msg.From = new MailAddress("");
            msg.Subject = subject;
            msg.Body = sms;
            for (int i = 0; i < to.Length; i++)
            {
                msg.To.Add(new MailAddress(to[i]));
            }
            SmtpClient SmtpClient = new SmtpClient();
            SmtpClient.Credentials = new System.Net.NetworkCredential(userName, password);
            SmtpClient.Host = "smtp.office365.com";
            SmtpClient.Port = 587;
            SmtpClient.EnableSsl = true;
            SmtpClient.Send(msg);
            return Ok();
        }


    }
}