using HospitalAdmin.Data.Models;
using HospitalAdmin.Services.Interfaces;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Text.Json;

namespace HospitalAdmin.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _httpClient;

        public DoctorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DoctorModel>> GetAllDoctorsAsync()
        {
            using (var response = await _httpClient.GetAsync("doctor/search-all-doctors"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Não foi possível realizar a requisição. Por favor, contate o suporte.");

                var responseStr = await response.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<List<DoctorModel>>(responseStr, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

                return responseObj ?? new();
            }
        }

        public async Task<DoctorModel> GetDoctorByIdAsync(long doctorId)
        {
            using (var response = await _httpClient.GetAsync($"doctor/search/{doctorId}"))
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<DoctorModel>(responseStr, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return responseObj ?? new();
            }
        }

        public async Task<bool> AddDoctor(DoctorModel doctor)
        {
            using(var response = await _httpClient.PostAsync("doctor/register", new StringContent(JsonSerializer.Serialize(doctor), Encoding.UTF8, "application/json")))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdateDoctor(DoctorModel doctor)
        {
            using (var response = await _httpClient.PutAsync($"doctor/update/{doctor.Id}", new StringContent(JsonSerializer.Serialize(doctor), Encoding.UTF8, "application/json")))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteDoctor(long doctorId)
        {
            using (var response = await _httpClient.DeleteAsync($"doctor/delete/{doctorId}"))
            {
                return response.IsSuccessStatusCode;
            }
        }
    }
}
