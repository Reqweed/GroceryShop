using GroceryShop.API.Extensions;
using GroceryShop.API.Middlewares;

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();