using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        Context c = new Context();
        // GET: ToDoList
        public ActionResult Index()
        {
            var var1 = c.Customers.Count().ToString();
            ViewBag.v1 = var1;

            var var2 = c.Products.Count().ToString();
            ViewBag.v2 = var2;

            var var3 = c.Categories.Count().ToString();
            ViewBag.v3 = var3;

            var var4 = (from x in c.Customers select x.CustomerCity).Distinct().Count().ToString();
            ViewBag.v4 = var4;

            var todolist = c.ToDoLists.ToList();
            return View(todolist);
        }
    }
}