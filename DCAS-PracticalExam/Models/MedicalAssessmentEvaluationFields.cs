using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Models
{
    public class MedicalAssessmentEvaluationFields
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
        public bool CriteriaCheck1 { get; set; }
        public bool CriteriaCheck2 { get; set; }
        public bool CriteriaCheck3 { get; set; }
        public bool CriteriaCheck4 { get; set; }
        public bool CriteriaCheck5 { get; set; }
        public bool CriteriaCheck6 { get; set; }
        //new colum strat
        public bool RespiRespiratory1 { get; set; }
        public bool RespiRespiratory2 { get; set; }
        public bool RespiRespiratory3 { get; set; }
        public bool RespiRespiratory4 { get; set; }
        public bool RespiRespiratory5 { get; set; }
        public bool RespiRespiratory6 { get; set; }
        public bool RespiRespiratory7 { get; set; }

        public bool Cardiac1 { get; set; }
        public bool Cardiac2 { get; set; }
        public bool Cardiac3 { get; set; }
        public bool Cardiac4 { get; set; }
        public bool Cardiac5 { get; set; }
        public bool Cardiac6 { get; set; }
        public bool Cardiac7 { get; set; }

        public bool AlteredMental1  { get; set; }
        public bool AlteredMental2  { get; set; }
        public bool AlteredMental3  { get; set; }
        public bool AlteredMental4  { get; set; }
        public bool AlteredMental5  { get; set; }
        public bool AlteredMental6  { get; set; }
        public bool AlteredMental7  { get; set; }
        public bool AlteredMental8  { get; set; }

        public bool AllergicReaction1  { get; set; }
        public bool AllergicReaction2  { get; set; }
        public bool AllergicReaction3  { get; set; }
        public bool AllergicReaction4  { get; set; }
        public bool AllergicReaction5  { get; set; }
        public bool AllergicReaction6  { get; set; }

        public bool PoisoningOverdose1  { get; set; }
        public bool PoisoningOverdose2  { get; set; }
        public bool PoisoningOverdose3  { get; set; }
        public bool PoisoningOverdose4  { get; set; }
        public bool PoisoningOverdose5  { get; set; }
        public bool PoisoningOverdose6  { get; set; }
        public bool PoisoningOverdose7  { get; set; }

        public bool EnvironmentalEmergency1  { get; set; }
        public bool EnvironmentalEmergency2  { get; set; }
        public bool EnvironmentalEmergency3  { get; set; }
        public bool EnvironmentalEmergency4  { get; set; }
        public bool EnvironmentalEmergency5  { get; set; }

        public bool Obstetrics1 { get; set; }
        public bool Obstetrics2 { get; set; }
        public bool Obstetrics3 { get; set; }
        public bool Obstetrics4 { get; set; }
        public bool Obstetrics5 { get; set; }
        public bool Obstetrics6 { get; set; }
        public bool Obstetrics7 { get; set; }

        public bool Behavioral1 { get; set; }
        public bool Behavioral2 { get; set; }
        public bool Behavioral3 { get; set; }
        public bool Behavioral4 { get; set; }
        public bool Behavioral5 { get; set; }

        //new colum ends
        public string Assessor { get; set; }
        public string Monitor { get; set; }
        public string Comments { get; set; }
        public string Result { get; set; }
        public Byte[] AssessorSign { get; set; }
        public Byte[] MonitorSign { get; set; }
    }
}
