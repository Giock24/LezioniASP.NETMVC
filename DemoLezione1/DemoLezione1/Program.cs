//using DemoLezione1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// è come se fosse un cesto di oggetti
// il problema del Singleton è che non va bene per i siti web, perché l'instanza è sempre la stessa
builder.Services.AddSingleton<IMyNotification, EmailNotification>();
// addTransient crea una nuova istanza ogni volta che viene richiesta
builder.Services.AddTransient<B>();
// addScoped crea una nuova istanza per ogni richiesta HTTP
builder.Services.AddScoped<A>();
builder.Services.AddScoped<IClock, SystemClock>();
builder.Services.AddScoped<WelcomeMessage>();


var app = builder.Build();

var student = new Student() { Id = 1 };
Student student2 = new() { Id = 2 };
Student student3 = new Student { Id = 3 };

app.MapGet("/", 
    (IMyNotification notification, A a, WelcomeMessage w) => {
        //var b = new B();
        //var email = new WhatsAppNotification();
        //var a = new A(b, notification);
        var message = w.Welcome() + a.DoSomething() + " Hello World!";
        return message;
    }
);

app.Run();