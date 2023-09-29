using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var authors = (await _repo.GetRequests()).OrderBy(x=>x.Date);
            return View(authors);
        }
    }
}