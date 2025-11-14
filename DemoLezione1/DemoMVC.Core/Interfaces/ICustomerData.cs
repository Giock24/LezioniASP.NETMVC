using DemoMVC.Core.ViewModel.Customers;

namespace DemoMVC.Core.Interfaces;

public interface ICustomerData
{
    public Task<CustomerDetailsViewModel?> GetCustomerDetails(string customerId);
}
