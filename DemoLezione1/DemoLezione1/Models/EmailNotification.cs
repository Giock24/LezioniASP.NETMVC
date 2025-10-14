namespace DemoLezione1.Models;

public class EmailNotification : IMyNotification
{
    public string SendNotification(string to)
    {
        return $"Email sent to {to}!";
    }
}

public class WhatsAppNotification : IMyNotification
{
    public string SendNotification(string to)
    {
        return $"WhatsApp message sent to {to}!";
    }
}
