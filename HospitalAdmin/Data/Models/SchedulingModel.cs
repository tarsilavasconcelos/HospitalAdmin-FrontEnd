namespace HospitalAdmin.Data.Models
{
    public class SchedulingModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int DoctorId { get; set; }
        public DoctorModel? Doctor { get; set; }
        public int PatientId { get; set; }
        public PatientModel? Patient { get; set; }
        public DateTime? SchedulingDate { get; set; }
        public string? StatusId { get; set; }
    }
}
