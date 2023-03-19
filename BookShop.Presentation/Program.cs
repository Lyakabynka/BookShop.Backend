using BookShop.Application;
using BookShop.Application.Interfaces;
using BookShop.Persistence;
using BookShop.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(
    typeof(IBookShopDbContext).Assembly
    );

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
