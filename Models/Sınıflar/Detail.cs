﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Detail
    {
        [Key]
        public int DetailID { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string ProductInfo { get; set; }
    }
}