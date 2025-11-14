using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMVC.Core.ViewModel.Customers;

public class OrderDetailsViewModel
{
    public int OrderId { get; set; }
    public DateTime? OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}
