using HospitalAdmin.Data.Models;

namespace HospitalAdmin.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientModel>> GetAllPatientsAsync();
        Task<PatientModel> GetPatientByIdAsync(long patientId);
        Task<bool> AddPatient(PatientModel patient);
        Task<bool> UpdatePatient(PatientModel patient);
        Task<bool> DeletePatient(long patientId);
    }
}
