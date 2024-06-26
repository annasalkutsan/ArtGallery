using Application.DTO.Auth;
using Application.Interfaces;
using AutoMapper;

namespace Application.Services
{
    public class AuthService 
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        /// <summary>
        /// Авторизоваться  
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var res = await _authRepository.Login(request);
            return res;
        }
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task Registration(RegisterRequest request)
        {
            await _authRepository.Registration(request);
        }
    }
}
