using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChewApp.Data.Access;
using ChewApp.Domain.Models;

namespace ChewAppV2.Areas.Admin.Controllers
{
    public class AsynDemoController : Controller
    {
        private ChewAppContext db = new ChewAppContext();

        // GET: Admin/AsynDemo
        public async Task<ActionResult> Index()
        {
            return View(await db.UserTbls.ToListAsync());
        }

        // GET: Admin/AsynDemo/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = await db.UserTbls.FindAsync(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // GET: Admin/AsynDemo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AsynDemo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FullName,Gender,Email,Phone,Address,UserName,Password,StarTotalSC,StarTotalKC,KeeChew,SoonChew,UserType,UserRole,Image,ResetPasswordCode,DigitCode,RegisteredOn,ReferralCode,ReferredBy,TokenDevices,KeeChewPlaceOrderTbl_ID,HistorySoonChew_ID,HistoryKeeChew_ID,Latitude,Longitude,TimeOTP,TimeOpenApp,VerifyCode,StatusEmail,StatusOnline,Status,Customer_Stripe_ID,Devices_OS")] UserTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                db.UserTbls.Add(userTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userTbl);
        }

        // GET: Admin/AsynDemo/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = await db.UserTbls.FindAsync(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // POST: Admin/AsynDemo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FullName,Gender,Email,Phone,Address,UserName,Password,StarTotalSC,StarTotalKC,KeeChew,SoonChew,UserType,UserRole,Image,ResetPasswordCode,DigitCode,RegisteredOn,ReferralCode,ReferredBy,TokenDevices,KeeChewPlaceOrderTbl_ID,HistorySoonChew_ID,HistoryKeeChew_ID,Latitude,Longitude,TimeOTP,TimeOpenApp,VerifyCode,StatusEmail,StatusOnline,Status,Customer_Stripe_ID,Devices_OS")] UserTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userTbl);
        }

        // GET: Admin/AsynDemo/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = await db.UserTbls.FindAsync(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // POST: Admin/AsynDemo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            UserTbl userTbl = await db.UserTbls.FindAsync(id);
            db.UserTbls.Remove(userTbl);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
