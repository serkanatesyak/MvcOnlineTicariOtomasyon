using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string EmployeeSurName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }

        public int DepartmentID { get; set; }



        public ICollection<SalesMove> SalesMoves { get; set; }
        public virtual Department Department { get; set; }




    }
}