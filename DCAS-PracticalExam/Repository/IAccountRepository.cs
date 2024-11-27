using DCAS_PracticalExam.HelperModels;
using DCAS_PracticalExam.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DCAS_PracticalExam.Repository
{
    public interface IAccountRepository
    {
        Task<SignInResult> PasswordSigninAsync(UserSignIn user);
        Task<ApplicationUser> FindByEmailAsync(string Email);

        Task<IdentityResult> CreateUserAsync(UserSignup user);
        Task SignInAsync(ApplicationUser user, int rememberMe); 
        Task Signout();
        Task<string> AddUserRole(string userID);
    }
}