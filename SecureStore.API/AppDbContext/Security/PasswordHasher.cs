using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
namespace SecureStore.API.AppDbContext.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; 
        private const int HashSize = 32; 
        private const int Iterations = 10000; 

        public string GetHashPassword(string password)
        {

            byte[] saltBytes = new byte[SaltSize];
            RandomNumberGenerator.Fill(saltBytes);


            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);


                return $"{Convert.ToBase64String(saltBytes)}:{Convert.ToBase64String(hashBytes)}";
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {

            string[] parts = storedHash.Split(':');
            if (parts.Length != 2) return false;

            byte[] saltBytes = Convert.FromBase64String(parts[0]);
            byte[] storedHashBytes = Convert.FromBase64String(parts[1]);


            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);


                return CryptographicOperations.FixedTimeEquals(hashBytes, storedHashBytes);
            }
        }
    }
}
