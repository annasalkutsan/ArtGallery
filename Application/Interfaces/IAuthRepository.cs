using Application.DTO.Auth;

namespace Application.Interfaces
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Авторизоваться  
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginResponse> Login(LoginRequest request);
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task Registration(RegisterRequest request);
    }
}
