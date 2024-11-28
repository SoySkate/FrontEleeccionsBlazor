namespace FrontEleccM.FrontServices
{
	using System.Net.Http;
	using System.Net.Http.Json;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using BackEleccionsM.Dto;
	public class VotService
	{
		private readonly HttpClient _http;

		public VotService(HttpClient http)
        {
			_http = http;
        }
		public async Task<List<VotsPerPartitDto>> GetVotsPerPartitAsync()
		{
			return await _http.GetFromJsonAsync<List<VotsPerPartitDto>>("api/VotsPerPartit");
		}

		public async Task<VotsPerPartitDto> GetVotsPerPartitByIdAsync(int id)
		{
			return await _http.GetFromJsonAsync<VotsPerPartitDto>($"api/VotsPerPartit/{id}");
		}

		public async Task<bool> CreateVotsPerPartitAsync(VotsPerPartitDto VotsPerPartit)
		{
			var response = await _http.PostAsJsonAsync("api/VotsPerPartit", VotsPerPartit);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateVotsPerPartitAsync(VotsPerPartitDto VotsPerPartit)
		{
			var response = await _http.PutAsJsonAsync($"api/VotsPerPartit/{VotsPerPartit.ID}", VotsPerPartit);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteVotsPerPartitAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/VotsPerPartit/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
