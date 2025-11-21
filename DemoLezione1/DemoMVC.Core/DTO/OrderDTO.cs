using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMVC.Core.DTO;

public class OrderDTO
{
    public int OrderId { get; set; }

    public required string CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }
}
