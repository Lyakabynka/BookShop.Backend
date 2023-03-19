using BookShop.Application;
using BookShop.Application.Interfaces;
using BookShop.Persistence;
using BookShop.Presentation.Middleware;
using Microsoft.OpenApi.Models;
using System.Reflection;

const string WebApiName = "BookShop WebApi";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(
    typeof(IBookShopDbContext).Assembly
    );

builder.Services.AddPersistence(builder.Configuration); // dbcontext
builder.Services.AddApplication(); // mediatr

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = WebApiName,
        Description = "Simple " + WebApiName,
        //TermsOfService = new Uri("uri"),
        Contact = new OpenApiContact()
        {
            Name = "Dmytro Murza",
            Email = "dima17741@gmail.com",
            //Url = ...
        },
        License = new OpenApiLicense()
        {
            Name = "Non-Commercial license",
            //Url = ...
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseCustomExceptionHandler();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", WebApiName);
        config.RoutePrefix = string.Empty;
    });
}

app.Run();
