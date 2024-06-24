using Application.Interfaces;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositoryes;
using Microsoft.EntityFrameworkCore;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Добавление службы для автоматического создания документации API (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Добавление контроллеров
builder.Services.AddControllers();

// Регистрация профилей AutoMapper
builder.Services.AddMappings();
// Регистрация сервисов
builder.Services.AddServiceApplication();

// Получение строки подключения из конфигурационного файла
var connectionString = builder.Configuration.GetConnectionString("ArtGalleryDatabase");
// Настройка контекста базы данных для использования PostgreSQL
builder.Services.AddDbContext<ArtGalleryDbContext>(options => options.UseNpgsql(connectionString));

// Регистрация репозиториев
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPaintingRepository, PaintingRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();


var app = builder.Build();

// Конфигурация конвейера обработки HTTP-запросов
if (app.Environment.IsDevelopment())
{
    // Использование Swagger только в режиме разработки
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Перенаправление HTTP-запросов на HTTPS
app.UseHttpsRedirection();

// Добавление маршрутизации
app.UseRouting();

// Маршрутизация контроллеров
app.MapControllers();

// Запуск приложения
app.Run();
