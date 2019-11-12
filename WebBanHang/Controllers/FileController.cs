using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebBanHang.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        // Action download file
        public FileResult Download(string fileName)
        {
            var FileVirtualPath = "~/DocumentFiles/" + fileName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        } 
    }
}