namespace FrontEleccM.FrontServices
{
	using System.Net.Http;
	using System.Net.Http.Json;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using BackEleccionsM.Dto;

	public class MunicipiService
	{
		private readonly HttpClient _http;

		public MunicipiService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<MunicipiDto>> GetMunicipisAsync()
		{
			return await _http.GetFromJsonAsync<List<MunicipiDto>>("api/Municipi");
		}

		public async Task<MunicipiDto> GetMunicipiByIdAsync(int id)
		{
			return await _http.GetFromJsonAsync<MunicipiDto>($"api/Municipi/{id}");
		}

		public async Task<bool> CreateMunicipiAsync(MunicipiDto municipi)
		{
			var response = await _http.PostAsJsonAsync("api/Municipi", municipi);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateMunicipiAsync(MunicipiDto municipi)
		{
			var response = await _http.PutAsJsonAsync($"api/Municipi/{municipi.ID}", municipi);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteMunicipiAsync(int id)
		{
			var response = await _http.DeleteAsync($"api/Municipi/{id}");
			return response.IsSuccessStatusCode;
		}
	}

}
