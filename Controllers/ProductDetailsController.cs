using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailsController : Controller
    {
        Context c = new Context();
        // GET: ProductDetails
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var varaibles = c.Products.Where(x => x.ProductID == 1).ToList();
            cs.dgr1 = c.Products.Where(x => x.ProductID == 1).ToList();
            cs.dgr2 = c.Details.Where(y => y.DetailID == 1).ToList();
            return View(cs);
        }
    }
}