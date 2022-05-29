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
    public class TacgiasController : Controller
    {
        private LTQLDBContext db = new LTQLDBContext();

        // GET: Tacgias
        public ActionResult Index()
        {
            return View(db.TacGias.ToList());
        }

        // GET: Tacgias/Details/5
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
