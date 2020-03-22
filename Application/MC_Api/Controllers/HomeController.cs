using System.Web.Mvc;

namespace MC_Api.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}