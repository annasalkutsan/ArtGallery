using System.Security.Cryptography;
using System.Text;

namespace Application.Authentications
{
    public static class GetHash
    {
        /// <summary>
        /// Метод для генерации хеша пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static (string hash, string salt) GetHashPassword(string password)
        {
            var passwordKey = Guid.NewGuid().ToString("N");
            return (BitConverter.ToString(
                SHA256.Create().ComputeHash(
                    Encoding.UTF8.GetBytes(password + passwordKey))), passwordKey);
        }
        /// <summary>
        /// Метод для хеширования пароля с использованием заданной ключем
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string GetHashPassword(string password, string salt)
        {
            return BitConverter.ToString(
                SHA256.Create().ComputeHash(
                    Encoding.UTF8.GetBytes(password + salt)));
        }
        /// <summary>
        /// Метод для вычисления хеша изображения
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string ImageHash(Stream stream)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return BitConverter.ToString(sha256.ComputeHash(stream))
                    .Replace("-", "")
                        .ToLower();
            }
        }
    }
}
