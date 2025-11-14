using DemoMVC.Core.Interfaces;
using DemoMVC.Core.ViewModel.Customers;

namespace DemoMVC.Infrastructure.Services;

public class CustomerDatabaseService : ICustomerData
{
    public Task<CustomerDetailsViewModel> GetCustomerDetails(string customerId)
    {
        throw new NotImplementedException();
    }
}
