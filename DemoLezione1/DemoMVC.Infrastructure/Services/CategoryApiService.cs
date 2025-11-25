using DemoMVC.Core.DTO;
using DemoMVC.Core.Interfaces;
using System.Net.Http.Json;

namespace DemoMVC.Infrastructure.Services;

public class CategoryApiService : ICategoriesApiData
{
    private readonly IHttpClientFactory factory;

    public CategoryApiService(IHttpClientFactory factory)
    {
        this.factory = factory;
    }

    public async Task<IEnumerable<CategoriaDTO>?> GetAll()
    {
        var httpClient = factory.CreateClient("CategoriesApi");

        var responseMessage = await httpClient.GetAsync($"categories", HttpCompletionOption.ResponseHeadersRead);

        if (responseMessage.IsSuccessStatusCode)
        {
            return await responseMessage.Content.ReadFromJsonAsync<List<CategoriaDTO>>();
        }
        else
        {
            return null;
        }
    }
}
