using DemoMVC.Core.Interfaces;
using DemoMVC.Core.ViewModel;

namespace DemoMVC.Infrastructure.Services;

public class MenuService : IMenu
{
    private readonly IStudentsData studentsData;
    private readonly IWelcome welcome;

    public MenuService(IStudentsData studentsData, IWelcome welcome)
    {
        this.studentsData = studentsData;
        this.welcome = welcome;
    }

    public MenuViewModel GetMenuViewModel()
    {
        var viewModel = new MenuViewModel();

        viewModel.NumeroTotaleStudenti = studentsData.GetAll("Cognome").Count();
        viewModel.NomeCognomeUltimoInserito = studentsData.GetLastInserted();
        viewModel.Saluto = welcome.WelcomeMessage();

        return viewModel;
    }
}
