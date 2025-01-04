using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;


namespace FrontEleccM
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        //Obté els valors que hi han emmagatzemats a la SessionStorage del browser
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");
        

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var claims = ParseClaimsFromJwt(token);
            // Imprimir todos los claims para depurar 
            Console.WriteLine("Claims parseados:");
            foreach (var claim in claims)
            {
                Console.WriteLine($"Tipo: {claim.Type}, Valor: {claim.Value}");
            }

            var identity = new ClaimsIdentity(claims, "jwt");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = Convert.FromBase64String(AddPadding(payload));
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            var claims = new List<Claim>();

            foreach (var kvp in keyValuePairs)
            {
                if (kvp.Key == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                {
                    // Si el rol está en un array, manejalo
                    if (kvp.Value is JsonElement roleElement && roleElement.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var role in roleElement.EnumerateArray())
                        {
                            Console.WriteLine($"Rol encontrado: {role.GetString()}");
                            claims.Add(new Claim(ClaimTypes.Role, role.GetString()));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Rol único encontrado: {kvp.Value}");
                        // Si el rol es un solo valor
                        claims.Add(new Claim(ClaimTypes.Role, kvp.Value.ToString()));
                    }
                }
                else
                {
                    claims.Add(new Claim(kvp.Key, kvp.Value.ToString()));
                }
            }

            return claims;
        }


        private string AddPadding(string base64)
        {
            return base64.Length % 4 == 0 ? base64 : base64.PadRight(base64.Length + (4 - base64.Length % 4), '=');
        }
    }

}
