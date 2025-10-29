using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;
using DemoMVC.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Infrastructure.Services;

public class MenuService : IMenu
{
    private readonly IStudentsData _studentsData;
    private readonly IWelcome _welcome;
    public MenuService(IStudentsData studentsData, IWelcome welcome)
    {
        _studentsData = studentsData;
        _welcome = welcome;
    }

    public MenuViewModel GetMenuViewModel()
    {
        var menuVM = new MenuViewModel();
        menuVM.Saluto = _welcome.WelcomeMessage();
        menuVM.NomeCognomeUltimoInserito = _studentsData.GetLastInserted();
        menuVM.NumeroTotaleStudenti = _studentsData.GetAll("cognome").Count().ToString() ?? "0";
        return menuVM;
    }
}
