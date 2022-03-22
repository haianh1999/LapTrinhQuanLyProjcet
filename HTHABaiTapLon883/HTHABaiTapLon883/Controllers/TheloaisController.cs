using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HTHABaiTapLon883.Models;

namespace HTHABaiTapLon883.Controllers
{
    public class TheloaisController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();

        // GET: Theloais
        public ActionResult Index()
        {
            return View(db.Theloais.ToList());
        }

        // GET: Theloais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloai theloai = db.Theloais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // GET: Theloais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Theloais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTheLoai,TenTheLoai")] Theloai theloai)
        {
            if (ModelState.IsValid)
            {
                db.Theloais.Add(theloai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theloai);
        }

        // GET: Theloais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloai theloai = db.Theloais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // POST: Theloais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTheLoai,TenTheLoai")] Theloai theloai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theloai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theloai);
        }

        // GET: Theloais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloai theloai = db.Theloais.Find(id);
            if (theloai == null)
            {
                return HttpNotFound();
            }
            return View(theloai);
        }

        // POST: Theloais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theloai theloai = db.Theloais.Find(id);
            db.Theloais.Remove(theloai);
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
