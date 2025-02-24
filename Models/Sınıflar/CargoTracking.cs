﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingID { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}