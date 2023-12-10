using HospitalAdmin.Data.Models;

namespace HospitalAdmin.Services.Interfaces
{
    public interface ISchedulingService
    {
        Task<List<SchedulingModel>> GetAllSchedulingsAsync();
        Task<SchedulingModel> GetSchedulingByIdAsync(long schedulingId);
        Task<bool> AddScheduling(SchedulingModel scheduling);
        Task<bool> UpdateScheduling(SchedulingModel scheduling);
        Task<bool> DeleteScheduling(long schedulingId);
    }
}
