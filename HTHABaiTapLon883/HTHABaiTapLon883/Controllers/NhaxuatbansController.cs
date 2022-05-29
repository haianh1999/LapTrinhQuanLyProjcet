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
    public class NhaxuatbansController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();

        // GET: Nhaxuatbans
        public ActionResult Index()
        {
            return View(db.Nhaxuatbans.ToList());
        }

        // GET: Nhaxuatbans/Details/5
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

        // GET: Nhaxuatbans/Create        
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
