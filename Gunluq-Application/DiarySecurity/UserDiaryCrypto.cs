using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gunluq_Application.DiarySecurity
{
    public class UserDiaryCrypto
    {
        private readonly string _masterKey;

        public UserDiaryCrypto()
        {
            _masterKey = Environment.GetEnvironmentVariable("ENCRYPTION_KEY")
                ?? throw new Exception("ENCRYPTION_KEY yok");
        }

        // =========================
        // 🔑 KEY DERIVATION (KEK)
        // =========================
        private byte[] DeriveKek(string userCode, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(
                Encoding.UTF8.GetBytes(_masterKey + userCode),
                salt,
                100_000,
                HashAlgorithmName.SHA256);

            return pbkdf2.GetBytes(32);
        }

        // =========================
        // 🔐 AES-GCM ENCRYPT
        // =========================
        private byte[] EncryptRaw(byte[] data, byte[] key)
        {
            byte[] nonce = RandomNumberGenerator.GetBytes(12);
            byte[] cipher = new byte[data.Length];
            byte[] tag = new byte[16];

            using var aes = new AesGcm(key, 16);
            aes.Encrypt(nonce, data, cipher, tag);

            return nonce.Concat(tag).Concat(cipher).ToArray();
        }

        private byte[] DecryptRaw(byte[] encrypted, byte[] key)
        {
            byte[] nonce = encrypted[..12];
            byte[] tag = encrypted[12..28];
            byte[] cipher = encrypted[28..];

            byte[] plain = new byte[cipher.Length];

            using var aes = new AesGcm(key, 16);
            aes.Decrypt(nonce, cipher, tag, plain);

            return plain;
        }

        // =========================
        // 👤 USER SETUP
        // =========================
        public (string userCode, byte[] salt, string encryptedDek) CreateUserCrypto()
        {
            string userCode = RandomNumberGenerator
                .GetInt32(0, 1_000_000)
                .ToString("D6");

            byte[] salt = RandomNumberGenerator.GetBytes(16);

            // DEK üret (asıl veri key'i)
            byte[] dek = RandomNumberGenerator.GetBytes(32);

            // KEK türet
            byte[] kek = DeriveKek(userCode, salt);

            // DEK'i şifrele
            byte[] encryptedDek = EncryptRaw(dek, kek);

            return (userCode, salt, Convert.ToBase64String(encryptedDek));
        }

        // =========================
        // 📓 ENCRYPT DIARY
        // =========================
        public string EncryptDiary(string content, string encryptedDek, string userCode, byte[] salt)
        {
            byte[] kek = DeriveKek(userCode, salt);

            byte[] dek = DecryptRaw(
                Convert.FromBase64String(encryptedDek),
                kek);

            byte[] encrypted = EncryptRaw(
                Encoding.UTF8.GetBytes(content),
                dek);

            return Convert.ToBase64String(encrypted);
        }

        // =========================
        // 📖 DECRYPT DIARY
        // =========================
        public string DecryptDiary(string encryptedContent, string encryptedDek, string userCode, byte[] salt)
        {
            byte[] kek = DeriveKek(userCode, salt);

            byte[] dek = DecryptRaw(
                Convert.FromBase64String(encryptedDek),
                kek);

            byte[] plain = DecryptRaw(
                Convert.FromBase64String(encryptedContent),
                dek);

            return Encoding.UTF8.GetString(plain);
        }

        // =========================
        // 🔄 USER CODE CHANGE
        // =========================
        public string ReEncryptDek(string encryptedDek, string oldUserCode, string newUserCode, byte[] salt)
        {
            byte[] oldKek = DeriveKek(oldUserCode, salt);
            byte[] dek = DecryptRaw(Convert.FromBase64String(encryptedDek), oldKek);

            byte[] newKek = DeriveKek(newUserCode, salt);
            byte[] newEncryptedDek = EncryptRaw(dek, newKek);

            return Convert.ToBase64String(newEncryptedDek);
        }
    }
}
