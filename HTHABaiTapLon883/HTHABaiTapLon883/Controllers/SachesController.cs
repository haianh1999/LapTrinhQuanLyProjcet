﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HTHABaiTapLon883.Models;
using HTHABaiTapLon883.Models.Process;

namespace HTHABaiTapLon883.Controllers
{
    public class SachesController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();
        StringProcess genkey = new StringProcess();
        // GET: Saches
        public ActionResult Index()
        {
            return View(db.Saches.ToList());
        }

        // GET: Saches/Details/5
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

        // GET: Saches/Create
        [Authorize]
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
            ViewBag.MaTacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia");
            ViewBag.MaTheLoai = new SelectList(db.Theloais, "MaTheLoai", "TenTheLoai");
            ViewBag.MaNhaXuatBan = new SelectList(db.Nhaxuatbans, "MaTheLoai", "TenTheLoai");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSach,TenSach,GiaSach")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sach);
        }

        // GET: Saches/Edit/5
        [Authorize]
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
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSach,TenSach,GiaSach")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sach);
        }

        // GET: Saches/Delete/5
        [Authorize]
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

        // POST: Saches/Delete/5
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
