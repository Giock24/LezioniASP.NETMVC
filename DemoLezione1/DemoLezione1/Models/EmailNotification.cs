namespace DemoLezione1.Models;

public class EmailNotification : IMyNotification
{
    public string SendNotification(string to)
    {
        return "Email notification sent.";
    }
}

public class SmsNotification : IMyNotification
{
    public string SendNotification(string to)
    {
        return "SMS notification sent.";
    }
}

public class  WhatsAppNotification : IMyNotification
{
    public string SendNotification(string to)
    {
        return "WhatsApp notification sent.";
    }
}

