using DemoMVC.Core.DTO;

namespace DemoMVC.Core.ViewModel;

public class OrdersIndexViewModel
{
    public int PageIndex { get; set; }

    public int TotalPages { get; set; }

    public int PageSize { get; set; }

    public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
}
