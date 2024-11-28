namespace FrontEleccM.FrontServices
{
	using System.Net.Http;
	using System.Net.Http.Json;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using BackEleccionsM.Dto;
	public class ResultatTaulaService
	{
		private readonly HttpClient _http;

		public ResultatTaulaService(HttpClient http)
        {
			_http = http;
        }
		public async Task<List<ResultatsTaulaDto>> GetResultatsTaulaAsync()
		{
			return await _http.GetFromJsonAsync<List<ResultatsTaulaDto>>("api/ResultatsTaula");
		}

		public async Task<ResultatsTaulaDto> GetResultatsTaulaByIdAsync(int id)
		{
			return await _http.GetFromJsonAsync<ResultatsTaulaDto>($"api/ResultatsTaula/{id}");
		}

		public async Task<bool> CreateResultatsTaulaAsync(ResultatsTaulaDto ResultatsTaula)
		{
			var response = await _http.PostAsJsonAsync("api/ResultatsTaula", ResultatsTaula);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateResultatsTaulaAsync(ResultatsTaulaDto ResultatsTaula)
		{
			var response = await _http.PutAsJsonAsync($"api/ResultatsTaula/{ResultatsTaula.ID}", ResultatsTaula);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteResultatsTaulaAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/ResultatsTaula/{id}");
			return response.IsSuccessStatusCode;
		}
	}
}
