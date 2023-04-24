using Study.HR.Core.Domain.Services;
using System.Security.Cryptography;
using System.Text;

namespace Study.HR.Core.Infrastructure.Services
{
    public class HashService : IHashService
    {
        public string Hash(string value)
        {
            using var sha = SHA256.Create();

            byte[] textBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            string hash = BitConverter.ToString(hashBytes)
                .Replace("-", string.Empty);

            return hash;
        }
    }
}
