using DemoMVC.Core.Interfaces;
using DemoMVC.Core.ViewModel;
using DemoMVC.Data.Models;

namespace DemoMVC.Infrastructure.Services;

public class DashboardService : IDashboard
{
    private readonly NorthwindContext northwindContext;

    public DashboardService(NorthwindContext northwindContext)
    {
        this.northwindContext = northwindContext;
    }

    public DashboardIndexViewModel DashboardIndexViewModel()
    {
        var dashboardIndexVM = new DashboardIndexViewModel
        {
            NumeroCategorie = northwindContext.Categories.Count(),
            NumeroProdotti = northwindContext.Products.Count(),
            UltimaCategoriaCreata = northwindContext.Categories.OrderByDescending(x => x.CategoryId).First().CategoryName
        };

        return dashboardIndexVM;
    }
}
