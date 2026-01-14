using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Añadir servicios de Swagger/OpenAPI
// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BarberFlow API",
        Description = "API para gestión de barbería"
    });
});

var app = builder.Build();

// Configurar pipeline
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty; // Para ver Swagger en la raíz
    });
}

// Tus endpoints aquí...

app.Run();