using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        // GET: Category
        public ActionResult Index(int page = 1)
        {
            var variables = c.Categories.ToList().ToPagedList(page, 4);
            return View(variables);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryDelete(int id)
        {
            var ctgid = c.Categories.Find(id);
            c.Categories.Remove(ctgid);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryUpdate(int id)
        {
            var ctgupt = c.Categories.Find(id);
            return View("CategoryUpdate", ctgupt);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            var ctgr = c.Categories.Find(category.CategoryID);
            ctgr.CategoryName = category.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Test()
        {
            Class4 cs = new Class4();
            cs.Categories = new SelectList(c.Categories, "CategoryID", "CategoryName");
            cs.Products = new SelectList(c.Products, "ProductID", "ProductName");
            return View(cs);

        }
        public JsonResult GetProduct(int p)
        {

            var products = (from x in c.Products
                            join y in c.Categories
                            on x.category.CategoryID equals y.CategoryID
                            where x.category.CategoryID == p
                            select new
                            {
                                Text = x.ProductName,
                                Value = x.ProductID.ToString()
                            }).ToList();

            return Json(products,JsonRequestBehavior.AllowGet);
        }

    }
}