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
    public class SachesAdminController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();
        StringProcess genkey = new StringProcess();
        // GET: Admin/SachesAdmin
        public ActionResult Index()
        {
            var saches = db.Saches.Include(s => s.Nhaxuatbans).Include(s => s.TacGias).Include(s => s.TheLoais);
            return View(saches.ToList());
        }

        // GET: Admin/SachesAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Admin/SachesAdmin/Create
        public ActionResult Create()
        {
            if (db.Saches.OrderByDescending(m => m.IDSach).Count() == 0)
            {
                var newID = "Sach01";
                ViewBag.newproID = newID;
            }
            else
            {
                var PdID = db.Saches.OrderByDescending(m => m.IDSach).FirstOrDefault().IDSach;
                var newID = genkey.AutogenrateCode(PdID);
                ViewBag.newproID = newID;
            }
            ViewBag.MaNhaXuatBan = new SelectList(db.Nhaxuatbans, "MaNhaXuatBan", "TenNhaXuatban");
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia");
            ViewBag.MaTheLoai = new SelectList(db.Theloais, "MaTheLoai", "TenTheLoai");
            return View();
        }

        // POST: Admin/SachesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSach,TenSach,GiaSach,MaTheLoai,MaTacGia,MaNhaXuatBan")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhaXuatBan = new SelectList(db.Nhaxuatbans, "MaNhaXuatBan", "TenNhaXuatban", sach.MaNhaXuatBan);
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sach.MaTacGia);
            ViewBag.MaTheLoai = new SelectList(db.Theloais, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // GET: Admin/SachesAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhaXuatBan = new SelectList(db.Nhaxuatbans, "MaNhaXuatBan", "TenNhaXuatban", sach.MaNhaXuatBan);
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sach.MaTacGia);
            ViewBag.MaTheLoai = new SelectList(db.Theloais, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // POST: Admin/SachesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSach,TenSach,GiaSach,MaTheLoai,MaTacGia,MaNhaXuatBan")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhaXuatBan = new SelectList(db.Nhaxuatbans, "MaNhaXuatBan", "TenNhaXuatban", sach.MaNhaXuatBan);
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sach.MaTacGia);
            ViewBag.MaTheLoai = new SelectList(db.Theloais, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // GET: Admin/SachesAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Admin/SachesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
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
