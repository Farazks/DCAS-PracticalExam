using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.DTOs;
using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using DCAS_PracticalExam.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PracticalExamContext db;
        private readonly IApiService _apiService;
        public HomeController(ILogger<HomeController> logger, PracticalExamContext context, IApiService apiService)
        {
            db = context;
            _logger = logger;
            _apiService = apiService;
        }
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
                { return View(); }

            return RedirectToAction("Login", "Account");
        }

        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLicense()
        {
           //for testing 
           //testing is pass 
           //code is working 
           //API Sucssesfully Cunsume and working fine
            var crmResponse = await UpdateLicenseResultAsync("PLR-19-01936", "Fail");
            return Ok(crmResponse);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Helping Method for 
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
