namespace DemoLezione1.Models;

public class WelcomeMessage
{
    private readonly IClock _clock;

    public WelcomeMessage(IClock clock)
    {
        _clock = clock;
    }

    public string Welcome()
    {
        if (_clock.Now.Hour < 12)
        {
            return "Good morning!";
        }
        else
        {
            return "Good afternoon!";
        }
    }
}
