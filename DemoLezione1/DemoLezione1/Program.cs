
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddSingleton<IMyNotification, EmailNotification>();
//builder.Services.AddTransient<B>();
//builder.Services.AddScoped<A>();
//builder.Services.AddScoped<IClock, SystemClock>();
//builder.Services.AddScoped<WelcomeMessage>();
//builder.Services.Configure<PositionOptions>
//    (builder.Configuration.GetSection(PositionOptions.Position));


var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
app.UseWhen(context => context.Request.Path.StartsWithSegments("/admin"), 
    appBuilder =>
    {
        appBuilder.Use(async (context, next) =>
        {
            app.Logger.LogInformation("Admin Area Middleware - Before Next");
            await next.Invoke();
            app.Logger.LogInformation("Admin Area Middleware - After Next");
        });
    }
);

app.Use(async (context, next) => {
    app.Logger.LogInformation("First Middleware");
    app.Logger.LogInformation("Request Incoming: " + context.Request.Method + " " + context.Request.Path);
    await next.Invoke();
});

app.UseMiddleware<RequestLoggingMiddleware>();

//app.Use(async (context, next) =>
//{
//    var watch = System.Diagnostics.Stopwatch.StartNew();
//    await Task.Delay(1000); // Simula un'elaborazione
//    await next.Invoke();
//    watch.Stop();
//    var elapsedMs = watch.ElapsedMilliseconds;
//    // Aggiunge l'intestazione personalizzata alla risposta
//    context.Response.Headers.Add("X-Response-Time-Ms", elapsedMs.ToString());
//    await context.Response.WriteAsync($"\nResponse Time: {elapsedMs} ms");
//});

#region oldcode
//app.MapGet("/", 
//    (IMyNotification notification, A a, WelcomeMessage w) => {
//        // var b = new B();
//        //var smsNotification = new SmsNotification();    
//        //var a = new A(b,notification);
//        var message = w.Welcome() + ", " +   a.DoSomething() + " Hello World!";
//        return message;
//    }
//);

//app.MapGet("/", (IConfiguration configuration) =>
//{
//    // var result = configuration["Chiave"];
//    //var result = configuration["ChiaveComplessa:B:C:D"];

//    //var positionOptions = new PositionOptions();
//    //configuration.GetSection(PositionOptions.Position).Bind(positionOptions);
//    //var result = positionOptions.Title + " " + positionOptions.Name;
//    //return result;

//    //return result ?? "Non ho trovato la chiave";
//});

//app.MapGet("/", (IOptions<PositionOptions> positionOptions) => { 
//      return positionOptions.Value.Title + " " + positionOptions.Value.Name;
//});
#endregion

app.Run(async context => { 
    app.Logger.LogInformation("Second Middleware");
    await context.Response.WriteAsync("Hello World!");
});


app.Run();

