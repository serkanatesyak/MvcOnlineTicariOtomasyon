using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class ReciptDetail
    {
        [Key]
        public int ReciptDetailID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string ReciptDetailDescription { get; set; }
        public string ReciptDetailQuantity { get; set; }
        public decimal ReciptDetailUnitPrice { get; set; }
        public decimal ReciptDetailAmount { get; set; }

        public int ReciptID { get; set; }


        public virtual Recipt Recipt { get; set; }
    }
}