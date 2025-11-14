using System.ComponentModel;

namespace DemoMVC.Core.ViewModel.Customers;

public class CustomerDetailsViewModel
{
    public required string CustomerId { get; set; }
    [DisplayName("Company Name")]
    public string? CompanyName { get; set; }

    public required string Address { get; set; }

    public required string City { get; set; }

    public required string Country { get; set; }

    public string? Phone { get; set; }

    public decimal GrandTotal   { get; set; }

    public required string FavouriteProduct { get; set; }
    public List<OrderDetailsViewModel> Orders { get; set; } = new();
}
