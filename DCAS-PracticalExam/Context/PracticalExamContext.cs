using DCAS_PracticalExam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Context
{
    public class PracticalExamContext : IdentityDbContext<ApplicationUser>
    {
        public PracticalExamContext(DbContextOptions<PracticalExamContext> options) : base(options) 
        {

        }

        public DbSet<CPRAssessmentEvaluationFields> CPRAssessmentEvaluationFields { get; set; }
        public DbSet<TraumaAssessmentEvaluationFields> TraumaAssessmentEvaluationFields { get; set; }
        public DbSet<MedicalAssessmentEvaluationFields> MedicalAssessmentEvaluationFields { get; set; }
        public DbSet<EvaluationInstructorsFields> EvaluationInstructorsFields { get; set; }
        public DbSet<Otp> Otps { get; set; }
    }
}
