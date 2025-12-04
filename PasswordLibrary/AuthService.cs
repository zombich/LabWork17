namespace AuthLibrary
{
    public static class AuthService
    {
        public static string HashPassword(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public static bool VerifyPassword(string password, string passwordHash)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }
}
