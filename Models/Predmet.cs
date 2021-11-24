using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Predmet")]
    public class Predmet
    {
        [Key]
        public string PredmetID { get; set; }
        [StringLength(100)]

        [Display(Name = "Naziv predmeta")]
        public string NazivPredmeta { get; set; }
        

    }
}