using DCAS_PracticalExam.Context;
using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly PracticalExamContext db;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, PracticalExamContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            this.db = db;
        }

        public async Task<IdentityResult> CreateUserAsync(UserSignup myuser)
        {
            var user = new ApplicationUser()
            {
                FirstName = myuser.FirstName,
                LastName = myuser.LastName,
                Email = myuser.Email,
                UserName = myuser.Email
            };

            var result = await _userManager.CreateAsync(user, myuser.Password);
            
            return result;
        }

        public async Task<SignInResult> PasswordSigninAsync(UserSignIn user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

            return result;
        }
        public async Task<ApplicationUser> FindByEmailAsync(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            return user;
        }
        public async Task SignInAsync(ApplicationUser user, int rememberMe)
        {
            await _signInManager.SignInAsync(user, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(rememberMe),
                AllowRefresh = true
            });
        }

        public async Task Signout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> AddUserRole(string userID)
        {
            //var myuser = await _userManager.FindByEmailAsync(user.userEmail);
            //var userID = myuser.Id;
            //var myresult = _userManager.AddToRolesAsync(myuser, "Admin");
            var result = db.UserRoles.Add(new IdentityUserRole<string> { RoleId = "2",UserId=userID});

            db.SaveChanges();
            return "Success";
        }

    }
}
