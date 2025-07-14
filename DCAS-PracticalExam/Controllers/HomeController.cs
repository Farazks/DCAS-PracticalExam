﻿using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
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
        public HomeController(ILogger<HomeController> logger, PracticalExamContext context)
        {
            db = context;
            _logger = logger;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
