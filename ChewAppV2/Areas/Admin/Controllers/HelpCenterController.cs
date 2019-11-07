using ChewApp.Domain.Models;
using ChewApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChewAppV2.Areas.Admin.Controllers
{
    public class HelpCenterController : Controller
    {
        IHelpCenterService _helpCenterService;
        

        public HelpCenterController(IHelpCenterService helpCenterService)
        {
            _helpCenterService = helpCenterService;
        }

        // GET: Admin/HelpCenter
        public ActionResult Index()
        {
            return View(_helpCenterService.GetAll());
        }
        // GET: Admin/HelpCenter/Details/5
        public ActionResult Details(int id)
        {
            _helpCenterService.GetSingleById(id);
            return View("Details");
        }

    }
}