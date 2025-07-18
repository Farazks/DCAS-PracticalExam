using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Repository
{
    public class FormRepository : IFormRepository
    {
        private readonly PracticalExamContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FormRepository(PracticalExamContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            _userManager = userManager;
        }

        public async Task<string> InsertCPREvaluation(CPRAssessmentEvaluationFields data)
        {
            try
            {
                db.CPRAssessmentEvaluationFields.Add(data);
                db.SaveChanges();

                return "Success";
            }

            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> InsertInstructorsEvaluation(EvaluationInstructorsFields data)
        {
            try
            {
                db.EvaluationInstructorsFields.Add(data);
                db.SaveChanges();

                return "Success";
            }

            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> InsertMedicalAssessment(MedicalAssessmentEvaluationFields data)
        {
            try
            {
                db.MedicalAssessmentEvaluationFields.Add(data);
                db.SaveChanges();

                return "Success";
            }

            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> InsertTraumaAssessment(TraumaAssessmentEvaluationFields data)
        {
            try
            {
                db.TraumaAssessmentEvaluationFields.Add(data);
                db.SaveChanges();

                return "Success";
            }

            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<List<EvaluationResult>> FetchCPREvaluation()
        {
            try
            {
                var result = await db.CPRAssessmentEvaluationFields.Select(x => new EvaluationResult
                {
                    ID = x.ID,
                    //CandidateName = x.CandidateName,
                    CRMRequest = x.CRMRequest,
                    Result = x.Result,
                    TestDate = x.TestDate,
                }).ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<EvaluationResult>> FetchInstructorsEvaluation()
        {
            try
            {
                var result = await db.EvaluationInstructorsFields.Select(x => new EvaluationResult
                {
                    ID = x.ID,
                    //CandidateName = x.Name,
                    CRMRequest = x.CRMRequest,
                    Result = x.Result,
                    TestDate = x.EvaluationDate,
                }).ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<EvaluationResult>> FetchMedicalAssessment()
        {
            try
            {
                var result = await db.MedicalAssessmentEvaluationFields.Select(x => new EvaluationResult
                {
                    ID = x.ID,
                    //CandidateName = x.CandidateName,
                    CRMRequest = x.CRMRequest,
                    Result = x.Result,
                    TestDate = x.TestDate,
                }).ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<EvaluationResult>> FetchTraumaAssessment()
        {
            try
            {
                var result = await db.TraumaAssessmentEvaluationFields.Select(x => new EvaluationResult
                {
                    ID = x.ID,
                    //CandidateName = x.CandidateName,
                    CRMRequest = x.CRMRequest,
                    Result = x.Result,
                    TestDate = x.TestDate,
                }).ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<EvaluationInstructorsFields> ViewInstructionReportByID(int reportID)
        {
            try
            {
                var result = db.EvaluationInstructorsFields.Where(x => x.ID == reportID).FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<CPRAssessmentEvaluationFields> ViewCPRReportByID(int reportID)
        {
            try
            {
                var result = db.CPRAssessmentEvaluationFields.Where(x => x.ID == reportID).FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<MedicalAssessmentEvaluationFields> ViewMedicalAssessmentReportByID(int reportID)
        {
            try
            {
                var result = db.MedicalAssessmentEvaluationFields.Where(x => x.ID == reportID).FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<TraumaAssessmentEvaluationFields> ViewTraumaAssessmentReportByID(int reportID)
        {
            try
            {
                var result = db.TraumaAssessmentEvaluationFields.Where(x => x.ID == reportID).FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<ApplicationUser> getById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
    }

}
