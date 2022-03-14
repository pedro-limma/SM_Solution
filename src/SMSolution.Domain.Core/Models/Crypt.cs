using System.Security.Cryptography;
using System.Text;

namespace SMSolution.Domain.Core.Models
{
    public class Crypt
    {
        private HashAlgorithm _algorithm;
        public Crypt(HashAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public string HashPassword(string password)
        {
            byte[] encodedValue = Encoding.UTF8.GetBytes(password);

            byte[] encryptedPassword = _algorithm.ComputeHash(encodedValue);

            StringBuilder sb = new ();
            foreach (byte character in encryptedPassword)
            {
                sb.Append(character.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
