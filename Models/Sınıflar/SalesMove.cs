using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class SalesMove
    {
        [Key]
        public int SalesMoveID { get; set; }


        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }


        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

        //ürün 
        public virtual Product Product { get; set; }
        //müşteri
        public virtual Customer Customer { get; set; }
        //kim sattı personel

        public virtual Employee Employee { get; set; }


    }
}