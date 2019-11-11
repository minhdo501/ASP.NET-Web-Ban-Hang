using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EF;

namespace WebBanHang.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string XuLyDangNhap(string email, string password)
        {
            //Tìm trong DB username và password giống với dữ liệu mà người dùng gửi đến
            using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
            {
                /*Viết LinQ để tìm trong table 'employees', ai có email và password tương đương
                 * obj 'context' tương đương DB
                 * Thuộc tính trong 'context.'
                 * Ví dụ: context.employees => table employees trong DB
                 * ...
                 */

                // Viết theo style METHOD
                var objEmployeeLogin = context.employees.Where(p => p.email == email && p.password == password).FirstOrDefault();

                // Viết theo LinQ
                if (objEmployeeLogin == null)
                {
                    return "Không hợp lệ!";
                }
                else
                {
                    return String.Format("Xin chào anh {0} {1}", objEmployeeLogin.last_name, objEmployeeLogin.first_name);
                }
            }
        }

        [HttpPost]
        public string DangKy(string last_name, string first_name, string email, string password, string avatar, string job_title, string department,
            int manager_id, string phone, string address1, string address2, string city, string postal_code, string country)
        {
            try
            {
                using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
                {
                    // Tạo 1 dòng mới 'employees'
                    employees newRow = new employees();

                    newRow.last_name = last_name;
                    newRow.first_name = first_name;
                    newRow.email = email;
                    newRow.password = password;
                    newRow.avatar = avatar;
                    newRow.job_title = job_title;
                    newRow.department = department;
                    newRow.manager_id = manager_id;
                    newRow.phone = phone;
                    newRow.address1 = address1;
                    newRow.address2 = address2;
                    newRow.city = city;
                    newRow.postal_code = postal_code;
                    newRow.country = country;

                    // Sinh câu lệnh để lưu => Entity Framework => INSERT INTO
                    context.employees.Add(newRow);

                    // Thực thi để lưu thực sự
                    context.SaveChanges();

                    return string.Format("Tài khoản {0} {1} đã được khởi tạo...", last_name, first_name);
                }
            }
            catch (Exception ex)
            {
                return string.Format("Có lỗi xảy ra, thông tin lỗi: {0}", ex.Message);
            }
    
        }
    }
}