using System.Security.Cryptography;
using System.Text;

namespace Gunluq_Application.PasswordHelper
{
    public static class PasswordHasher
    {

        /// <summary>
        /// Kullanıcı şifresini Hashleme işlemi yapar
        /// </summary>
        /// <param name="password">Kullanıcının kayıt sırasındaki şifresi</param>
        /// <returns>Hashlenmiş Şifreyi döner</returns>
        public static string Hash(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }


        /// <summary>
        /// Kullanıcının şifresi Doğru mu? kontrolü
        /// </summary>
        /// <param name="hashedPassword">Kullanıcının Hashli şifresi</param>
        /// <param name="providedPassword">Kullanıcının giriş anında input'a girilen şifresi</param>
        /// <returns>Şifre doğru veya yanlış şeklinde TRUE - FALSE döner</returns>
        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var hasOfInput = Hash(hashedPassword);
            return hasOfInput == providedPassword;
        }
    }
}
