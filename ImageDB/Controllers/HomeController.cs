using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddImage()
        {
            Picture b1 = new Picture();
            return View(b1);
        }
        [HttpPost]
        public ActionResult AddImage(Picture model, HttpPostedFileBase image1)
        {
            var db = new GalleryEntities();
            if(image1!=null)
            {
                model.Image = new byte[image1.ContentLength];
                image1.InputStream.Read(model.Image, 0, image1.ContentLength);
            }
            db.Pictures.Add(model);
            db.SaveChanges();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}