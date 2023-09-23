using Microsoft.AspNetCore.Mvc;

namespace SecondMVCFile.Controllers
{
    public class PartialViewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tabs()
        {
            ViewData["data1"] = "Tom and jerry are Good Friends";
            return View();
        }
    }
}
