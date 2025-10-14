namespace DemoLezione1.Models;

public interface IClock
{
    DateTime Now { get; }
}

public class  MorningClock : IClock
{
    public DateTime Now => new DateTime(2000, 1, 1, 10, 0, 0);
}

public class AfternoonClock : IClock
{
    public DateTime Now => new DateTime(2000, 1, 1, 17, 0, 0);
}

public class SystemClock : IClock
{
    public DateTime Now => DateTime.Now;
}
