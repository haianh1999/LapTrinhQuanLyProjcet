using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HTHABaiTapLon883.Models;
using HTHABaiTapLon883.Models.Process;

namespace HTHABaiTapLon883.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NhaxuatbansAdminController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();
        StringProcess genkey = new StringProcess();
        // GET: Admin/NhaxuatbansAdmin
        public ActionResult Index()
        {
            return View(db.Nhaxuatbans.ToList());
        }

        // GET: Admin/NhaxuatbansAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // GET: Admin/NhaxuatbansAdmin/Create
        public ActionResult Create()
        {
            if (db.Nhaxuatbans.OrderByDescending(m => m.MaNhaXuatBan).Count() == 0)
            {
                var newID = "NXB01";
                ViewBag.newproID = newID;
            }
            else
            {
                var PdID = db.Nhaxuatbans.OrderByDescending(m => m.MaNhaXuatBan).FirstOrDefault().MaNhaXuatBan;
                var newID = genkey.AutogenrateCode(PdID);
                ViewBag.newproID = newID;
            }
            return View();
        }

        // POST: Admin/NhaxuatbansAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhaXuatBan,TenNhaXuatban")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                db.Nhaxuatbans.Add(nhaxuatban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaxuatban);
        }

        // GET: Admin/NhaxuatbansAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Admin/NhaxuatbansAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhaXuatBan,TenNhaXuatban")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaxuatban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaxuatban);
        }

        // GET: Admin/NhaxuatbansAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Admin/NhaxuatbansAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            db.Nhaxuatbans.Remove(nhaxuatban);
            db.SaveChanges();
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
