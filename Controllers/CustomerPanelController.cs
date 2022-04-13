using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CustomerPanelController : Controller
    {
        Context c = new Context();
        // GET: CustomerPanel


        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var varaible = c.Messages.Where(x => x.Delivery == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerID).FirstOrDefault();
            ViewBag.mid = mailid;
            var totalsale = c.SalesMoves.Where(x => x.CustomerID == mailid).Count();
            ViewBag.totalsale = totalsale;

            var totalprice = c.SalesMoves.Where(x => x.CustomerID == mailid).Sum(y => y.TotalPrice);
            ViewBag.totalprice = totalprice;

            var totalproduct = c.SalesMoves.Where(x => x.CustomerID == mailid).Sum(y => y.Quantity);
            ViewBag.totalproduct = totalproduct;

            var namesurname = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerName + " " + y.CustomerSurName).FirstOrDefault();
            ViewBag.namesurname = namesurname;


            return View(varaible);
        }
        public ActionResult MyOrder()
        {
            var mail = (string)Session["CustomerMail"];
            var id = c.Customers.Where(x => x.CustomerMail == mail.ToString()).Select(y => y.CustomerID).FirstOrDefault();
            var varabile = c.SalesMoves.Where(x => x.CustomerID == id).ToList();
            return View(varabile);
        }

        public ActionResult Inbox()
        {
            var mail = (string)Session["CustomerMail"];
            var message = c.Messages.Where(x => x.Delivery == mail).OrderByDescending(x => x.MessageID).ToList();
            var ınboxnumber = c.Messages.Count(x => x.Delivery == mail).ToString();
            ViewBag.d1 = ınboxnumber;
            var outnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outnumber;
            return View(message);
        }

        public ActionResult Outbox()
        {
            var mail = (string)Session["CustomerMail"];
            var message = c.Messages.Where(x => x.Sender == mail).OrderByDescending(z => z.MessageID).ToList();
            var ınboxnumber = c.Messages.Count(x => x.Delivery == mail).ToString();
            ViewBag.d1 = ınboxnumber;

            var outnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outnumber;
            return View(message);
        }
        public ActionResult MessageDetails(int id)
        {
            var varaibles = c.Messages.Where(x => x.MessageID == id).ToList();
            var mail = (string)Session["CustomerMail"];
            var ınboxnumber = c.Messages.Count(x => x.Delivery == mail).ToString();
            ViewBag.d1 = ınboxnumber;
            var outnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outnumber;
            return View(varaibles);
        }
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CustomerMail"];
            var ınboxnumber = c.Messages.Count(x => x.Delivery == mail).ToString();
            ViewBag.d1 = ınboxnumber;
            var outnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outnumber;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = (string)Session["CustomerMail"];
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            c.Messages.Add(message);
            c.SaveChanges();
            return View();
        }
        public ActionResult CargoTracking(string search)
        {
            var cargo = from x in c.CargoDetailss select x;

            cargo = cargo.Where(x => x.TrackingCode.Contains(search));

            return View(cargo.ToList());
        }
        public ActionResult CustomerCargoTracking(string id)

        {
            var varaibles = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();

            return View(varaibles);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }

        public PartialViewResult Settings()
        {
            var mail = (string)Session["CustomerMail"];
            var id = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerID).FirstOrDefault();
            var customerfind = c.Customers.Find(id);
            return PartialView("Settings", customerfind);

        }
        public PartialViewResult Notice()
        {
            var data = c.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(data);
        }
        public ActionResult CustomerInfoUpdate(Customer customer)
        {
            var cst = c.Customers.Find(customer.CustomerID);
            cst.CustomerName = customer.CustomerName;
            cst.CustomerSurName = customer.CustomerSurName;
            cst.Password = customer.Password;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}