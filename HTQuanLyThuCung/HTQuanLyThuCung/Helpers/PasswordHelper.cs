using System;
using System.Security.Cryptography;
using System.Text;

namespace HTQuanLyThuCung.Helpers
{
    public static class PasswordHelper
    {
        // Salt mặc định để hash password
        private const string DEFAULT_SALT = "HTQuanLyThuCung_Salt_2024";

        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Mật khẩu không được để trống", nameof(password));
            }

            // Tạo salt từ password
            string salt = DEFAULT_SALT + password.Length.ToString();

            // Kết hợp password + salt
            string combined = password + salt;

            // Hash bằng SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(combined));

                // Chuyển đổi byte array thành string hex
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string password, string storedPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(storedPasswordHash))
            {
                return false;
            }

            string hashedPassword = HashPassword(password);

            return hashedPassword.Equals(storedPasswordHash, StringComparison.Ordinal);
        }

        // Kiểm tra pattern SQL injection (dùng cho password)
        public static bool ContainsDangerousCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            string upperInput = input.ToUpper();

            string[] dangerousPatterns = {
                "--", "/*", "*/", ";",
                " OR ", " AND ", " UNION ", " SELECT ", " DROP ",
                " INSERT ", " UPDATE ", " DELETE ", " EXEC ",
                " CREATE ", " ALTER ", " TRUNCATE ",
                "1=1", "'='"
            };

            foreach (string pattern in dangerousPatterns)
            {
                if (upperInput.Contains(pattern))
                    return true;
            }

            return false;
        }

        // Strict check cho username
        public static bool ContainsDangerousCharactersStrict(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            if (input.Contains("'") || input.Contains("\""))
                return true;

            return ContainsDangerousCharacters(input);
        }

        // Validate username
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            foreach (char c in username)
            {
                if (!char.IsLetterOrDigit(c) && c != '_')
                    return false;
            }

            if (ContainsDangerousCharactersStrict(username))
                return false;

            return true;
        }

        // Validate password
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (ContainsDangerousCharacters(password))
                return false;

            return true;
        }
    }
}