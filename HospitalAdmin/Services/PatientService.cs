using HospitalAdmin.Data.Models;
using System.Text.Json;
using System.Text;
using HospitalAdmin.Services.Interfaces;

namespace HospitalAdmin.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PatientModel>> GetAllPatientsAsync()
        {
            using (var response = await _httpClient.GetAsync("patient/search-all-patients"))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Não foi possível realizar a requisição. Por favor, contate o suporte.");

                var responseStr = await response.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<List<PatientModel>>(responseStr, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return responseObj ?? new();
            }
        }

        public async Task<PatientModel> GetPatientByIdAsync(long patientId)
        {
            using (var response = await _httpClient.GetAsync($"patient/search/{patientId}"))
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<PatientModel>(responseStr, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return responseObj ?? new();
            }
        }

        public async Task<bool> AddPatient(PatientModel patient)
        {
            using (var response = await _httpClient.PostAsync("patient/register", new StringContent(JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json")))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdatePatient(PatientModel patient)
        {
            using (var response = await _httpClient.PutAsync($"patient/update/{patient.Id}", new StringContent(JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json")))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeletePatient(long patientId)
        {
            using (var response = await _httpClient.DeleteAsync($"patient/delete/{patientId}"))
            {
                return response.IsSuccessStatusCode;
            }
        }
    }
}
