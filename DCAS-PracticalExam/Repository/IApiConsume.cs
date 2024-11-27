using System.Threading.Tasks;

namespace DCAS_PracticalExam.Repository
{
    public interface IApiConsume 
    {
        Task<bool> VerifyUserAsync(string email, string password);
    }
}
