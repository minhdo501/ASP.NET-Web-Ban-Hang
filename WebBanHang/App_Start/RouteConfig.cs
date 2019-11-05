using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route mặc định của trang Giới thiệu
            // URL: /gioi-thieu
            routes.MapRoute(
                name: "page.gioi_thieu",
                url: "gioi-thieu",
                defaults: new { controller = "Page", action = "GioiThieu" }
            );

            // Route mặc định của trang Liên hệ
            // URL: /lien-he
            routes.MapRoute(
                name: "page.lien_he",
                url: "lien-he",
                defaults: new { controller = "Page", action = "LienHe" }
            );

            // Route mặc định của trang Đăng nhâp
            // URL: /dang-nhap
            routes.MapRoute(
                name: "page.dang_nhap",
                url: "dang-nhap",
                defaults: new { controller = "Page", action = "DangNhap" }
            );

            // Route mặc định của trang Đăng ký
            // URL: /dang-ky
            routes.MapRoute(
                name: "page.dang_ky",
                url: "dang-ky",
                defaults: new { controller = "Page", action = "DangKy" }
            );

            // Route mặc định của trang Sản phẩm
            // URL: /san-pham
            routes.MapRoute(
                name: "page.san_pham",
                url: "san-pham",
                defaults: new { controller = "Page", action = "SanPham" }
            );

            // Route mặc định của trang Chi tiết sản phẩm
            // URL: /product-detail
            routes.MapRoute(
                name: "page.product_detail",
                url: "chitiet-sanpham",
                defaults: new { controller = "Page", action = "ProductDetail(int id)" }
            );

            // Route mặc định của trang Sản phẩm
            // URL: /tim-kiem
            routes.MapRoute(
                name: "page.tim_kiem",
                url: "tim-kiem",
                defaults: new { controller = "Page", action = "Index" }
            );

            // Route mặc định của trang Đơn hàng
            // URL: /gio-hang
            routes.MapRoute(
                name: "page.gio_hang",
                url: "gio-hang",
                defaults: new { controller = "Page", action = "GioHang" }
            );

            // Route mặc định của trang Check out
            // URL: /check-out
            routes.MapRoute(
                name: "page.check_out",
                url: "check-out",
                defaults: new { controller = "Page", action = "CheckOut" }
            );

            // URL: /chinh-sach
            routes.MapRoute(
                name: "page.chinh_sach",
                url: "chinh-sach",
                defaults: new { controller = "Page", action = "ChinhSach" }
            );
            
            // URL: /dieu-khoan
            routes.MapRoute(
                name: "page.dieu_khoan",
                url: "dieu-khoan",
                defaults: new { controller = "Page", action = "DieuKhoan" }
            );

            // Route mặc định của trang Web
            // URL: /
            routes.MapRoute(
                name: "page",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
