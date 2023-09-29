using System.Threading.Tasks;
using DatabaseAccess.Models;

namespace DatabaseAccess
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User []> GetUsers();
    }
}