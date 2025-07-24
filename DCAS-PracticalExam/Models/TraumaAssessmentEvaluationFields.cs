using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Models
{
    public class TraumaAssessmentEvaluationFields
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
        public bool PointsStep11 { get; set; }
        public bool PointsStep12 { get; set; }
        public bool PointsStep13 { get; set; }
        public bool PointsStep14 { get; set; }
        public bool PointsStep15 { get; set; }
        public bool PointsStep16 { get; set; }
        public bool PointsStep17 { get; set; }
        public bool PointsStep18 { get; set; }
        public bool PointsStep19 { get; set; }
        public bool PointsStep20 { get; set; }
        public bool PointsStep21 { get; set; }
        public bool PointsStep22 { get; set; }
        public bool PointsStep23 { get; set; }
        public bool PointsStep24 { get; set; }
        public bool PointsStep25 { get; set; }
        public bool PointsStep26 { get; set; }
        public bool PointsStep27 { get; set; }
        public bool PointsStep28 { get; set; }
        public bool PointsStep29 { get; set; }
        public bool PointsStep30 { get; set; }
        public bool PointsStep31 { get; set; }
        public bool PointsStep32 { get; set; }
        public bool PointsStep33 { get; set; }
        public bool PointsStep34 { get; set; }
        public bool PointsStep35 { get; set; }
        public bool PointsStep36 { get; set; }
        public bool PointsStep37 { get; set; }
        public bool PointsStep38 { get; set; }
        public bool PointsStep39 { get; set; }
        public bool PointsStep40 { get; set; }
        public bool CriteriaCheck1 { get; set; }
        public bool CriteriaCheck2 { get; set; }
        public bool CriteriaCheck3 { get; set; }
        public bool CriteriaCheck4 { get; set; }
        public bool CriteriaCheck5 { get; set; }
        public bool CriteriaCheck6 { get; set; }
        public bool CriteriaCheck7 { get; set; }
        public bool CriteriaCheck8 { get; set; }
        public string Assessor { get; set; }
        public string Monitor { get; set; }
        public string Comments { get; set; }
        public string Result { get; set; }
        public Byte[] AssessorSign { get; set; }
        public Byte[] MonitorSign { get; set; }
    }
}
