using System;
using System.Collections.Generic;
using System.IO;
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
        public string DangKy(string last_name, string first_name, string email, string password, HttpPostedFileBase avatar, string job_title, string department,
            int manager_id, string phone, string address1, string address2, string city, string postal_code, string country)
        {
            try
            {
                // Code cho việc xử lý và lưu trữ file upload
                string _FileName = "";
                string datetimeFolderName= "";
                // Di chuyển file vào thư mục mong muốn
                if (avatar.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(avatar.FileName);
                    
                    string _FileNameExtension = Path.GetExtension(avatar.FileName);
                    if ((_FileNameExtension == ".png"
                        || _FileNameExtension == ".jpg"
                        || _FileNameExtension == "jpeg"
                        || _FileNameExtension == ".docx"
                        || _FileNameExtension == ".xls"
                        || _FileNameExtension == ".xlsx") == false)
                    {
                        return string.Format("File có đuôi {0} không được chấp nhận. Vui lòng kiểm tra lại!", _FileNameExtension);
                    }

                    DateTime now = DateTime.Now;
                    datetimeFolderName = string.Format("{0}{1}{2}{3}", now.Year, now.Month, now.Day, now.Hour);

                    string uploadFolderPath = Server.MapPath("~/UploadedFiles/" + datetimeFolderName);
                    if (Directory.Exists(uploadFolderPath) == false) // Nếu thư mục cần lưu trữ file upload không tồn tại -> Tạo mới
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }

                    string _path = Path.Combine(Server.MapPath(uploadFolderPath), _FileName);
                    avatar.SaveAs(_path);
                }

                using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
                {
                    // Tạo 1 dòng mới 'employees'
                    employees newRow = new employees();

                    newRow.last_name = last_name;
                    newRow.first_name = first_name;
                    newRow.email = email;
                    newRow.password = password;

                    // Save tên file vào DB
                    // 201911122018/'tên file'.png/jpg...
                    newRow.avatar = datetimeFolderName + "/" + _FileName;

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