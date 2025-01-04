using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FrontEleccM.FrontServices
{
    public class RoleService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public RoleService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }
        //crea una llista amb els rols que detecta al claims que hi ha al token del usuari
        public async Task<List<string>> GetUserRolesAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (!user.Identity.IsAuthenticated)
                return new List<string>();

            return user.Claims
                .Where(c => c.Type == ClaimTypes.Role || c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                .Select(c => c.Value)
                .ToList();
        }
        //Detecta si hi ha un rol especific a la llista creada per la func anterior
        public async Task<bool> IsInRoleAsync(string role)
        {
            var roles = await GetUserRolesAsync();
            return roles.Contains(role);
        }
    }

}
