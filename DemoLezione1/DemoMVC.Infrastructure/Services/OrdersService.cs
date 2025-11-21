using DemoMVC.Core.DTO;
using DemoMVC.Core.Interfaces;
using DemoMVC.Core.ViewModel;
using DemoMVC.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DemoMVC.Infrastructure.Services;

public class OrdersService : IOrderData
{
    private readonly IData<Order> repository;
    private readonly IConfiguration configuration;

    public OrdersService(IData<Order> repository, IConfiguration configuration)
    {
        this.repository = repository;
        this.configuration = configuration;
    }

    public async Task<IEnumerable<OrderDTO>> GetOrders(int pageNumber, int pageSize)
    {
        var orderId = configuration["OrderId"];
        int id = 0;

        if (orderId != null)
        {
            id = int.Parse(orderId);
        }

        var orders = await repository.GetAll()/*.Where(X => X.OrderId >= id)*/.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return orders.Select(o => new OrderDTO { OrderId = o.OrderId, CustomerId = o.CustomerId, EmployeeId = o.EmployeeId, OrderDate = o.OrderDate, RequiredDate = o.RequiredDate, ShippedDate = o.ShippedDate});
    }

    public async Task<OrdersIndexViewModel?> GetOrdersVM(int pageNumber, int pageSize = 10)
    {
        var total = await (repository.GetAll()).CountAsync();
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);

        OrdersIndexViewModel viewModel = new OrdersIndexViewModel();

        viewModel.PageIndex = pageNumber;
        viewModel.PageSize = pageSize;
        viewModel.TotalPages = totalPages;
        viewModel.Orders = (await GetOrders(pageNumber, pageSize)).Select(o => new OrderDTO { OrderId = o.OrderId, CustomerId = o.CustomerId, EmployeeId = o.EmployeeId, OrderDate = o.OrderDate, RequiredDate = o.RequiredDate, ShippedDate = o.ShippedDate }).ToList();

        return viewModel;
    }
}
