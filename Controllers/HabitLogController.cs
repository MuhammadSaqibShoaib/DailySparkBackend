using Microsoft.AspNetCore.Mvc;

namespace AtomsBackend.Controllers
{
    public class HabitLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
