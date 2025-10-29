using DemoLezione1;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();

app.UseWhen( context => context.Request.Path.StartsWithSegments("/admin"),
    appBuilder => 
    {
        appBuilder.Use(async(context, next) => 
        {
            app.Logger.LogInformation("admin before");
            await next.Invoke();
            app.Logger.LogInformation("admin before");
        });
    });

app.Use(async (context, next) => 
{
    app.Logger.LogInformation("First Middelware");
    app.Logger.LogInformation("Request Incoming:"+context.Request.Method+" "+context.Request.Path);
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    app.Logger.LogInformation("Second Middelware");
    await next.Invoke();
});

app.UseMiddleware<RequestLoggingMiddleware>();

//app.Use(async (context, next) =>
//{
//    var watch = System.Diagnostics.Stopwatch.StartNew();
//    await next.Invoke();
//    watch.Stop();
//    var elapsedMs = watch.ElapsedMilliseconds;
//    context.Response.Headers.Add("X-Response-Time-ms", elapsedMs.ToString());
//    //await context.Response.WriteAsync("Hello world2!");
//});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Run();


#region Old code

// Add services to the container.
//builder.Services.AddSingleton<IMyNotification, EmailNotification>();
//builder.Services.AddTransient<B>();
//builder.Services.AddScoped<A>();
//builder.Services.AddScoped<IClock, SystemClock>();
//builder.Services.AddScoped<WelcomeMessage>();
//builder.Services.Configure<PositionOptions>
//    (builder.Configuration.GetSection(PositionOptions.Position));

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
