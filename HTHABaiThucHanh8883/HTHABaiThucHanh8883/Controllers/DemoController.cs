using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTHABaiThucHanh8883.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Demo1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Demo2(string MaSinhVien, string HoTenSinhVien)
        {
            ViewBag.Thongtin = MaSinhVien + "" + HoTenSinhVien;
            return View();
        }
    }
}