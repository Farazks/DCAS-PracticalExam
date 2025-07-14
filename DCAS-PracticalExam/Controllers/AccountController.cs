using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.General;
using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using DCAS_PracticalExam.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly PracticalExamContext db;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration configuration;
        private readonly IApiConsume _api;
        public AccountController(IAccountRepository _accountRespository, PracticalExamContext db, ILogger<AccountController> logger,
                                UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager, IConfiguration myconfig,IApiConsume api)
        {
            _api = api;
            this.db = db;
            accountRepository = _accountRespository;
            _logger = logger;
            this.db = db;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            configuration = myconfig;
        }

        [Route("signup")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost, Route("signup")]
        public async Task<IActionResult> Signup(UserSignup user)
        {
            Notifications home = new Notifications(configuration);
            if (ModelState.IsValid)
            {
                var result = await accountRepository.CreateUserAsync(user);

                if(!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    
                    return View(user);
                }

                TempData["Message"] = await home.Notify("User Created Succesfully", "Success");
                ModelState.Clear();
            }
            else
            {

            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        //        [HttpPost]
        //        [Route("login")]
        //        public async Task<IActionResult> Login(UserSignIn signInModel, string returnUrl)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var user = await accountRepository.FindByEmailAsync(signInModel.Email);
        //                if (user is null)
        //                {
        //                    ModelState.AddModelError("", $"Invalid email email address {signInModel.Email}");
        //                    return View();
        //                }
        //                //is email verifeid
        //                if (!user.EmailConfirmed)
        //                {
        //                    ModelState.AddModelError("", "Account is locked contact admin");
        //                    return View();
        //                }

        //                //validate user from active directory
        //                var result = Microsoft.AspNetCore.Identity.SignInResult.Success;
        //#if (!DEBUG)
        //                var response = await _api.VerifyUserAsync(signInModel.Email, signInModel.Password);
        //#else
        //                var response = true;
        //                #endif
        //                if (!response)
        //                {
        //                    //what to do
        //                    // so doing don't know right or wrong but it will work.

        //                    //pass invalid credential to passwordsignin so after few attempt it can block code
        //                    //signInModel.Password = "Incorrect zyz";
        //                    result = await accountRepository.PasswordSigninAsync(signInModel);

        //                    //if account is locked
        //                    if (result.IsLockedOut)
        //                    {
        //                        var a = db.Users.FirstOrDefault(x => x.Email == signInModel.Email);
        //                        a.EmailConfirmed = false;
        //                        db.SaveChanges();
        //                        ModelState.AddModelError("", "The account is locked out");
        //                    }
        //                    //is email verifeid
        //                    if (result.IsNotAllowed)
        //                        ModelState.AddModelError("", "account is locked contact admin");
        //                    //credentials verfication
        //                    if (!result.Succeeded)
        //                        ModelState.AddModelError("", "Invalid Credentials");

        //                    return View();
        //                }

        //                await accountRepository.SignInAsync(user, configuration.GetValue<int>("AD:SessionExpiryHours"));
        //                if (!string.IsNullOrEmpty(returnUrl))
        //                {


        //                    //if (!string.IsNullOrEmpty(returnUrl))
        //                    //    return LocalRedirect(returnUrl);
        //                    if (returnUrl == "/")
        //                    {
        //                        return RedirectToAction("GenerateOtp", "Form", new {appID = user.Id});
        //                    }
        //                    else if (returnUrl == "/signup" || returnUrl == "/login")
        //                    {
        //                        return RedirectToAction("GenerateOtp", "Form", new { appID = user.Id });
        //                    }
        //                    return RedirectToAction(returnUrl, "Form", new { appID = user.Id });
        //                }//return url setting

        //                return RedirectToAction("GenerateOtp", "Form", new { appID = user.Id });

        //            }//if model state is valid
        //            return View();
        //            #region Old Code
        //            //if (ModelState.IsValid)
        //            //{
        //            //    var result = await accountRepository.PasswordSigninAsync(user);

        //            //    if (result.Succeeded)
        //            //    {
        //            //        if (!string.IsNullOrEmpty(returnUrl))
        //            //        {
        //            //            return LocalRedirect(returnUrl);
        //            //        }
        //            //        return RedirectToAction("Index", "Home");
        //            //    }
        //            //    if (result.IsNotAllowed)
        //            //    {
        //            //        ModelState.AddModelError("", "Email Not Confirmed By Admin");
        //            //    }
        //            //    else
        //            //        ModelState.AddModelError("", "Invalid Credentials");
        //            //}
        //            //return View(user);
        //            #endregion
        //        }


        // New login method using AD without checking password from DB


        /*// New login method using AD without checking password from DB*/
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserSignIn signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // 1. Find user from local database
                var user = await accountRepository.FindByEmailAsync(signInModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", $"Invalid email address {signInModel.Email}");
                    return View();
                }

                // 2. Check if email is confirmed
                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError("", "Account is locked. Contact admin.");
                    return View();
                }

                // 3. Validate against Active Directory
#if (!DEBUG)
        var isAdValid = await _api.VerifyUserAsync(signInModel.Email, signInModel.Password);
#else
                var isAdValid = true;
#endif

                if (!isAdValid)
                {
                    ModelState.AddModelError("", "Invalid Active Directory credentials.");
                    return View();
                }

                // 4. Sign in the user manually after AD validation success
                await accountRepository.SignInAsync(user, configuration.GetValue<int>("AD:SessionExpiryHours"));

                // 5. Handle redirection after successful login
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    // Normalize URLs
                    if (returnUrl == "/" || returnUrl == "/signup" || returnUrl == "/login")
                    {
                        return RedirectToAction("GenerateOtp", "Form", new { appID = user.Id });
                    }

                    return RedirectToAction(returnUrl, "Form", new { appID = user.Id });
                }

                return RedirectToAction("GenerateOtp", "Form", new { appID = user.Id });
            }

            return View(); // If ModelState is invalid
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await accountRepository.Signout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "SuperAdmin")]
        [Route("ViewAllUsers")]
        public async Task<IActionResult> ViewAllUsers()
        {
            var usrLsst = db.UserRoles.Where(w => w.RoleId == "1").Select(s => new { s.UserId }).ToList();

            var users = _userManager.Users.ToList();    //Get All Users
            var getUAndR = new GetUsersAndTheirRoles();
            List<ApplicationUser> s = new List<ApplicationUser>();
            foreach (var uId in usrLsst)
            {
                var u = _userManager.Users.FirstOrDefault(f => f.Id == uId.UserId);
                users.Remove(u);
            }
            foreach (var u in users)
            {
                ApplicationUser usr = new ApplicationUser
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    EmailConfirmed = u.EmailConfirmed,
                    PhoneNumber = u.PhoneNumber,
                    roles = await _userManager.GetRolesAsync(u)

                };
                s.Add(usr);
            }
            getUAndR.users = s;

            return View(getUAndR);
        }

        [Route("ActiveUser")]
        public async Task<IActionResult> ActiveUser(string uid)
        {
            Notifications home = new Notifications(configuration);
            var checkuserrole = db.UserRoles.Where(x => x.UserId == uid).FirstOrDefault();
            if(checkuserrole==null)
            {
                await accountRepository.AddUserRole(uid);
            }

            var a = db.Users.Where(x => x.Id == uid).FirstOrDefault();
            a.EmailConfirmed = true;
            db.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            TempData["Message"] = await home.Notify("User Activated Succesfully", "Success");

            return RedirectToAction("ViewAllUsers", "Account");
        }

        [Route("DeActiveUser")]
        public async Task<IActionResult> DeActiveUser(string uid)
        {
            Notifications home = new Notifications(configuration);
            var a = db.Users.Where(x => x.Id == uid).FirstOrDefault();
            a.EmailConfirmed = false;
            db.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            TempData["Message"] = await home.Notify("User DeActivated Succesfully", "Success");
            return RedirectToAction("ViewAllUsers", "Account");
        }

    }
}
