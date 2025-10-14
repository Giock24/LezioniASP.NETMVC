namespace DemoLezione1.Models;

public class A
{

    private readonly B _b;
    // in questo modo non c'è dipendenza diretta dalla classe concreta
    private readonly IMyNotification _email;

    public A (B b, IMyNotification email)
    {
        _b = b;
        _email = email;
    }
    public string DoSomething()
    {
        var messageFromB = _b.DoSomethingElse();
        _email.SendNotification("Gianluca");
        return $"Hello from A: {messageFromB}";
    }
}
