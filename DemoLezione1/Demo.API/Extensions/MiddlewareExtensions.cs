namespace Demo.API.Extensions;

public static class MiddlewareExtensions
{
    public static void SetUpAppMiddleware(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.RegisterCategoriesEndpoint();

    }
}
