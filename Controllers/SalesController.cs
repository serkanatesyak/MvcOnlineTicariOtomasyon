using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        Context c = new Context();
        // GET: Sales
        public ActionResult Index()
        {
            var varaibles = c.SalesMoves.ToList();
            return View(varaibles);
        }
        public ActionResult NewSales()
        {
            List<SelectListItem> var1 = (from x in c.Products.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ProductName,
                                             Value = x.ProductID.ToString()
                                         }).ToList();
            List<SelectListItem> var2 = (from x in c.Customers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CustomerName + " " + x.CustomerSurName,
                                             Value = x.CustomerID.ToString()
                                         }).ToList();



            List<SelectListItem> var3 = (from x in c.Employees.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.EmployeeName + " " + x.EmployeeSurName,
                                             Value = x.EmployeeID.ToString()
                                         }).ToList();
            ViewBag.varabible1 = var1;
            ViewBag.varabible2 = var2;
            ViewBag.varabible3 = var3;
            return View();
        }

        [HttpPost]
        public ActionResult NewSales(SalesMove salesMove)
        {
            salesMove.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMoves.Add(salesMove);
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSales(int id)
        {
            List<SelectListItem> var1 = (from x in c.Products.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ProductName,
                                             Value = x.ProductID.ToString()
                                         }).ToList();
            List<SelectListItem> var2 = (from x in c.Customers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CustomerName + " " + x.CustomerSurName,
                                             Value = x.CustomerID.ToString()
                                         }).ToList();



            List<SelectListItem> var3 = (from x in c.Employees.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.EmployeeName + " " + x.EmployeeSurName,
                                             Value = x.EmployeeID.ToString()
                                         }).ToList();
            ViewBag.varabible1 = var1;
            ViewBag.varabible2 = var2;
            ViewBag.varabible3 = var3;
            var varaibles = c.SalesMoves.Find(id);
            return View("GetSales", varaibles);
        }


        public ActionResult UpdateSales(SalesMove salesMove)
        {
            var varabible = c.SalesMoves.Find(salesMove.SalesMoveID);
            varabible.CustomerID = salesMove.CustomerID;
            varabible.Quantity = salesMove.Quantity;
            varabible.Price = salesMove.Price;
            varabible.EmployeeID = salesMove.EmployeeID;
            varabible.Date = salesMove.Date;
            varabible.TotalPrice = salesMove.TotalPrice;
            varabible.ProductID = salesMove.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetails(int id)
        {
            var varaibles=c.SalesMoves.Where(x=>x.SalesMoveID== id).ToList();
            return View(varaibles);
        }



    }
}