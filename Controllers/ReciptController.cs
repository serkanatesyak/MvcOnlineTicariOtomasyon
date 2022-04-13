using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{

    public class ReciptController : Controller
    {
        Context c = new Context();
        // GET: Recipt
        public ActionResult Index()
        {
            var list = c.Recipts.ToList();
            return View(list);
        }
        public ActionResult AddRecipt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRecipt(Recipt recipt)
        {
            c.Recipts.Add(recipt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetRecipt(int id)
        {
            var recipt = c.Recipts.Find(id);
            return View("GetRecipt", recipt);
        }
        public ActionResult UpdateRecipt(Recipt recipt)
        {

            var rcpt = c.Recipts.Find(recipt.ReciptID);
            rcpt.ReciptSerialNumber = recipt.ReciptSerialNumber;
            rcpt.ReciptRankNumber = recipt.ReciptRankNumber;
            rcpt.ReciptTime = recipt.ReciptTime;
            rcpt.ReciptDate = recipt.ReciptDate;
            rcpt.Submitter = recipt.Submitter;
            rcpt.Receiver = recipt.Receiver;
            rcpt.TaxAdministration = recipt.TaxAdministration;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ReciptDetails(int id)
        {
            var varaibles = c.ReciptDetails.Where(x => x.ReciptID == id).ToList();

            return View(varaibles);
        }
        public ActionResult NewDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewDetail(ReciptDetail reciptDetail)
        {
            c.ReciptDetails.Add(reciptDetail);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Dynamic()
        {
            Class5 cs = new Class5();
            cs.Recipts = c.Recipts.ToList();
            cs.ReciptDetails = c.ReciptDetails.ToList();
            return View(cs);
        }
        public ActionResult ReciptSave(string ReciptSerialNumber, string ReciptRankNumber, DateTime ReciptDate,
            string TaxAdministration, string ReciptTime, string Submitter, string Receiver, string Total, ReciptDetail[] details)
        {
            Recipt f = new Recipt();
            f.ReciptSerialNumber = ReciptSerialNumber;
            f.ReciptRankNumber = ReciptRankNumber;
            f.ReciptDate = ReciptDate;
            f.TaxAdministration = TaxAdministration;
            f.ReciptTime = ReciptTime;
            f.Submitter = Submitter;
            f.Receiver = Receiver;
            f.Total = decimal.Parse(Total);
            c.Recipts.Add(f);
            foreach (var x in details)
            {
                ReciptDetail rd = new ReciptDetail();
                rd.ReciptDetailDescription = x.ReciptDetailDescription;
                rd.ReciptDetailUnitPrice = x.ReciptDetailUnitPrice;
                rd.ReciptID = x.ReciptDetailID;
                rd.ReciptDetailQuantity = x.ReciptDetailQuantity;
                rd.ReciptDetailAmount = x.ReciptDetailAmount;
                c.ReciptDetails.Add(rd);
                

            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);

        }
    }
}