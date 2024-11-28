namespace FrontEleccM.FrontServices
{
	using System.Net.Http;
	using System.Net.Http.Json;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using BackEleccionsM.Dto;
	public class CandidatService
	{
		private readonly HttpClient _http;

		public CandidatService(HttpClient http)
        {
			_http = http;
        }
		public async Task<List<CandidatDto>> GetCandidatAsync()
		{
			return await _http.GetFromJsonAsync<List<CandidatDto>>("api/Candidat");
		}

		public async Task<CandidatDto> GetCandidatByIdAsync(int id)
		{
			return await _http.GetFromJsonAsync<CandidatDto>($"api/Candidat/{id}");
		}

		public async Task<bool> CreateCandidatAsync(CandidatDto Candidat)
		{
			var response = await _http.PostAsJsonAsync("api/Candidat", Candidat);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateCandidatAsync(CandidatDto Candidat)
		{
			var response = await _http.PutAsJsonAsync($"api/Candidat/{Candidat.ID}", Candidat);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteCandidatAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/Candidat/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
