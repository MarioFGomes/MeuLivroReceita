

using MeuLivroDeReceitas.Exceptions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
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

}
