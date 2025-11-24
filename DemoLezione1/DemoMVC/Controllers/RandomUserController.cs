using DemoMVC.Infrastructure.RandomUser.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class RandomUserController : Controller
    {
        private readonly IRandomUserData randomUserData;

        public RandomUserController(IRandomUserData randomUserData)
        {
            this.randomUserData = randomUserData;
        }

        public async Task<IActionResult> Index()
        {
            var data = await randomUserData.GetRandomUserData(10);
            return View(data);
        }
    }
}
