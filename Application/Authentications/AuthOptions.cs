using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Application.Authentications
{
    public class AuthOptions
    {
        public const string ISSUER = "XLEB";

        public const string AUDIENCE = "MPID";

        private const string KEY = "mysupersecret_secretkey!Doteka228";

        public const int LIFETIME = 10000;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
