namespace DemoLezione1.Models;

public class WelcomeMessage
{
    private readonly IClock clock;

    public WelcomeMessage(IClock clock)
    {
        this.clock = clock;
    }

    public string Welcome() { 
       if(clock.Now.Hour < 12)
       {
            return "Good morning!";
       }
       else
       {
            return "Good afternoon!";
       }
    }
}
