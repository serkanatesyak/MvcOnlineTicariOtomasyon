using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grapichdraw = new Chart(600, 600);
            grapichdraw.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değeler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(grapichdraw.ToWebImage().GetBytes(), "image/jpg");
        }
        Context c = new Context();


        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = c.Products.ToList();
            result.ToList().ForEach(x => xvalue.Add(x.ProductName));
            result.ToList().ForEach(y => yvalue.Add(y.Stock));
            var graphic = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpg");
        }


        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(Productlist(), JsonRequestBehavior.AllowGet); ;
        }

        public List<Class2> Productlist()
        {
            List<Class2> cls = new List<Class2>();
            cls.Add(new Class2()
            {
                ProductName = "Bilgisayar",
                Stock = 120
            });

            cls.Add(new Class2()
            {
                ProductName = "Beyaz Eşya",
                Stock = 150
            });
            cls.Add(new Class2()
            {
                ProductName = "Mobilya",
                Stock = 70
            });
            cls.Add(new Class2()
            {
                ProductName = "Küçük Ev Aletleri",
                Stock = 180
            });
            cls.Add(new Class2()
            {
                ProductName = "Mobil Cihazlar",
                Stock = 90
            });
            return cls;
        }
        public ActionResult Index5()
        {
            return View();
        }


        public ActionResult VisualizeProductResult2()
        {
            return Json(Productlist2(), JsonRequestBehavior.AllowGet);
        }

        public List<Class3> Productlist2()
        {
            List<Class3> cls = new List<Class3>();
            using (var c = new Context())
            {
                cls = c.Products.Select(x => new Class3
                {
                    prd = x.ProductName,
                    Stk = x.Stock
                }).ToList();
            }
            return cls;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }

    }
}