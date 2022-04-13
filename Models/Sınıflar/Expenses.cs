using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Expenses
    {
        [Key]
        public int ExpensesID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string ExpensesDescription { get; set; }
        public DateTime ExpensesDate { get; set; }
        public decimal ExpensesPrice { get; set; }
    }
}