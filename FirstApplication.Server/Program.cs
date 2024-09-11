using FirstApplication.Server.Data;
using FirstApplication.Server.Interfaces;
using FirstApplication.Server.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar o CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()  // Permitir qualquer origem
                   .AllowAnyMethod()  // Permitir qualquer método (GET, POST, etc.)
                   .AllowAnyHeader();  // Permitir qualquer cabeçalho
        });
});

var app = builder.Build();

// Configure o pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar a política de CORS antes de qualquer outro middleware
app.UseCors("AllowAllOrigins");

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();  // Adiciona o middleware de roteamento

app.UseAuthorization();  // Adiciona o middleware de autorização

app.MapControllers();  // Mapeia os controladores

// Configure o fallback para servir o arquivo index.html para rotas SPA
app.MapFallbackToFile("/index.html");

app.Run();
