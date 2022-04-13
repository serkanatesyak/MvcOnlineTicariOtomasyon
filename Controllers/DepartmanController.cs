using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    [Authorize(Roles = "A")]
    public class DepartmanController : Controller
    {
        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var varaibles = c.Departments.Where(x => x.Status == true).ToList();
            return View(varaibles);
        }

        [HttpGet]
        public ActionResult AddDepartman()
        {
            return View();

        }

        [HttpPost]
        

        public ActionResult AddDepartman(Department department)
        {
            c.Departments.Add(department);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanDelete(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GetDepartman(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("GetDepartman", dpt);
        }
        [HttpPost]
        public ActionResult DepartmanUpdate(Department department)
        {
            var dep = c.Departments.Find(department.DepartmentID);
            dep.DepartmentName = department.DepartmentName;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetails(int id)
        {
            var varaibles = c.Employees.Where(x => x.DepartmentID == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(varaibles);
        }
        public ActionResult DepartmanEmployeSales(int id)
        {
            var varaibles = c.SalesMoves.Where(x => x.EmployeeID == id).ToList();
            var per = c.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName + " " + y.EmployeeSurName).FirstOrDefault();
            ViewBag.dper = per;
            return View(varaibles);
        }

    }
}