namespace FrontEleccM.FrontServices
{
	using System.Net.Http;
	using System.Net.Http.Json;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using BackEleccionsM.Dto;
	public class PartitService
	{
		private readonly HttpClient _http;

		public PartitService(HttpClient http)
        {
			_http = http;
        }
		public async Task<List<PartitPoliticDto>> GetPartitsPoliticsAsync()
		{
			return await _http.GetFromJsonAsync<List<PartitPoliticDto>>("api/PartitPolitic");
		}

		public async Task<PartitPoliticDto> GetPartitPoliticByIdAsync(int id)
		{
			return await _http.GetFromJsonAsync<PartitPoliticDto>($"api/PartitPolitic/{id}");
		}

		public async Task<bool> CreatePartitPoliticAsync(PartitPoliticDto PartitPolitic)
		{
			var response = await _http.PostAsJsonAsync("api/PartitPolitic", PartitPolitic);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdatePartitPoliticAsync(PartitPoliticDto PartitPolitic)
		{
			var response = await _http.PutAsJsonAsync($"api/PartitPolitic/{PartitPolitic.ID}", PartitPolitic);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeletePartitPoliticAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/PartitPolitic/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
