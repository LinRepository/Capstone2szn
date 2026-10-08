using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstoneszn
{
    public static class SecurityHelper
    {
        private const int WorkFactor = 12;

        public static string Hash(string plain)
            => BCrypt.Net.BCrypt.HashPassword(plain, WorkFactor);

        public static bool Verify(string entered, string storedHash)
        {
            if (string.IsNullOrEmpty(storedHash)) return false;
            try { return BCrypt.Net.BCrypt.Verify(entered, storedHash); }
            catch (BCrypt.Net.SaltParseException) { return false; }
        }

        public static string NormalizeAnswer(string answer)
            => (answer ?? string.Empty).Trim();
    }
}
