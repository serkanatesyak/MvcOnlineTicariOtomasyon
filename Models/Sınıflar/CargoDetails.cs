using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class CargoDetails
    {
        [Key]
        public int CargoDetailsID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Employee { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string DeliveryPerson { get; set; }
        public DateTime Date { get; set; }
    }
}