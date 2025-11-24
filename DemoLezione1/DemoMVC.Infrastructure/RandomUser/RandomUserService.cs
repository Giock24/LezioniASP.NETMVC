using DemoMVC.Infrastructure.RandomUser.Interfaces;
using DemoMVC.Infrastructure.RandomUser.Models;
using Microsoft.Identity.Client;
using Polly;
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

        var retryPolicy = Policy.Handle<HttpRequestException>()
            .RetryAsync(3);

        var httpClient = factory.CreateClient("RandomUser.Me");

        var response = await retryPolicy.ExecuteAsync(
            () => httpClient.GetAsync($"api?results={totalNumber}"));

        return await response.Content.ReadFromJsonAsync<RandomUserResponse>();


        //var responseMessage = await httpClient.GetAsync($"xxxxxapi?results={totalNumber}"
        //    , HttpCompletionOption.ResponseHeadersRead);

        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return await responseMessage.Content.ReadFromJsonAsync<RandomUserResponse>();
        //}
        //else {
        //    return null;
        //}



        //throw new NotImplementedException();
    }
}
