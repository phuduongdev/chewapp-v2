using ChewApp.Data.Access.Repository;
using ChewApp.Domain.Models;
using ChewApp.Service;
using PagedList;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChewAppV2.Areas.Admin.Controllers {

    public class AccountController : Controller {
        private IUserService _userService;

        public AccountController(IUserService userService) {
            _userService = userService;
        }

        // GET: Admin/Account
        public ActionResult Index() {
            var results = _userService.GetAll();
            //return View(result.ToPagedList(page, pageSize));
            return View("Index", results);
        }

        public ActionResult Details(int id) {
            _userService.GetSingleById(id);
            return View("Details");
        }
    }
}