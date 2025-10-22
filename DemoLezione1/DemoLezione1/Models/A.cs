namespace DemoLezione1.Models;

public class A
{
    private readonly B b;
    private readonly IMyNotification email;

    public A(B b, IMyNotification email)
    {
        this.b = b;
        this.email = email;
    }

    public string DoSomething()
    {

       // var b = new B();
        var message = b.DoSomething();
        email.SendNotification("");
        return $"Hello from class A: {message}";
    }   
}
