using DemoMVC.Core.Interfaces;
using DemoMVC.Core.ViewModel.Customers;
using DemoMVC.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Infrastructure.Services;

public class CustomerDatabaseService : ICustomerData
{
    private readonly NorthwindContext northwindContext;

    public CustomerDatabaseService(NorthwindContext northwindContext)
    {
        this.northwindContext = northwindContext;
    }

    public async Task<CustomerDetailsViewModel?> GetCustomerDetails(string customerId)
    {
        //CACTU
        var customer=await northwindContext.Customers.Include(c=>c.Orders)
            .ThenInclude(o=> o.OrderDetails)
            .ThenInclude(od=> od.Product)
            .FirstOrDefaultAsync(c=> c.CustomerId==customerId);

        //var x = customer.Orders.ToList();

        //var prodotti = new List<String>();
        //foreach (var order in customer!.Orders) {
        //    foreach (var orderDetail in order.OrderDetails) {
        //        prodotti.Add(orderDetail.Product.ProductName);
        //    }
        //}
        var result = customer!.Orders
            .SelectMany(o => o.OrderDetails)
            .GroupBy(od => od.Product.ProductName)
            .OrderByDescending(g => g.Count())
            .Select(g => new { Nome = g.Key, Conteggio = g.Count() })
            .FirstOrDefault();

        return customer != null ? new CustomerDetailsViewModel { CustomerId = customer.CustomerId, CompanyName = customer.CompanyName,
            City = customer.City, Country = customer.Country, Address = customer.Address, Phone = customer.Phone
            ,GrandTotal=customer.Orders.Sum(o=> o.OrderDetails.Sum(od=> od.Quantity * od.UnitPrice))
            ,FavouriteProduct= result!.Nome
            ,Orders=customer.Orders.Select(o=> new OrderDetailsViewModel { OrderId=o.OrderId,OrderDate=o.OrderDate
            ,TotalAmount=o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice)
            }).ToList() } 
            : null;
    }
}
