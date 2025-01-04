namespace FrontEleccM.FrontServices
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using BackEleccionsM.Dto;
    using Microsoft.JSInterop;

    public class MunicipiService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _jsRuntime;

        public MunicipiService(HttpClient http, IJSRuntime jsRuntime)
        {
            _http = http;
            _jsRuntime = jsRuntime;
        }

        // Método para obtener el token del almacenamiento local
        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");
        }

        // Método para añadir el token al header de las solicitudes
        public async Task SetAuthorizationHeaderAsync(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                Console.WriteLine($"Token configurado en el encabezado: {token}");
            }
            else
            {
                Console.WriteLine("No se proporcionó un token válido.");
            }
            //var token = await GetTokenAsync();
            //Console.WriteLine("Token obtenido: " + (token ?? "null"));
            //if (!string.IsNullOrEmpty(token))
            //{
            //    _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            //    Console.WriteLine($"Token configurado en el encabezado: {token}");
            //}
            //else
            //{
            //    Console.WriteLine("No se encontró un token válido.");
            //}
        }


        public async Task<List<MunicipiDto>> GetMunicipisAsync()
        {
            // Asegurar que el header de autorización esté configurado
            var token = await GetTokenAsync();
            await SetAuthorizationHeaderAsync(token);

            // Realizar la solicitud al backend
            return await _http.GetFromJsonAsync<List<MunicipiDto>>("api/Municipi");
        }

        public async Task<MunicipiDto> GetMunicipiByIdAsync(int id)
        {
            // Asegurar que el header de autorización esté configurado
            var token = await GetTokenAsync();
            await SetAuthorizationHeaderAsync(token);

            // Realizar la solicitud al backend
            return await _http.GetFromJsonAsync<MunicipiDto>($"api/Municipi/{id}");
        }

        public async Task<bool> CreateMunicipiAsync(MunicipiDto municipi)
        {
            // Asegurar que el header de autorización esté configurado
            var token = await GetTokenAsync();
            await SetAuthorizationHeaderAsync(token);

            // Realizar la solicitud al backend
            var response = await _http.PostAsJsonAsync("api/Municipi", municipi);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateMunicipiAsync(MunicipiDto municipi)
        {
            // Asegurar que el header de autorización esté configurado
            var token = await GetTokenAsync();
            await SetAuthorizationHeaderAsync(token);

            // Realizar la solicitud al backend
            var response = await _http.PutAsJsonAsync($"api/Municipi/{municipi.ID}", municipi);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMunicipiAsync(int id)
        {
            // Asegurar que el header de autorización esté configurado
            var token = await GetTokenAsync();
            await SetAuthorizationHeaderAsync(token);

            // Realizar la solicitud al backend
            var response = await _http.DeleteAsync($"api/Municipi/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
