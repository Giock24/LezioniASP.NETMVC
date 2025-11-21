using DemoMVC.Core.DTO;
using DemoMVC.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMVC.Core.Interfaces;

public interface IOrderData
{
    Task<IEnumerable<OrderDTO>> GetOrders(int pageNumber, int pageSize);

    Task<OrdersIndexViewModel?> GetOrdersVM(int pageNumber, int pageSize);
}
