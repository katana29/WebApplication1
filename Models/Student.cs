using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public string StudentID { get; set; }
        [StringLength(100)]

        [Display(Name = "Broj indexa")]
        public string BrIndexa { get; set; }
        [StringLength(100)]

        [Display(Name = "Ime i prezime")]
        public string imePrezime { get; set; }
        [StringLength(255)]

        [Display(Name = "Grad")]
        public string grad { get; set; }
       
    }
}