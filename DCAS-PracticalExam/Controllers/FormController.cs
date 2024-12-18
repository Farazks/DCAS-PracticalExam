using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.General;
using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using DCAS_PracticalExam.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormRepository formRepository;
        private readonly PracticalExamContext db;
        private readonly IConfiguration configuration;
        //private readonly HomeController home;
        public FormController(IFormRepository formRepository, PracticalExamContext context, IConfiguration myconfig)
        {
            this.formRepository = formRepository;
            db = context;
            configuration = myconfig;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route("AddCPRAssessment")]
        public IActionResult AddCPRAssessment()
        {
            return View();
        }

        [Route("AddCPRAssessment")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCPRAssessment(CPRAssessmentEvaluationFields data)
        {
            Notifications home = new Notifications(configuration);
            if (ModelState.IsValid)
            {
                var result = await formRepository.InsertCPREvaluation(data);

                if (result == "Success")
                {
                    TempData["Message"] = await home.Notify("Data Saved Succesfully","Success");
                    ModelState.Clear();
                    
                }
                else
                {
                    foreach (var errorMessage in result)
                    {
                        ModelState.AddModelError("", errorMessage.ToString());
                        return View(data);
                    };
                }
            }
            else
            {
                ModelState.AddModelError("", "Model State Not Valid");
            }
                return View();
        }


        [Route("RetrieveImage")]
        public IActionResult RetrieveImage()
        {
            var r = db.CPRAssessmentEvaluationFields.ToList();
            var result = r[0];
            string imageBase64Data = Convert.ToBase64String(result.Assessor1Sign);

            string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);

            ViewBag.ImageDataUrl = imageDataURL;

            return View();
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route("AddInstructorsEvaluation")]
        public IActionResult AddInstructorsEvaluation()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route("ShowCPRAssessment")]
        public async Task<IActionResult> ShowCPRAssessment()
        {
            var result = await formRepository.FetchCPREvaluation();
            return View(result);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route("ShowInstructorsEvaluation")]
        public async Task<IActionResult> ShowInstructorsEvaluation()
        {
            var result = await formRepository.FetchInstructorsEvaluation();
            return View(result);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route("ShowMedicalAssessment")]
        public async Task<IActionResult> ShowMedicalAssessment()
        {
            var result = await formRepository.FetchMedicalAssessment();
            return View(result);
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route("ShowTraumaAssessment")]
        public async Task<IActionResult> ShowTraumaAssessment()
        {
            var result = await formRepository.FetchTraumaAssessment();
            return View(result);
        }

        [HttpPost]
        [Authorize]
        [Route("AddInstructorsEvaluation")]
        public async Task<IActionResult> AddInstructorsEvaluation(EvaluationInstructorsFields data)
        {
            Notifications home = new Notifications(configuration);

            if (ModelState.IsValid)
            {
                var result = await formRepository.InsertInstructorsEvaluation(data);

                if (result == "Success")
                {
                    TempData["Message"] = await home.Notify("Data Saved Succesfully", "Success");
                    ModelState.Clear();

                }
                else
                {
                    foreach (var errorMessage in result)
                    {
                        ModelState.AddModelError("", errorMessage.ToString());
                        return View(data);
                    };
                }
            }
            else
            {
                ModelState.AddModelError("", "Model State Not Valid");
            }
            return View();
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route("AddMedicalAssessment")]
        public IActionResult AddMedicalAssessment()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("AddMedicalAssessment")]
        public async Task<IActionResult> AddMedicalAssessment(MedicalAssessmentEvaluationFields data)
        {
            Notifications home = new Notifications(configuration);
            if (ModelState.IsValid)
            {
                var result = await formRepository.InsertMedicalAssessment(data);

                if (result == "Success")
                {
                    TempData["Message"] = await home.Notify("Data Saved Succesfully", "Success");
                    ModelState.Clear();

                }
                else
                {
                    foreach (var errorMessage in result)
                    {
                        ModelState.AddModelError("", errorMessage.ToString());
                        return View(data);
                    };
                }
            }
            else
            {
                ModelState.AddModelError("", "Model State Not Valid");
            }
            return View();
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [Route("AddTraumaAssessment")]
        public IActionResult AddTraumaAssessment()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("AddTraumaAssessment")]
        public async Task<IActionResult> AddTraumaAssessment(TraumaAssessmentEvaluationFields data)
        {
            Notifications home = new Notifications(configuration);
            if (ModelState.IsValid)
            {
                var result = await formRepository.InsertTraumaAssessment(data);

                if (result == "Success")
                {
                    TempData["Message"] = await home.Notify("Data Saved Succesfully", "Success");
                    ModelState.Clear();
                }
                else
                {
                    foreach (var errorMessage in result)
                    {
                        ModelState.AddModelError("", errorMessage.ToString());
                        return View(data);
                    };
                }
            }
            else
            {
                ModelState.AddModelError("", "Model State Not Valid");
            }
            return View();
        }

        public async Task<IActionResult> ViewCPRReport(int id)
        {
            Notifications home = new Notifications(configuration);

            var result = await formRepository.ViewCPRReportByID(id);

            if (result != null)
            {
                string Assessor1Sign = string.Empty;
                string Assessor2Sign = string.Empty;

                if (result.Assessor1Sign != null)
                {
                    string Assessor1 = Convert.ToBase64String(result.Assessor1Sign);
                    Assessor1Sign = string.Format("data:image/jpg;base64,{0}", Assessor1);
                }

                if (result.Assessor2Sign != null)
                {
                    string Assessor2 = Convert.ToBase64String(result.Assessor2Sign);
                    Assessor2Sign = string.Format("data:image/jpg;base64,{0}", Assessor2);
                }

                ViewBag.Sign1 = Assessor1Sign;
                ViewBag.Sign2 = Assessor2Sign;
                return View(result);
            }

            TempData["Message"] = await home.Notify("No Report Found With Report-ID : " + id, "Not Found", NotificationType.error);
            return View(result);
        }

        public async Task<IActionResult> ViewInstuctionReport(int id)
        {
            Notifications home = new Notifications(configuration);
            
            var result = await formRepository.ViewInstructionReportByID(id);
            if(result != null)
            {
                string Assessor1 = Convert.ToBase64String(result.ExaminerSign);
                string Assessor1Sign = string.Format("data:image/jpg;base64,{0}", Assessor1);

                ViewBag.Sign1 = Assessor1Sign;
                return View(result);
            }

            TempData["Message"] = await home.Notify("No Report Found With Report-ID : "+id, "Not Found",NotificationType.error);
            return View(result);     
        }

        public async Task<IActionResult> ViewMedicalReport(int id)
        {
            Notifications home = new Notifications(configuration);

            var result = await formRepository.ViewMedicalAssessmentReportByID(id);
            
            if(result != null)
            {
                string Assessor1 = Convert.ToBase64String(result.Assessor1Sign);
                string Assessor1Sign = string.Format("data:image/jpg;base64,{0}", Assessor1);

                string Assessor2 = Convert.ToBase64String(result.Assessor2Sign);
                string Assessor2Sign = string.Format("data:image/jpg;base64,{0}", Assessor2);

                ViewBag.Sign1 = Assessor1Sign;
                ViewBag.Sign2 = Assessor2Sign;
                return View(result);
            }

            TempData["Message"] = await home.Notify("No Report Found With Report-ID : " + id, "Not Found", NotificationType.error);
            return View(result);
        }

        public async Task<IActionResult> ViewTraumaReport(int id)
        {
            Notifications home = new Notifications(configuration);

            var result = await formRepository.ViewTraumaAssessmentReportByID(id);

            if(result != null)
            {
                string Assessor1 = Convert.ToBase64String(result.Assessor1Sign);
                string Assessor1Sign = string.Format("data:image/jpg;base64,{0}", Assessor1);

                string Assessor2 = Convert.ToBase64String(result.Assessor2Sign);
                string Assessor2Sign = string.Format("data:image/jpg;base64,{0}", Assessor2);

                ViewBag.Sign1 = Assessor1Sign;
                ViewBag.Sign2 = Assessor2Sign;
                return View(result);
            }

            TempData["Message"] = await home.Notify("No Report Found With Report-ID : " + id, "Not Found", NotificationType.error);
            return View(result);
        }

    }
}
