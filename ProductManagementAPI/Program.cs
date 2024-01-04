using Microsoft.OpenApi.Models;
using System.Reflection;
using ProductManagementAPI.Product.Application.interfaces;
using ProductManagementAPI.Product.Application.services;
using ProductManagementAPI.Infrastructure.IoC; // Asegúrate de agregar esta referencia
using Serilog;
using ProductManagementAPI.Infrastructure.Logging;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();

//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .WriteTo.Console()
//    .WriteTo.File("logs/ProductManagementAPI.log", rollingInterval: RollingInterval.Day)
//    .CreateLogger();
//builder.Host.UseSerilog(); // Indica al host que utilice Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();
DependencyContainer.RegisterServices(builder.Services, builder.Configuration);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Configuración de Swagger con comentarios XML.
// Swagger se utiliza para generar una interfaz de usuario interactiva y descriptiva para la API,
// facilitando la visualización y prueba de los endpoints de la API.
builder.Services.AddSwaggerGen(c =>
{
    // Define la información de la versión para la UI de Swagger.
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });

    // Incluyendo los comentarios XML para que Swagger los muestre como parte de la documentación de la API.
    // Los comentarios XML son generados por el compilador de C# y contienen la documentación de los métodos y clases.
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    c.IncludeXmlComments(xmlPath);
    c.EnableAnnotations();
});

var app = builder.Build();

var productStateService = app.Services.CreateScope().ServiceProvider.GetRequiredService<IProductStateService>();
await productStateService.LoadStatesAsync();

// Configura el pipeline de solicitudes HTTP para el entorno de desarrollo.
// Esto incluye la configuración de Swagger para que se ejecute solo en desarrollo.
if (app.Environment.IsDevelopment())
{
    // Activa el middleware para servir la UI de Swagger.
    app.UseSwagger();
    // Activa el middleware para servir la UI de Swagger con la configuración de JSON de Swagger.
    app.UseSwaggerUI();
}

// Middleware para redirigir HTTP a HTTPS.
app.UseHttpsRedirection();

app.UseMiddleware<ResponseTimeLoggingMiddleware>();


// Middleware para manejar la autorización.
app.UseAuthorization();

// Mapeo de los controladores en la aplicación.
app.MapControllers();

// Ejecuta la aplicación.
app.Run();


/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/