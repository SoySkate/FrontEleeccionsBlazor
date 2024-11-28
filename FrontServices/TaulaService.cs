namespace FrontEleccM.FrontServices
{
	using System.Net.Http;
	using System.Net.Http.Json;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using BackEleccionsM.Dto;
	public class TaulaService
	{
		private readonly HttpClient _http;

		public TaulaService(HttpClient http)
        {
			_http = http;
        }
		public async Task<List<TaulaElectoralDto>> GetTaulaElectoralAsync()
		{
			return await _http.GetFromJsonAsync<List<TaulaElectoralDto>>("api/TaulaElectoral");
		}

		public async Task<TaulaElectoralDto> GetTaulaElectoralByIdAsync(int id)
		{
			return await _http.GetFromJsonAsync<TaulaElectoralDto>($"api/TaulaElectoral/{id}");
		}

		public async Task<bool> CreateTaulaElectoralAsync(TaulaElectoralDto TaulaElectoral)
		{
			var response = await _http.PostAsJsonAsync("api/TaulaElectoral", TaulaElectoral);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateTaulaElectoralAsync(TaulaElectoralDto TaulaElectoral)
		{
			var response = await _http.PutAsJsonAsync($"api/TaulaElectoral/{TaulaElectoral.ID}", TaulaElectoral);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteTaulaElectoralAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/TaulaElectoral/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
