using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var onefile = Request.Files[0];
                fileName = onefile.FileName;
                try
                {
                    onefile.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
                    Message = "File Uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    Message = "File Upload failed! try it again.";
                }
            }
            return new JsonResult{ Data = new {Message= Message, Status= flag}};
        }
    }
}