namespace SecureStore.API.AppDbContext.Security
{
    public interface IPasswordHasher
    {
        string GetHashPassword(string Password);
        bool VerifyPassword(string PasswordHash, string Password);
    }
}
