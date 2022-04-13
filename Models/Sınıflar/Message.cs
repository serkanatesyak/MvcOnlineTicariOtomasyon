using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Delivery { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Subject { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string Contents { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime Date { get; set; }

    }
}