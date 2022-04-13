using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        Context c = new Context();
        // GET: Employee
        public ActionResult Index()
        {
            var employee = c.Employees.ToList();
            return View(employee);
        }


        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> var1 = (from x in c.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentID.ToString()
                                         }).ToList();

            ViewBag.varaible = var1;

            return View();
        }

        [HttpPost]
        public ActionResult EmployeeAdd(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ext = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + ext;
                Request.Files[0].SaveAs(Server.MapPath(path));
                employee.EmployeeImage = "~/Image/" + filename + ext;
            }
            c.Employees.Add(employee);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> var1 = (from x in c.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentID.ToString()
                                         }).ToList();
            var emp = c.Employees.Find(id);
            ViewBag.varaible = var1;
            return View("GetEmployee", emp);
        }
        public ActionResult UpdateEmployee(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ext = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + ext;
                Request.Files[0].SaveAs(Server.MapPath(path));
                employee.EmployeeImage = "~/Image/" + filename + ext;
            }
            var emp = c.Employees.Find(employee.EmployeeID);
            emp.EmployeeName = employee.EmployeeName;
            emp.EmployeeSurName = employee.EmployeeSurName;
            emp.EmployeeImage = employee.EmployeeImage;
            emp.DepartmentID = employee.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeList()
        {
            var list = c.Employees.ToList();
            return View(list);
        }

    }
}