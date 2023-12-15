using Application.Customers.GetById;
using Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Application;


public class ClientProxy: IClientProx
{
    private readonly ApiUrl _apiUrls;
    private HttpClient _httpClient;
    public ClientProxy(
        IOptions<ApiUrl> apiUrls
,           HttpClient httpClient
        )
    {
        _apiUrls = apiUrls.Value;
        _httpClient = httpClient;
    }
    public async Task<string> createClientAsync(GetAccountByIdQuery commnad)
    {

        var content = new StringContent(
            JsonSerializer.Serialize(commnad),
            Encoding.UTF8,
            "application/json"
            );
        var url = _apiUrls.Url + "clientes/" +  commnad.id;
        var request = await _httpClient.GetAsync(url);
        request.EnsureSuccessStatusCode();
        return await request.Content.ReadAsStringAsync();

    }
}
