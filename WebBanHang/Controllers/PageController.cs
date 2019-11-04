using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            ViewBag.Message = "Đây là trang liên hệ...";

            return View();
        }

        public ActionResult GioiThieu()
        {
            ViewBag.Message = "Đây là trang giới thiệu...";

            return View();
        }
    }
}