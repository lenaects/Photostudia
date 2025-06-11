using System.Security.Cryptography;
using System.Text;

namespace PhotoStudia_1.Services
{
    public class PasswordHasher
    {
        public static string HashPassword(string password, out string salt)
        {
            // Генерация соли
            var saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);

            // Конкатенация пароля и соли
            var saltedPassword = password + salt;

            // Хэширование
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            // Конкатенация пароля и соли
            var saltedPassword = password + salt;

            // Хэширование для сравнения
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                var computedHash = Convert.ToBase64String(hashBytes);

                return computedHash == hashedPassword;
            }
        }
    }
}
