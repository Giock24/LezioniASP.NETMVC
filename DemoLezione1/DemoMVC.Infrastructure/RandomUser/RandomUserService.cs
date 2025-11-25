using DemoMVC.Infrastructure.RandomUser.Interfaces;
using DemoMVC.Infrastructure.RandomUser.Models;
using Microsoft.Identity.Client;
using Polly;
using System.Net.Http;
using System.Net.Http.Json;

namespace DemoMVC.Infrastructure.RandomUser;

public class RandomUserService : IRandomUserData
{
    private readonly IHttpClientFactory factory;

    public RandomUserService(IHttpClientFactory  factory)
    {
        this.factory = factory;
    }

    public async Task<RandomUserResponse?> GetRandomUserData(int totalNumber)
    {
        var httpClient = factory.CreateClient("RandomUser.Me");

        var responseMessage = await httpClient.GetAsync($"api?results={totalNumber}", HttpCompletionOption.ResponseHeadersRead);

        if (responseMessage.IsSuccessStatusCode)
        {
            return await responseMessage.Content.ReadFromJsonAsync<RandomUserResponse>();
        }
        else
        {
            return null;
        }
    }
}
