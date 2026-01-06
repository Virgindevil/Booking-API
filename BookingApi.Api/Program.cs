using Microsoft.EntityFrameworkCore;
using BookingApi.Infrastructure.Data;
using BookingApi.Application;
using BookingApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Слой приложения и инфраструктуры (пока просто регистрируем сборки)
builder.Services.AddApplication(); // мы создадим этот метод
builder.Services.AddInfrastructure(); // и этот

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();