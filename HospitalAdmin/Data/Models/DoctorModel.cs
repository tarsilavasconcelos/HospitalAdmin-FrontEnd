using System.ComponentModel.DataAnnotations;

namespace HospitalAdmin.Data.Models
{
    public class DoctorModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome do médico para continuar")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "É necessário informar o email do médico para continuar")]
        public string? Email { get; set; }
    }
}
