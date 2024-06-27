namespace Application.DTO.Auth
{
    public class TokenResponse
    {
        public Guid Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
