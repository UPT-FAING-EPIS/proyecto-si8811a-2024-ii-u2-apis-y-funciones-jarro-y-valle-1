using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Models;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Services;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Config MongoDB
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<EVConnection>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Configurar servicios y controladores
builder.Services.AddControllers();

// Configurar el cliente MongoDB


// Agregar servicios específicos
builder.Services.AddSingleton<EventoService>();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Aplicar CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Urls.Add("http://0.0.0.0:9091");
app.Run();
