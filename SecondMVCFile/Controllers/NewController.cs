using Microsoft.AspNetCore.Mvc;

namespace SecondMVCFile.Controllers
{
    public class NewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Start()
        {
            return View();
        }
    }
}
