using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        Context c = new Context();
        // GET: Cargo
        public ActionResult Index(string search)
        {
            var cargo = from x in c.CargoDetailss select x;
            if (!string.IsNullOrEmpty(search))
            {
                cargo = cargo.Where(x => x.TrackingCode.Contains(search));
            }
            return View(cargo.ToList());

        }
        [HttpGet]
        public ActionResult AddCargo()
        {
            Random random = new Random();
            string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int c1, c2, c3;
            c1 = random.Next(0, chars.Length);
            c2 = random.Next(0, chars.Length);
            c3 = random.Next(0, chars.Length);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string code = s1.ToString() + chars[c1] + s2 + chars[c2] + s3 + chars[c3];
            ViewBag.trackingcode = code;
            return View();

        }

        [HttpPost]
        public ActionResult AddCargo(CargoDetails cargoDetails)
        {
            c.CargoDetailss.Add(cargoDetails);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult CargoTracking(string id)
        {
            //trackingcode = "380A66C34D";
            var varaibles = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(varaibles);
        }





    }
}