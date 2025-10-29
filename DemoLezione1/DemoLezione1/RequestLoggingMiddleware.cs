namespace DemoLezione1;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<RequestLoggingMiddleware> logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger) {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) {
        logger.LogInformation("Handling request");
        await next(context);
        logger.LogInformation("PostHandling request");
    }
}

