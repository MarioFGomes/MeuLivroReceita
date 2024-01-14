

using MeuLivroDeReceitas.Exceptions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Text.Json;
using Xunit;

namespace WebApi.Teste.V1;

public class ControllerBase:IClassFixture<MeuLivroReceitasWebApplicationFactory<Program>>
{
    private readonly HttpClient _cliente;

    public ControllerBase(MeuLivroReceitasWebApplicationFactory<Program> factory)
    {
        _cliente = factory.CreateClient();
        ResourceMensagensdeErro.Culture = CultureInfo.CurrentCulture;
    }

    protected async Task<HttpResponseMessage> PostRequest(string metodo, object body)
    {
        var jsonString = JsonConvert.SerializeObject(body);

        return await _cliente.PostAsync(metodo, new StringContent(jsonString,Encoding.UTF8,"application/json"));
    }

    protected async Task<HttpResponseMessage> PutRequest(string metodo, object body,string token="")
    {
        AutorizarRequisicao(token);

        var jsonString = JsonConvert.SerializeObject(body);

        return await _cliente.PutAsync(metodo, new StringContent(jsonString, Encoding.UTF8, "application/json"));
    }
    protected async Task<string> Login(string email ,string senha)
    {
        var requisicao = new MeuLivroDeReceitas.Comunicacao.Requisicoes.RequisicaoLoginJson
        {
            Email = email,
            Senha = senha
        };

        var resposta = await PostRequest("api/login", requisicao);

        await using var responseBody = await resposta.Content.ReadAsStreamAsync();

        var responsetaData = await JsonDocument.ParseAsync(responseBody);

        return responsetaData.RootElement.GetProperty("token").GetString();
    }

    private void AutorizarRequisicao(string token)
    {
        if(!string.IsNullOrEmpty(token))
        {
            _cliente.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }

}
