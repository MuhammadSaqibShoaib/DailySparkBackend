using Microsoft.AspNetCore.Mvc;

namespace AtomsBackend.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
