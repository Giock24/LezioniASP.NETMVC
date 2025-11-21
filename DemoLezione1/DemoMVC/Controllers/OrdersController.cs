using DemoMVC.Core.Interfaces;
using DemoMVC.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Controllers;

public class OrdersController : Controller
{
    private readonly IOrderData orders;

    public OrdersController(IOrderData orders)
    {
        this.orders = orders;
    }

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 50)
    {
        var x = await orders.GetOrdersVM(pageNumber, pageSize);

        return View(x);
    }
}
