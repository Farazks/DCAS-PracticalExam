using System.ComponentModel.DataAnnotations;

namespace DCAS_PracticalExam.Helper_Model
{
    public class VerifyOTP
    {
        [Required]
        [Display(Name = "OTP")]
        [MaxLength(6)]
        public string Otp { get; set; } = default!;

        public string employeeId { get; set; } = default!;
    }
}
