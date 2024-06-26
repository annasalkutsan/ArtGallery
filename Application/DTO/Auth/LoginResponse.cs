using Domain.Primitives;

namespace Application.DTO.Auth
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string NickName { get; set; }
        public EnumTypeRoles Role { get; set; }
    }
}
