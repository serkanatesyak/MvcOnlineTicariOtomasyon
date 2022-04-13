using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Recipt
    {
        [Key]
        public int ReciptID { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string ReciptSerialNumber { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string ReciptRankNumber { get; set; }

        public DateTime ReciptDate { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string ReciptTime { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Submitter { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }

        public decimal Total { get; set; }


        public ICollection<ReciptDetail> ReciptDetails { get; set; }


    }
}