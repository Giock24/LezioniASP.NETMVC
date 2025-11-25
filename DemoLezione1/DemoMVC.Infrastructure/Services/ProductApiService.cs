using DemoMVC.Core.DTO;
using DemoMVC.Core.Interfaces;
using System.Net.Http.Json;

namespace DemoMVC.Infrastructure.Services;

public class ProductApiService : IProductsApiData
{
    private readonly IHttpClientFactory factory;

    public ProductApiService(IHttpClientFactory factory)
    {
        this.factory = factory;
    }

    public async Task Create(ProdottoCreaDTO prodottoCreaDTO)
    {
        var httpClient = factory.CreateClient("ProductsApi");

        var responseMessage = await httpClient.PostAsJsonAsync($"products", prodottoCreaDTO);
    }

    public async Task Delete(int id)
    {
        var httpClient = factory.CreateClient("ProductsApi");

        var responseMessage = await httpClient.DeleteAsync($"products/{id}");
    }

    public async Task<IEnumerable<ProdottoDTO>?> GetAll()
    {
        var httpClient = factory.CreateClient("ProductsApi");

        var responseMessage = await httpClient.GetAsync($"products", HttpCompletionOption.ResponseHeadersRead);

        if (responseMessage.IsSuccessStatusCode)
        {
            return await responseMessage.Content.ReadFromJsonAsync<List<ProdottoDTO>>();
        }
        else
        {
            return null;
        }
    }

    public async Task<ProdottoDTO?> GetById(int id)
    {
        var httpClient = factory.CreateClient("ProductsApi");

        var responseMessage = await httpClient.GetAsync($"products/{id}", HttpCompletionOption.ResponseHeadersRead);

        if (responseMessage.IsSuccessStatusCode)
        {
            return await responseMessage.Content.ReadFromJsonAsync<ProdottoDTO>();
        }
        else
        {
            return null;
        }
    }

    public async Task Update(ProdottoModificaDTO prodottoModificaDTO)
    {
        var httpClient = factory.CreateClient("ProductsApi");

        var responseMessage = await httpClient.PutAsJsonAsync($"products/{prodottoModificaDTO.Id}", prodottoModificaDTO);
    }
}
