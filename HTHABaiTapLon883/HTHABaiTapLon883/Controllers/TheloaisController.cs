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
