using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        public string CustomerName { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemessiniz.")]
        public string CustomerSurName { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(13)]
        public string CustomerCity { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CustomerMail { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Password { get; set; }


        public ICollection<SalesMove> SalesMoves { get; set; }
        public bool Status { get; set; }
    }
}