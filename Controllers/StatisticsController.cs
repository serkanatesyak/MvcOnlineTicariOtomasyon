using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcOnlineTicariOtomasyon.Controllers
{

    public class StatisticsController : Controller
    {
        Context c = new Context();
        // GET: Statistics
        public ActionResult Index()
        {
            var vrb1 = c.Customers.Count().ToString();
            ViewBag.d1 = vrb1;

            var vrb2 = c.Products.Count().ToString();
            ViewBag.d2 = vrb2;

            var vrb3 = c.Employees.Count().ToString();
            ViewBag.d3 = vrb3;

            var vrb4 = c.Categories.Count().ToString();
            ViewBag.d4 = vrb4;

            var vrb5 = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = vrb5;

            var vrb6 = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.d6 = vrb6;

            var vrb7 = c.Products.Count(x => x.Stock <= 150).ToString();
            ViewBag.d7 = vrb7;

            var vrb8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = vrb8;

            var vrb9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = vrb9;

            var vrb10 = c.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = vrb10;

            var vrb11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = vrb11;

            var vrb12 = c.Products.GroupBy(x => x.ProductBrand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = vrb12;

            var vrb13 = c.Products.Where(u => u.ProductID == c.SalesMoves.GroupBy(x => x.ProductID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.d13 = vrb13;

            var vrb14 = c.SalesMoves.Sum(x => x.TotalPrice).ToString();
            ViewBag.d14 = vrb14;

            var vrb15 = c.SalesMoves.Count(x => x.Date == DateTime.Today).ToString();
            ViewBag.d15 = vrb15;

            var vrb16 = c.SalesMoves.Where(x => x.Date == DateTime.Today).Sum(y =>(decimal?) y.TotalPrice).ToString();
            ViewBag.d16 = vrb16;


            return View();
        }
        public ActionResult Table()
        {
            var tbl = from x in c.Customers
                      group x by x.CustomerCity into g
                      select new ClassGroup
                      {
                          City = g.Key,
                          Count = g.Count()

                      };
            return View(tbl.ToList());
        }

        public PartialViewResult GroupDepartman()
        {
            var tbl1 = from x in c.Employees
                       group x by x.Department.DepartmentName into g
                       select new ClassGroup2
                       {
                           Departman = g.Key,
                           Count = g.Count()
                       };
            return PartialView(tbl1.ToList());
        }
        public PartialViewResult Partial2()
        {
            var tbl = c.Customers.ToList();
            return PartialView(tbl);
        }
        public PartialViewResult Partial3()
        {
            var tbl = c.Products.ToList();
            return PartialView(tbl);
        }
        public PartialViewResult Partial4()
        {

            var tbl4 = from x in c.Products
                       group x by x.ProductBrand into g
                       select new ClassGroup3
                       {
                           Brand = g.Key,
                           Count = g.Count()
                       };
            return PartialView(tbl4.ToList());
        }



    }
}