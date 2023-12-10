using HospitalAdmin.Data.Models;
using HospitalAdmin.Services.Interfaces;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace HospitalAdmin.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly HttpClient _httpClient;

        public SchedulingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddScheduling(SchedulingModel scheduling)
        {
            using (var response = await _httpClient.PostAsync("scheduling/register", new StringContent(JsonSerializer.Serialize(scheduling), Encoding.UTF8, "application/json")))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteScheduling(long schedulingId)
        {
            using (var response = await _httpClient.DeleteAsync($"scheduling/delete/{schedulingId}"))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<List<SchedulingModel>> GetAllSchedulingsAsync()
        {
            using (var response = await _httpClient.GetAsync("scheduling/search-all-schedulings"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Não foi possível realizar a requisição. Por favor, contate o suporte.");

                var responseStr = await response.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<List<SchedulingModel>>(responseStr, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return responseObj ?? new();
            }
        }

        public async Task<SchedulingModel> GetSchedulingByIdAsync(long schedulingId)
        {
            using (var response = await _httpClient.GetAsync($"scheduling/search/{schedulingId}"))
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<SchedulingModel>(responseStr, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return responseObj ?? new();
            }
        }

        public async Task<bool> UpdateScheduling(SchedulingModel scheduling)
        {
            using (var response = await _httpClient.PutAsync($"scheduling/update/{scheduling.Id}", new StringContent(JsonSerializer.Serialize(scheduling), Encoding.UTF8, "application/json")))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> ConfirmScheduling(long schedulingId)
        {
            using (var response = await _httpClient.PutAsync($"scheduling/confirm/{schedulingId}", null))
            {
                return response.IsSuccessStatusCode;
            }
        }
    }
}
