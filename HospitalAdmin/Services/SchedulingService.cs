using HospitalAdmin.Data.Models;
using HospitalAdmin.Services.Interfaces;

namespace HospitalAdmin.Services
{
    public class SchedulingService : ISchedulingService
    {
        public Task<bool> AddScheduling(SchedulingModel scheduling)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteScheduling(long schedulingId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SchedulingModel>> GetAllSchedulingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SchedulingModel> GetSchedulingByIdAsync(long schedulingId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateScheduling(SchedulingModel scheduling)
        {
            throw new NotImplementedException();
        }
    }
}
