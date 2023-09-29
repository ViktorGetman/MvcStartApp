using System.Threading.Tasks;
using DatabaseAccess.Models;

namespace DatabaseAccess
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}