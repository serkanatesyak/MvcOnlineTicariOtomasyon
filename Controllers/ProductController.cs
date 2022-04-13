using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
//using static System.Net.Mime.MediaTypeNames;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();
        // GET: Product
        public ActionResult Index(string search)
        {

            var products = from x in c.Products select x;
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.ProductName.Contains(search));
            }
            return View(products.ToList());


        }
        //text burada kullanıcya gözükecek olan değer
        public ActionResult ProductAdd()
        {
            List<SelectListItem> var1 = (from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();

            ViewBag.varaible = var1;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            c.Products.Add(product);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var varaibles = c.Products.Find(id);
            varaibles.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductUpdate(int id)
        {
            List<SelectListItem> var1 = (from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();

            ViewBag.varaible = var1;

            var productvar = c.Products.Find(id);
            return View("ProductUpdate", productvar);
        }


        public ActionResult UpdateProduct(Product product)
        {
            var prd = c.Products.Find(product.ProductID);
            prd.PurchasePrice = product.PurchasePrice;
            prd.Status = product.Status;
            prd.CategoryID = product.CategoryID;
            prd.ProductBrand = prd.ProductBrand;
            prd.SalePrice = product.SalePrice;
            prd.Stock = product.Stock;
            prd.ProductName = product.ProductName;
            prd.ProductImage = product.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var varaibles = c.Products.ToList();
            return View(varaibles);
        }
        public ActionResult DoSale(int id)
        {

            List<SelectListItem> var1 = (from x in c.Employees.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.EmployeeName + " " + x.EmployeeSurName,
                                             Value = x.EmployeeID.ToString()
                                         }).ToList();
            ViewBag.varabible1 = var1;
            var var2 = c.Products.Find(id);

            ViewBag.varabible2 = var2.ProductID;
            ViewBag.varabible3 = var2.SalePrice;

            return View();
        }

        [HttpPost]
        public ActionResult DoSale(SalesMove salesMove)
        {

            salesMove.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMoves.Add(salesMove);
            c.SaveChanges();
            return RedirectToAction("Index", "Sales");


        }

    }
}