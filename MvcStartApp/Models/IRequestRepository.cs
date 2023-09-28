using System.Threading.Tasks;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Models
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}