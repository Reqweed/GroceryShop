using GroceryShop.API.Extensions;
using GroceryShop.API.Middlewares;
using GroceryShop.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureControllersAndFilters();
builder.Services.ConfigureMiddlewares();
builder.Services.ConfigureDbContext();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureMapper();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Logging.ConfigureLogger();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<PostgresDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();