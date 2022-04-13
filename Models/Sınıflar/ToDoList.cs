using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class ToDoList
    {
        [Key]
        public int ToDoListID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "bit")]
        public bool Status { get; set; }



    }
}