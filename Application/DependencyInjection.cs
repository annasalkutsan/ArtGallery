using Application.MappingProfiles;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        /// <summary>
        ///     Регистрация профилей AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile)); // Замените на реальные классы профилей
            services.AddAutoMapper(typeof(AuthorProfile)); // Замените на реальные классы профилей
            services.AddAutoMapper(typeof(PaintingProfile)); // Замените на реальные классы профилей
            services.AddAutoMapper(typeof(OrderProfile)); // Замените на реальные классы профилей
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
        /// <summary>
        ///     Регистрация сервисов
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<AuthorService>();
            services.AddScoped<PaintingService>();
            services.AddScoped<OrderService>();
            services.AddScoped<ImageService>();
            services.AddScoped<AuthService>();

            return services;
        }
    }
}
