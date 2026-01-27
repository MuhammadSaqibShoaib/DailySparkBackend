using Microsoft.AspNetCore.Mvc;

namespace AtomsBackend.Controllers
{
    public class HabitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
