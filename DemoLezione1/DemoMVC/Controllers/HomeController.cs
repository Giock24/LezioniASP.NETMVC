using DemoMVC.Core.Interfaces;
using DemoMVC.Core.ViewModel;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboard dashboard;

        public HomeController(ILogger<HomeController> logger, IDashboard dashboard)
        {
            _logger = logger;
            this.dashboard = dashboard;
        }

        public IActionResult Index()
        {
            return View(dashboard.DashboardIndexViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
