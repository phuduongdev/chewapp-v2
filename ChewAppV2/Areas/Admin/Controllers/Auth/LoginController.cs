using ChewApp.Service;
using System.Web.Mvc;

namespace ChewAppV2.Areas.Admin.Controllers.Auth {

    public class LoginController : Controller {
        private IAdministratorService _administratorService;

        public LoginController(IAdministratorService administratorService) {
            _administratorService = administratorService;
        }

        // GET: Admin/Login
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password) {
            var admin = _administratorService.GetAdminByUsernameAndPassword(username, password);
            if(admin != null) {
                Session["Administrator"] = admin;
                return RedirectToAction("Index", "Account");
            }
            ViewBag.error = "<p style='color: red;'>Please check your username and password.</p>";
            return View("Index");
        }

        public ActionResult Logout() {
            Session["Administrator"] = null;
            return View("Index");
        }
    }
}