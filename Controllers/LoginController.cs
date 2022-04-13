using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public PartialViewResult Register()
        {
            return PartialView();
        }

        [HttpPost]

        public PartialViewResult Register(Customer customer)
        {
            c.Customers.Add(customer);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CustomerLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin1(Customer customer)
        {
            var info = c.Customers.FirstOrDefault(x => x.CustomerMail == customer.CustomerMail && x.Password == customer.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.CustomerMail, false);
                Session["CustomerMail"] = info.CustomerMail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeLogin(Admin admin)
        {
            var info = c.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.UserName, false);
                Session["UserName"] = info.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

    }
}