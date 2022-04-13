using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        Context c = new Context();
        // GET: Customer
        public ActionResult Index()
        {
            var varaibles = c.Customers.Where(x => x.Status == true).ToList();
            return View(varaibles);
        }


        public ActionResult CustomerAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerAdd(Customer customer)
        {
            customer.Status = true;
            c.Customers.Add(customer);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerDelete(int id)
        {
            var cust = c.Customers.Find(id);
            cust.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCustomer(int id)
        {
            var custt = c.Customers.Find(id);
            return View("GetCustomer", custt);
        }

        public ActionResult CustomerUpdate(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return View("GetCustomer");
            }
            var cus = c.Customers.Find(customer.CustomerID);
            cus.CustomerName = customer.CustomerName;
            cus.CustomerSurName = customer.CustomerSurName;
            cus.CustomerCity = customer.CustomerCity;
            cus.CustomerMail = customer.CustomerMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult SalesHistory(int id)
        {
            var varaibles = c.SalesMoves.Where(x => x.CustomerID == id).ToList();
            var cus = c.Customers.Where(x => x.CustomerID == id).Select(y => y.CustomerName + " " + y.CustomerSurName).FirstOrDefault();
            ViewBag.dper = cus;
            return View(varaibles);
        }


    }
}