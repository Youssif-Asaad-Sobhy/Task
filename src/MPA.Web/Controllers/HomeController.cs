using Microsoft.AspNetCore.Mvc;

namespace MPA.Web.Controllers
{
    public class HomeController : MPAControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}