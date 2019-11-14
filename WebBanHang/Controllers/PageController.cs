using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EF;

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

        public ActionResult DangNhap()
        {
            ViewBag.Message = "Đây là trang đăng nhập...";

            return View();
        }

        public ActionResult DangKy()
        {
            ViewBag.Message = "Đây là trang đăng ký...";

            return View();
        }

        public ActionResult DieuKhoan()
        {
            ViewBag.Message = "Đây là trang đăng ký...";

            return View();
        }

        public ActionResult SanPham()
        {
            List<products> lstProduct = new List<products>();

            // Lấy dữ liệu danh sách sản phẩm
            using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
            {
                lstProduct = context.products.ToList();// SELECT * FROM products
            }

            // Truyền dữ liệu từ Controller -> View thông qua Viewbag
            ViewBag.DanhSachSanPham = lstProduct;
            return View();
        }
    }
}