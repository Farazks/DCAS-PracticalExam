using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Models
{
    public class EvaluationInstructorsFields
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string EstablishmentName { get; set; }
        public string Designation { get; set; }
        public string CRMRequest { get; set; }
        public string ProfessionalQualifications { get; set; }
        public string SiteName { get; set; }
        public string EvaluationDate { get; set; }
        public string Subject { get; set; }
        public bool Question1Check { get; set; }
        public bool Question1Remediation { get; set; }
        public bool Question2Check { get; set; }
        public bool Question2Remediation { get; set; }
        public bool Question3Check { get; set; }
        public bool Question3Remediation { get; set; }
        public bool Question4Check { get; set; }
        public bool Question4Remediation { get; set; }
        public bool Question5Check { get; set; }
        public bool Question5Remediation { get; set; }
        public bool Question6Check { get; set; }
        public bool Question6Remediation { get; set; }
        public bool Question7Check { get; set; }
        public bool Question7Remediation { get; set; }
        public bool Question8Check { get; set; }
        public bool Question8Remediation { get; set; }
        public string Question9Check { get; set; }
        public string Question10Check { get; set; }
        public string Comments { get; set; }
        public string Result{ get; set; }
        public string Assessor1 { get; set; }
        public Byte[] ExaminerSign { get; set; }
    }
}
