using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }




        public int CategoryID { get; set; }
        public virtual Category category { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }

    }
}