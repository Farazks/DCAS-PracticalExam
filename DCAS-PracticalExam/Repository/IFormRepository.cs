using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Repository
{
    public interface IFormRepository
    {
        Task<string> InsertCPREvaluation(CPRAssessmentEvaluationFields data);
        Task<string> InsertInstructorsEvaluation(EvaluationInstructorsFields data);
        Task<string> InsertMedicalAssessment(MedicalAssessmentEvaluationFields data);
        Task<string> InsertTraumaAssessment(TraumaAssessmentEvaluationFields data);
        Task<List<EvaluationResult>> FetchCPREvaluation();
        Task<List<EvaluationResult>> FetchTraumaAssessment();
        Task<List<EvaluationResult>> FetchInstructorsEvaluation();
        Task<List<EvaluationResult>> FetchMedicalAssessment();
        Task<EvaluationInstructorsFields> ViewInstructionReportByID(int reportID);
        Task<CPRAssessmentEvaluationFields> ViewCPRReportByID(int reportID);
        Task<MedicalAssessmentEvaluationFields> ViewMedicalAssessmentReportByID(int reportID);
        Task<TraumaAssessmentEvaluationFields> ViewTraumaAssessmentReportByID(int reportID);

    }
}