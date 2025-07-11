using DCAS_PracticalExam.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCAS_PracticalExam.Models
{
    public class Otp
    {
        public int Id { get; set; }

        public string FK_AppUserId { get; set; }
        [ForeignKey("FK_AppUserId")]

        public ApplicationUser applicationUsers { get; set; }
        [Required]
        public string Code { get; set; } = default!;

        [Required]
        public bool IsExpired { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UsedAt { get; set; }

    }
}
