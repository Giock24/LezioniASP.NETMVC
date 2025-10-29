using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class WelcomeStaticClass : IWelcome
{
    public string WelcomeMessage()
    {
        return "Buongiorno";
    }
}
