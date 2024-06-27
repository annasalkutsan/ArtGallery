using Application.Interfaces;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositoryes;
using Microsoft.EntityFrameworkCore;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Application.Authentications;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавление службы для автоматического создания документации API (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Добавление контроллеров
builder.Services.AddControllers();

// Регистрация профилей AutoMapper
builder.Services.AddMappings();
// Регистрация сервисов
//builder.Services.AddServiceApplication();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<PaintingService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<AuthService>();

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

app.UseAuthentication(); 
app.UseAuthorization();  

// Добавление маршрутизации
app.UseRouting();

// Маршрутизация контроллеров
app.MapControllers();

// Запуск приложения
app.Run();
