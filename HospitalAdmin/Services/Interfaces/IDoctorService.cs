using HospitalAdmin.Data.Models;

namespace HospitalAdmin.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<DoctorModel>> GetAllDoctorsAsync();
        Task<DoctorModel> GetDoctorByIdAsync(long doctorId);
        Task<bool> AddDoctor(DoctorModel doctor);
        Task<bool> UpdateDoctor(DoctorModel doctor);
        Task<bool> DeleteDoctor(long doctorId);
    }
}
