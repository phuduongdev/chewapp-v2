using ChewApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChewAppV2.Areas.Admin.Controllers
{
    public class ConnectionController : Controller
    {
        IKeeChewPlaceOrderService _keeChewPlaceOrderService;
        public ConnectionController(IKeeChewPlaceOrderService keeChewPlaceOrderService) {
            _keeChewPlaceOrderService = keeChewPlaceOrderService;
        }

        // GET: Admin/Connection
        public ActionResult Index()
        {
            return View(_keeChewPlaceOrderService.GetAll());
        }

        // GET: Admin/Connection/Details/5
        public ActionResult Details(int id)
        {
            return View(_keeChewPlaceOrderService.GetSingleById(id));
        }

        // GET: Admin/Connection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Connection/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Connection/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Connection/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Connection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Connection/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
