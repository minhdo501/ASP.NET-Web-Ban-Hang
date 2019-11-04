using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult GioHang()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            return View();
        }
    }
}