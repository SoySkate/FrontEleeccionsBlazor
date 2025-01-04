using System.Text;
using System.Text.Json;

namespace FrontEleccM.Utils
{
    public static class TokenUtils
    {
        public static string DecodeJwt(string token)
        {
            var parts = token.Split('.');
            if (parts.Length != 3)
            {
                throw new FormatException("El token JWT no tiene el formato esperado.");
            }

            var payload = parts[1];
            payload = payload.Replace('-', '+').Replace('_', '/');
            switch (payload.Length % 4)
            {
                case 2: payload += "=="; break;
                case 3: payload += "="; break;
            }

            var jsonBytes = Convert.FromBase64String(payload);
            var jsonPayload = Encoding.UTF8.GetString(jsonBytes);

            var parsedPayload = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonPayload);
            return parsedPayload.TryGetValue("sub", out var userName) ? userName.ToString() : "Usuario";
        }
    }
}
