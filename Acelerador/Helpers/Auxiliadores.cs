using System.Text.RegularExpressions;

namespace Acelerador.Helpers
{
    public static class Auxiliadores
    {
        public static bool EmailValido(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}
