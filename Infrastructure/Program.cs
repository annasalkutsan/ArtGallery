using Application;
using Application.Authentications;
using Application.Interfaces;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositoryes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddCors();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // укзывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,

                    // строка, представляющая издателя
                    ValidIssuer = AuthOptions.ISSUER,

                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,

                    // установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,

                    // будет ли валидироваться время существования
                    ValidateLifetime = true,

                    // установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true
                };

            });

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

app.UseAuthentication();   
app.UseAuthorization();   

// Маршрутизация контроллеров
app.MapControllers();

// Запуск приложения
app.Run();
