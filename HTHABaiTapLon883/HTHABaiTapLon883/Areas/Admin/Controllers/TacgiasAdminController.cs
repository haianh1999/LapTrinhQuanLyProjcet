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
    public class TacgiasAdminController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();
        StringProcess genkey = new StringProcess();
        // GET: Admin/TacgiasAdmin
        public ActionResult Index()
        {
            return View(db.TacGias.ToList());
        }

        // GET: Admin/TacgiasAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tacgia tacgia = db.TacGias.Find(id);
            if (tacgia == null)
            {
                return HttpNotFound();
            }
            return View(tacgia);
        }

        // GET: Admin/TacgiasAdmin/Create
        public ActionResult Create()
        {
            if (db.TacGias.OrderByDescending(m => m.MaTacGia).Count() == 0)
            {
                var newID = "TG01";
                ViewBag.newproID = newID;
            }
            else
            {
                var PdID = db.TacGias.OrderByDescending(m => m.MaTacGia).FirstOrDefault().MaTacGia;
                var newID = genkey.AutogenrateCode(PdID);
                ViewBag.newproID = newID;
            }
            return View();
        }

        // POST: Admin/TacgiasAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTacGia,TenTacGia")] Tacgia tacgia)
        {
            if (ModelState.IsValid)
            {
                db.TacGias.Add(tacgia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tacgia);
        }

        // GET: Admin/TacgiasAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tacgia tacgia = db.TacGias.Find(id);
            if (tacgia == null)
            {
                return HttpNotFound();
            }
            return View(tacgia);
        }

        // POST: Admin/TacgiasAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTacGia,TenTacGia")] Tacgia tacgia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tacgia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tacgia);
        }

        // GET: Admin/TacgiasAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tacgia tacgia = db.TacGias.Find(id);
            if (tacgia == null)
            {
                return HttpNotFound();
            }
            return View(tacgia);
        }

        // POST: Admin/TacgiasAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tacgia tacgia = db.TacGias.Find(id);
            db.TacGias.Remove(tacgia);
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
