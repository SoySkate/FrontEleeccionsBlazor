using Microsoft.JSInterop;

namespace FrontEleccM.FrontServices
{
    public class AuthStateService
    {
        private readonly IJSRuntime _jsRuntime;

        public AuthStateService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public event Action? AuthStateChanged;

        public void NotifyAuthStateChanged()
        {
            AuthStateChanged?.Invoke();
        }

        public async Task Logout()
        {
            // Eliminar el token de sessionStorage y localStorage
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "authToken");
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");

            // Notificar a los suscriptores
            NotifyAuthStateChanged();
        }
    }

}
