namespace DemoLezione1;

// classe middleware per il logging delle richieste HTTP
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    // RequestDelegate rappresenta il prossimo middleware nella pipeline
    // ILogger è un'interfaccia per il logging
    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger) 
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Request Incoming: " + context.Request.Method + " " + context.Request.Path);
        await _next(context); // Chiamata al prossimo middleware
        _logger.LogInformation("Finisched Handling Request");
    }
}
