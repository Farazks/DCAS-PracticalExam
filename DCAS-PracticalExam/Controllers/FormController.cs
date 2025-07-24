﻿using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.DTOs;
using DCAS_PracticalExam.General;
using DCAS_PracticalExam.Helper_Model;
using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using DCAS_PracticalExam.Repository;
using DCAS_PracticalExam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        private readonly ILogger<FormController> _logger;
        private readonly IConfiguration _config;
        private readonly MailSender emailSender;
        private readonly IApiService _apiService;

        //private readonly HomeController home;
        public FormController(IFormRepository formRepository, PracticalExamContext context, ILogger<FormController> logger, IConfiguration config, IOptions<SmtpConfig> smtpConfigModel, IApiService apiService)
        {
            this.formRepository = formRepository;
            db = context;
            configuration = config;
            _logger = logger;
            _config = config;
            emailSender = new MailSender(smtpConfigModel);
            _apiService = apiService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
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
            _logger.LogInformation("AddInstructorsEvaluation started.");
            Notifications home = new Notifications(configuration);


            if (ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is valid.");
                var result = await formRepository.InsertCPREvaluation(data);
                _logger.LogInformation("InsertInstructorsEvaluation returned: {Result}", result);

                if (result == "Success")
                {
                    try
                    {
                        _logger.LogInformation("Calling UpdateLicenseResultAsync with CRMRequest: {CRMRequest}, Result: {Result}", data.CRMRequest, data.Result);
                        //this work for api consume code 
                        var crmResponse = await UpdateLicenseResultAsync(data.CRMRequest, data.Result);
                        _logger.LogInformation("UpdateLicenseResultAsync returned: {CrmResponse}", crmResponse);

                        if (crmResponse.Contains("Success"))
                    {

                        TempData["Message"] = await home.Notify("Result is Updated Successfully.", "Success");
                        _logger.LogInformation("Result updated successfully.");

                        }
                        else
                    {
                        TempData["Message"] = await home.Notify(crmResponse, "Error", NotificationType.error);
                        _logger.LogWarning("CRM response error: {CrmResponse}", crmResponse);

                        }
                        ModelState.Clear();    
                }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Exception occurred during UpdateLicenseResultAsync.");
                        TempData["Message"] = await home.Notify(ex.Message, "Error", NotificationType.error);
                    }
                }
                else
                {
                    _logger.LogWarning("InsertInstructorsEvaluation did not return success. Result: {Result}", result);
                    foreach (var errorMessage in result)
                    {
                        ModelState.AddModelError("", errorMessage.ToString());
                        _logger.LogWarning("ModelError added: {ErrorMessage}", errorMessage.ToString());
                        return View(data);
                    };
                }
            }
            else
            {
                _logger.LogWarning("ModelState is invalid.");
                ModelState.AddModelError("", "Model State Not Valid");
            }
            _logger.LogInformation("Returning view from AddInstructorsEvaluation.");
            return View();
        }


        [Route("RetrieveImage")]
        public IActionResult RetrieveImage()
        {
            var r = db.CPRAssessmentEvaluationFields.ToList();
            var result = r[0];
            string imageBase64Data = Convert.ToBase64String(result.AssessorSign);

            string imageDataURL = string.Format("data:image/jpg;base64,{0}",imageBase64Data);

            ViewBag.ImageDataUrl = imageDataURL;

            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [Route("AddInstructorsEvaluation")]
        public IActionResult AddInstructorsEvaluation()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [Route("ShowCPRAssessment")]
        public async Task<IActionResult> ShowCPRAssessment()
        {
            var result = await formRepository.FetchCPREvaluation();
            return View(result);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [Route("ShowInstructorsEvaluation")]
        public async Task<IActionResult> ShowInstructorsEvaluation()
        {
            var result = await formRepository.FetchInstructorsEvaluation();
            return View(result);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [Route("ShowMedicalAssessment")]
        public async Task<IActionResult> ShowMedicalAssessment()
        {
            var result = await formRepository.FetchMedicalAssessment();
            return View(result);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
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
            _logger.LogInformation("AddInstructorsEvaluation started.");
               Notifications home = new Notifications(configuration);

            if (ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is valid.");
                var result = await formRepository.InsertInstructorsEvaluation(data);
                _logger.LogInformation("InsertInstructorsEvaluation returned: {Result}", result);

                if (result == "Success")
                {
                    try
                    {
                        _logger.LogInformation("Calling UpdateLicenseResultAsync with CRMRequest: {CRMRequest}, Result: {Result}", data.CRMRequest, data.Result);

                        //this work for api consume code 
                        var crmResponse = await UpdateLicenseResultAsync(data.CRMRequest, data.Result);
                        _logger.LogInformation("UpdateLicenseResultAsync returned: {CrmResponse}", crmResponse);
                       
                        
                        if (crmResponse.Contains("Success"))
                        {
                            TempData["Message"] = await home.Notify("Result is Updated Successfully.", "Success");
                            _logger.LogInformation("Result updated successfully.");
                        }
                        else
                        {
                            TempData["Message"] = await home.Notify(crmResponse, "Error", NotificationType.error);
                            _logger.LogWarning("CRM response error: {CrmResponse}", crmResponse);
                        }


                        ModelState.Clear();
                    }
                    catch (Exception ex) 
                    {
                        _logger.LogError(ex, "Exception occurred during UpdateLicenseResultAsync.");
                        TempData["Message"] = await home.Notify(ex.Message, "Error", NotificationType.error);
                    }

                }
                else
                {
                    _logger.LogWarning("InsertInstructorsEvaluation did not return success. Result: {Result}", result);
                    foreach (var errorMessage in result)
                    {
                        ModelState.AddModelError("", errorMessage.ToString());
                        _logger.LogWarning("ModelError added: {ErrorMessage}", errorMessage.ToString());
                        return View(data);
                    };
                }
            }
            else
            {
                _logger.LogWarning("ModelState is invalid.");
                ModelState.AddModelError("", "Model State Not Valid");
            }
            _logger.LogInformation("Returning view from AddInstructorsEvaluation.");
            return View();
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
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
            _logger.LogInformation("AddInstructorsEvaluation started.");
            Notifications home = new Notifications(configuration);
            if (ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is valid.");
                var result = await formRepository.InsertMedicalAssessment(data);
                _logger.LogInformation("InsertInstructorsEvaluation returned: {Result}", result);

                if (result == "Success")
                {
                    try
                    {
                        _logger.LogInformation("Calling UpdateLicenseResultAsync with CRMRequest: {CRMRequest}, Result: {Result}", data.CRMRequest, data.Result);
                        //this work for API consume Code
                        var crmResponse = await UpdateLicenseResultAsync(data.CRMRequest, data.Result);
                        _logger.LogInformation("UpdateLicenseResultAsync returned: {CrmResponse}", crmResponse);
                       
                    if (crmResponse.Contains("Success"))
                    {
                        TempData["Message"] = await home.Notify("Result is Updated Successfully.", "Success");
                        _logger.LogInformation("Result updated successfully.");
                        }
                        else 
                    {
                        TempData["Message"] = await home.Notify(crmResponse, "Error", NotificationType.error);
                        _logger.LogWarning("CRM response error: {CrmResponse}", crmResponse);

                        }
                        ModelState.Clear();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Exception occurred during UpdateLicenseResultAsync.");
                        TempData["Message"] = await home.Notify(ex.Message, "Error", NotificationType.error);
                    }
                }
                else
                {
                    _logger.LogWarning("InsertInstructorsEvaluation did not return success. Result: {Result}", result);
                    foreach (var errorMessage in result)
                    {
                        ModelState.AddModelError("", errorMessage.ToString());
                        _logger.LogWarning("ModelError added: {ErrorMessage}", errorMessage.ToString());
                        return View(data);
                    }
                }
            }
            else
            {
                _logger.LogWarning("ModelState is invalid.");
                ModelState.AddModelError("", "Model State Not Valid");
            }
            _logger.LogInformation("Returning view from AddInstructorsEvaluation.");
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
            _logger.LogInformation("AddInstructorsEvaluation started.");
            Notifications home = new Notifications(configuration);


            if (ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is valid.");
                var result = await formRepository.InsertTraumaAssessment(data);
                _logger.LogInformation("InsertInstructorsEvaluation returned: {Result}", result);

                if (result == "Success")
                {
                    try
                    {
                        _logger.LogInformation("Calling UpdateLicenseResultAsync with CRMRequest: {CRMRequest}, Result: {Result}", data.CRMRequest, data.Result);

                        //this work for API consume code 
                        var crmResponse = await UpdateLicenseResultAsync(data.CRMRequest, data.Result);
                        _logger.LogInformation("UpdateLicenseResultAsync returned: {CrmResponse}", crmResponse);

                   if (crmResponse.Contains("Success"))
                    {
                        TempData["Message"] = await home.Notify("Result is Updated Successfully.", "Success");
                        _logger.LogInformation("Result updated successfully.");

                    }
                    else
                    {
                        TempData["Message"] = await home.Notify(crmResponse, "Error", NotificationType.error);
                        _logger.LogWarning("CRM response error: {CrmResponse}", crmResponse);

                        }
                        ModelState.Clear();
                }
                catch (Exception ex)
                    {
                        _logger.LogError(ex, "Exception occurred during UpdateLicenseResultAsync.");
                        TempData["Message"] = await home.Notify(ex.Message, "Error", NotificationType.error);
                    }
                }
                else
                {
                    _logger.LogWarning("InsertInstructorsEvaluation did not return success. Result: {Result}", result);
                    foreach (var errorMessage in result)
                    {
                        ModelState.AddModelError("", errorMessage.ToString());
                        _logger.LogWarning("ModelError added: {ErrorMessage}", errorMessage.ToString());
                        return View(data);
                    }
                }
            }
            else
            {
                _logger.LogWarning("ModelState is invalid.");
                ModelState.AddModelError("", "Model State Not Valid");
            }
            _logger.LogInformation("Returning view from AddInstructorsEvaluation.");
            return View();
        }

        public async Task<IActionResult> ViewCPRReport(int id)
        {
            Notifications home = new Notifications(configuration);

            var result = await formRepository.ViewCPRReportByID(id);
            
            if(result != null)
            {
                string Assessor1 = Convert.ToBase64String(result.AssessorSign);
                string Assessor1Sign = string.Format("data:image/jpg;base64,{0}", Assessor1);

                string Assessor2 = Convert.ToBase64String(result.MonitorSign);
                string Assessor2Sign = string.Format("data:image/jpg;base64,{0}", Assessor2);

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
                string Assessor1 = Convert.ToBase64String(result.AssessorSign);
                string Assessor1Sign = string.Format("data:image/jpg;base64,{0}", Assessor1);

                string Assessor2 = Convert.ToBase64String(result.MonitorSign);
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
                string Assessor1 = Convert.ToBase64String(result.AssessorSign);
                string Assessor1Sign = string.Format("data:image/jpg;base64,{0}", Assessor1);

                string Assessor2 = Convert.ToBase64String(result.MonitorSign);
                string Assessor2Sign = string.Format("data:image/jpg;base64,{0}", Assessor2);

                ViewBag.Sign1 = Assessor1Sign;
                ViewBag.Sign2 = Assessor2Sign;
                return View(result);
            }

            TempData["Message"] = await home.Notify("No Report Found With Report-ID : " + id, "Not Found", NotificationType.error);
            return View(result);
        }


        public async Task<IActionResult> GenerateOtp()
        {
            string otp = OtpGenerator.GenerateOTP();
            string AppId = Request.Query["AppId"];
            var uInfo = db.Users.Where(s => s.Id == AppId).FirstOrDefault();

            if (uInfo == null)
            {
                TempData["errMsg"] = "User not found.";
                return RedirectToAction("Index");
            }

            // Format the phone number
            string phone = uInfo.PhoneNumber;
            if (!string.IsNullOrEmpty(phone))
            {
                if (phone.StartsWith("+971"))
                    phone = phone.Replace("+971", "");
                else if (phone.StartsWith("971"))
                    phone = phone.Replace("971", "");

                if (!phone.StartsWith("0"))
                    phone = "0" + phone;
            }

            Otp createOTP = new Otp
            {
                Code = otp,
                FK_AppUserId = AppId
            };

            await db.Otps.AddAsync(createOTP);

            var saveSuccessful = await db.SaveChangesAsync();

            if (saveSuccessful > 0)
            {

                //var msg = await EmailService.SendAsync(new()
                //{
                //    subject = "Verification OTP",
                //    recipients = new()
                //        {
                //        uInfo.Email
                //    },
                //    body = $"Dear {uInfo.FirstName + " " +uInfo.LastName } <br>" +
                //             $"Your OTP is: {otp} <br>" +
                //             $"Thank You <br> " +
                //             $"Dubai Corporation for Ambulance Services"
                //}, _logger);
                var body = $"Dear {uInfo.FirstName + " " + uInfo.LastName} <br>" +
                             $"Your OTP is: {otp}<br>" +
                             $"Thank You <br> " +
                             $"Dubai Corporation for Ambulance Services";

                EmailOptions ops = new EmailOptions
                {
                    toEmail = uInfo.Email,
                    subject = "Verification OTP",
                    body = body
                };

                string message = await emailSender.SendEmailPublic(ops);
                SmsDto sms = new SmsDto()
                {
                    _message = $"Dear {uInfo.FirstName + " " + uInfo.LastName}\n" +
                   $"Your OTP is: {otp}\n" +
                   $"Thank You \n " +
                   $"Dubai Corporation for Ambulance Services",
                    _mobileNo = phone
                };

                SmsService.Send(_config, sms);
                 
                return RedirectToAction("VerifyOTP", new { AppId = uInfo.Id });
            }
            else
            {
                TempData["errMsg"] = "Data is not Successfully Submitted";
                return RedirectToAction("Index");
            }
        }

        


        [HttpGet]
        public ActionResult VerifyOTP()
        {
            string employeeId = Request.Query["AppId"];

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                return RedirectToAction("VerifyOTP", "Form");
            }

            var user = db.Users.FirstOrDefault(u => u.Id == employeeId);
            if (user == null) 
            {
                TempData["errMsg"] = "User not found!";
                return RedirectToAction("Index");
            }

            //Mask the mobile number and email 
            //var maskedNumber = user.PhoneNumber;
            //if (!string.IsNullOrEmpty(maskedNumber) && maskedNumber.Length >= 7)
            //{
            //    maskedNumber = maskedNumber.Substring(0, 5) + "*****" + maskedNumber[^2..];
            //}
            //string email = user.Email;
            //var atIndex = email.IndexOf("@");
            //string maskedEmail = email;

            //if (atIndex > 3) 
            //{ 
            //    maskedEmail = email.Substring(0, 3) + "****" + email.Substring(atIndex);
            //}
            var model = new VerifyOTP
            {
                employeeId = employeeId,
                Email = user.Email,
                MobileNumber = user.PhoneNumber
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> VerifyOtp(VerifyOTP model)
        {
            // _logger.LogInformation($"\n{DateTime.Now} : Starting Verify OTP Method\n");
            if (!ModelState.IsValid)
            {
                // _logger.LogError($"\n{DateTime.Now} Invalid Entry : {JsonConvert.SerializeObject(model)}\n");

                TempData["errMsg"] = $"Please validate all fields";
                ModelState.AddModelError("", "Please validate all fields");
                return View(model);
            }

            var isOtpValid = await db.Otps.Include(x => x.applicationUsers).FirstOrDefaultAsync(x => x.Code == model.Otp && x.applicationUsers.Id == model.employeeId);

            if (isOtpValid is not null)
            {
                if (!isOtpValid.IsExpired)
                {

                    var userOtp = isOtpValid.applicationUsers.Id;
                    // _logger.LogInformation($"\n{DateTime.Now} : Successfully passed condition OTP is not expired\n");
                    isOtpValid.IsExpired = true;
                    isOtpValid.UsedAt = DateTime.Now;

                    await db.SaveChangesAsync();

                    TempData["msg"] = "You are successfully Logged In!!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["errMsg"] = "This OTP is already expired!!";
                }
            }
            else
            {
                TempData["errMsg"] = "The OTP you entered is invalid!!";
            }

            
            return RedirectToAction("VerifyOTP", new { AppId = model.employeeId });

        }
        #region Helping Method
        private async Task<string> UpdateLicenseResultAsync(string requestNumber, string result)
        {
            var dto = new LicenseResultDto
            {
                RequestNumber = requestNumber,
                TestResult = result
            };

            var CrmResult = await _apiService.PostAsync<LicenseResultDto, string>(
                "api/AppForLicense/UpdateStageAndStatus",
                dto
            );

            return CrmResult;
        }

        #endregion

    }
}
