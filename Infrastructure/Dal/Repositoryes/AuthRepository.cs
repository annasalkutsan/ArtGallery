using Application.Authentications;
using Application.DTO.Auth;
using Application.Interfaces;
using Domain.Entities;
using Domain.Primitives;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Dal.Repositoryes
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ArtGalleryDbContext _dbContext;

        public AuthRepository(ArtGalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email.Trim());
            if (user is null)
                throw new Exception("Неверный Email");

            if (user.PasswordHash != GetHash.GetHashPassword(request.Password, user.PasswordSalt))
                throw new Exception("Неверный Password");

            var tokenResult = await GenerateToken(user.Id);

            return new LoginResponse {
                Id = user.Id,
                NickName = user.NickName,
                Token = tokenResult.Token,
                Role = user.Role
            };
        }

        public async Task Registration(RegisterRequest request)
        {
            if (await _dbContext.Users.AnyAsync(x => x.Email == request.Email.Trim()))
                throw new Exception("Данный UserName уже используется!");

            var guidEmail = Guid.NewGuid();
            var (hashedPassword, salt) = GetHash.GetHashPassword(request.Password);

            var user = new User
            {
                NickName = request.NickName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                Role = EnumTypeRoles.Buyer,
                PaymentDetails = request.PaymentDetails
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<TokenResponse> GenerateToken(Guid Id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == Id);

            if (user is null)
                throw new Exception();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = AuthOptions.GetSymmetricSecurityKey();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.NickName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(AuthOptions.LIFETIME),
                Audience = AuthOptions.AUDIENCE,
                Issuer = AuthOptions.ISSUER,
                SigningCredentials = new(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResponse
            {
                Id = user.Id,
                NickName = user.NickName,
                Token = $"Bearer {tokenHandler.WriteToken(token)}",
            };
        }
    }
}
