using System.Collections.Generic;

namespace Patika_week1_Book.Controllers
{
    public class FakeUserLoginServices
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>
        {
            { "cagri", "ozden" },
        };

        public bool Authenticate(string NickName, string Password)
        {
            if (_users.TryGetValue(NickName, out string storedPassword))
            {
                // Büyük-küçük harf duyarlılığına dikkat ederek doğrudan şifre karşılaştırması yapıyoruz.
                return storedPassword.Equals(Password);
            }
            return false;
        }
    }
}