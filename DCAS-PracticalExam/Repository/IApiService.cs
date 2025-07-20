using System.Threading.Tasks;

namespace DCAS_PracticalExam.Repository
{
   
    public interface IApiService
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data);
        // You can add PutAsync, DeleteAsync similarly
    }
}
