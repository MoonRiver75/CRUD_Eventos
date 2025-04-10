using Microsoft.EntityFrameworkCore;
using Web_API_N.Models;
using Web_API_N.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEventDetailRepository, EventDetailRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de DbContext con SQL Server
builder.Services.AddDbContext<EventDetailsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")),
    ServiceLifetime.Scoped 
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configuración de CORS para permitir Angular (localhost:4200)
app.UseCors(options => options
    .WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthorization();
app.MapControllers();
app.Run();