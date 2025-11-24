using DemoMVC.Infrastructure.RandomUser.Models;

namespace DemoMVC.Infrastructure.RandomUser.Interfaces;

public interface IRandomUserData
{
    Task<RandomUserResponse?> GetRandomUserData(int totalNumber);
}
