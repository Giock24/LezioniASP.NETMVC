using DemoMVC.Core.Interfaces;
using DemoMVC.Core.ViewModel.Customers;

namespace DemoMVC.Infrastructure.Services;

public class CustomerMockService : ICustomerData
{
    public async Task<CustomerDetailsViewModel> GetCustomerDetails(string customerId)
    {
        await Task.Delay(100); // Simulate async data fetching

        return new CustomerDetailsViewModel
        {
            CustomerId = customerId,
            CompanyName = "Contoso Ltd.",
            Address = "123 MainSt",
            City = "Metropolis",
            Country = "Fictionland",
            Phone = "123-456-7890",
            Orders = new List<OrderDetailsViewModel>
            {
                new OrderDetailsViewModel
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now.AddDays(-10),
                    TotalAmount = 250.00m
                },
                new OrderDetailsViewModel
                {
                    OrderId = 2,
                    OrderDate = DateTime.Now.AddDays(-5),
                    TotalAmount = 450.00m
                },
                new OrderDetailsViewModel
                {
                    OrderId = 3,
                    OrderDate = DateTime.Now.AddDays(-2),
                    TotalAmount = 150.00m
                }
            }
        };
    }
}