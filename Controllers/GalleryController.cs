using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context c = new Context();
        // GET: Gallery
        public ActionResult Index()
        {
            var varabiles = c.Products.ToList();
            return View(varabiles);
        }
    }
}