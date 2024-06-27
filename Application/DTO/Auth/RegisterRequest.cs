using Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Auth
{
    public class RegisterRequest
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public PaymentDetails PaymentDetails { get; set; }
    }
}
