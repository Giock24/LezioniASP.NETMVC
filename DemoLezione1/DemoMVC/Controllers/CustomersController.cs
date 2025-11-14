using DemoMVC.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoMVC.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomerData customerData;

    public CustomersController(ICustomerData customerData)
    {
        this.customerData = customerData;
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var customerDetailsViewModel = await customerData.GetCustomerDetails(id);
        return View(customerDetailsViewModel);
    }
}
