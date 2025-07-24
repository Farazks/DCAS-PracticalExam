using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DCAS_PracticalExam.Models
{
    public class CPRAssessmentEvaluationFields
    {
        [Key]
        public int ID { get; set; }
        public string CandidateName { get; set; }
        public string EstablishmentName { get; set; }
        public string Designation { get; set; }
        public string CRMRequest { get; set; }
        public string TestDate { get; set; }
        public bool PointsStep1 { get; set; }
        public bool PointsStep2 { get; set; }
        public bool PointsStep3 { get; set; }
        public bool PointsStep4 { get; set; }
        public bool PointsStep5 { get; set; }
        public bool PointsStep6 { get; set; }
        public bool PointsStep7 { get; set; }
        public bool PointsStep8 { get; set; }
        public bool PointsStep9 { get; set; }
        public bool PointsStep10 { get; set; }
        public string Assessor { get; set; }
        public string Monitor { get; set; }
        public string Comments { get; set; }
        public string Result { get; set; }
        public Byte[] AssessorSign { get; set; }
        public Byte[] MonitorSign { get; set; }

    }
}
